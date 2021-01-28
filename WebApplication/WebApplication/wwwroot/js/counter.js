"use strict";


var counterConnection = new signalR.HubConnectionBuilder().withUrl("/counterHub").build();



counterConnection.start().catch(function (err) {
    return console.error(err.toString());
});

counterConnection.on("ReceiveCounter", (counterVisit) => {
    
        document.getElementById("counter").innerText = counterVisit;
    });





