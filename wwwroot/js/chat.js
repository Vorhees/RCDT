"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disabled until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    
    var msg = message.replace( /&/g, "&amp;" ).replace( /</g, "&lt;" ).replace( />/g, "&gt;" );
    var encodedMsg = user + ": " + msg;
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
    
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    connection.invoke("SendMessage", user, message).catch(function (err) {
        //console.log(user);
        return console.error(err.toString());
    });

    event.preventDefault();

    document.getElementById("messageInput").value = '';
});