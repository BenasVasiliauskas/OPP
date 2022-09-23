"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();


connection.on("ReceiveMessage", function (direction) {
    console.log(direction)
    var div = document.getElementById(direction);
    console.log(div);
    div.classList.toggle("grid-item-1");
});

connection.start();

const divs = document.querySelectorAll(".grid-item");

divs.forEach(div => {
    console.log("test")
    div.addEventListener("click", function (e) {
        connection.invoke("SendMessage", div.innerHTML).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var direction = document.getElementById("userInput").value;
//    connection.invoke("SendMessage", direction).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});