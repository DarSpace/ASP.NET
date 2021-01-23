$(document).ready(function () {
    var connection = $.hubConnection();
    var hub = connection.createHubProxy("CounterHub");
    hub.on("newClient", function (hitCounter) {
        $("#CounterHub").text(hitCounter);
    });
    connection.start(function () {
        hub.invoke("Increment");
    });
});