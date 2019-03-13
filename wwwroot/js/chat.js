"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disabled until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (message) {
    
    var msg = message.replace( /&/g, "&amp;" ).replace( /</g, "&lt;" ).replace( />/g, "&gt;" );
    var encodedMsg = "User: " + msg;
    var p = document.createElement("p");

    p.textContent = encodedMsg;

    document.getElementById("chatBox").appendChild(p);

});

connection.start().then(function() {

    document.getElementById("sendButton").disabled = false;

}).catch(function (err) {
    
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {

    var message = document.getElementById("messageInput").value;

    connection.invoke("SendMessage", message).catch(function (err) {
        
        return console.error(err.toString());
    });

    event.preventDefault();

    document.getElementById("messageInput").value = '';
});