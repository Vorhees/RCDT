"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disabled until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    
    var msg = message.replace( /&/g, "&amp;" ).replace( /</g, "&lt;" ).replace( />/g, "&gt;" );
    var encodedMsg = user + ": " + msg;
    //var encodedMsg = msg;
    var p = document.createElement("p");

    p.textContent = encodedMsg;

    document.getElementById("chatBox").appendChild(p);

});

connection.on("UserConnected", function(connectionId)
{
    var groupElement = document.getElementById("group");
   // var option = document.createElement("option");

   // option.text = connectionId;
   // option.value = connectionId;

    console.log("User is connected with connection ID: " + connectionId)

   // groupElement.add(option);
});

connection.on("UserDisconnected", function(connectionId)
{
    var groupElement = document.getElementById("group");

    for (var i = 0; i < groupElement.length; i++)
    {
        if (groupElement.options[i].value == connectionId)
        {
            groupElement.remove(i);
        }
    }
});

connection.start().then(function() {

    document.getElementById("sendButton").disabled = false;

}).catch(function (err) {
    
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var groupElement = document.getElementById("group");
    var groupValue = groupElement.options[groupElement.selectedIndex].value;

    connection.invoke("SendMessageToGroup", groupValue, user, message).catch(function (err) {
        //console.log(user);
        return console.error(err.toString());
    });

    event.preventDefault();

    document.getElementById("messageInput").value = '';
});

document.getElementById("joinGroup").addEventListener("click", function(event)
{
    var groupElement = document.getElementById("group");
    var groupValue = groupElement.options[groupElement.selectedIndex].value;

    console.log("I joined the group: " + groupValue);

    connection.invoke("JoinGroup", groupValue).catch(function (err)
    {
        return console.error(err.toString());
    });

    event.preventDefault();
});
