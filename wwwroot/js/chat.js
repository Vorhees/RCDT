"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disabled until connection is established.
document.getElementById("sendButton").disabled = true;

// Disabled until all group members join the connection.
document.getElementById("itemBank").style.pointerEvents = "none";
document.getElementById("chessBoard").style.pointerEvents = "none";
document.getElementById("itemBank").style.opacity = "0.4";
document.getElementById("chessBoard").style.opacity = "0.4";

connection.on("ReceiveMessage", function (user, message) {
    
    var msg = message.replace( /&/g, "&amp;" ).replace( /</g, "&lt;" ).replace( />/g, "&gt;" );
    var encodedMsg = user + ": " + msg;
    //var encodedMsg = msg;

    var p = document.createElement("p");

    p.textContent = encodedMsg;

    document.getElementById("chatBox").appendChild(p);
});

connection.on("UserConnected", function(connectionId, count)
{
    var totalNumInGroup = document.getElementById("userCount").value;

    console.log("User is connected with connection ID: " + connectionId)

    console.log("Number of users connected: " + count);

    var groupElement = document.getElementById("group");

    console.log("I joined the group: " + groupElement.value);

    connection.invoke("JoinGroup", groupElement.value).catch(function (err)
    {
        return console.error(err.toString());
    });


    if (count < totalNumInGroup) {
        console.log("Not enough users connected, Users Connected: " + count + "/" + totalNumInGroup);
    }

    if (count == totalNumInGroup)
    {
        console.log("Enough members joined, you can start the task");

        document.getElementById("itemBank").style.pointerEvents = "auto";
        document.getElementById("chessBoard").style.pointerEvents = "auto";
        document.getElementById("itemBank").style.opacity = "1.0";
        document.getElementById("chessBoard").style.opacity = "1.0";
    }

    event.preventDefault();
});

connection.on("UserDisconnected", function(connectionId)
{
    var groupElement = document.getElementById("group");

    for (var i = 0; i < groupElement.length; i++)
    {
        if (groupElement.options[i].value == connectionId)
        {
            groupElement.remove(i);
            console.log("USER: " + connectionId + " has left.");
        }
    }
});

// connection.on("UserNumber", function(count)
// {
//     console.log("Number of users joined: " + count);
// });

connection.start().then(function() {

    document.getElementById("sendButton").disabled = false;

}).catch(function (err) {
    
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var groupElement = document.getElementById("group").value;
    //var groupValue = groupElement.options[groupElement.selectedIndex].value;

    connection.invoke("SendMessageToGroup", groupElement, user, message).catch(function (err) {
        //console.log(user);
        return console.error(err.toString());
    });

    event.preventDefault();

    document.getElementById("messageInput").value = '';
});
