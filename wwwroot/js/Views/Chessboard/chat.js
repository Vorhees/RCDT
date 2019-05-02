"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var totalCount = 0;

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
    p.style.color = "blue";

    p.textContent = encodedMsg;

    document.getElementById("chatBox").appendChild(p);
});

connection.on("UserConnected", function(connectionId, count, groupName)
{
    var totalNumInGroup = document.getElementById("userCount").value;
    totalCount = count;

    console.log("User is connected with connection ID: " + connectionId)
    console.log("Total Users in group: " + totalNumInGroup);

    var groupElement = document.getElementById("group");

    connection.invoke("JoinGroup", groupElement.value).catch(function (err)
    {
        return console.error(err.toString());
    });

    console.log("I joined the group: " + groupElement.value);

    if (groupName != "Researcher")
    {
        if (groupElement.value == groupName)
        {
            console.log("My group name is (html): " + groupElement.value);
            console.log("My group name is (server): " + groupName);

            if (totalCount < totalNumInGroup) {
                console.log("Not enough users connected in group: "+ groupName + ", Users Connected: " + totalCount + "/" + totalNumInGroup);
            }

            if (totalCount == totalNumInGroup)
            {
            console.log("Enough members joined, you can start the task");

            document.getElementById("itemBank").style.pointerEvents = "auto";
            document.getElementById("chessBoard").style.pointerEvents = "auto";
            document.getElementById("itemBank").style.opacity = "1.0";
            document.getElementById("chessBoard").style.opacity = "1.0";
            }
        }
    }
    // else
    // {
    //         totalCount = totalCount--;
    // }


    console.log("Number of users connected: " + count);

    event.preventDefault();
});

connection.on("UserDisconnected", function(connectionId, username, newCount)
{
    var groupElement = document.getElementById("group");
    totalCount--;
    console.log("User disconnected: " + username);
    console.log("New count of users connected: " + totalCount);
});

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
        return console.error(err.toString());
    });

    event.preventDefault();

    document.getElementById("messageInput").value = '';
});
