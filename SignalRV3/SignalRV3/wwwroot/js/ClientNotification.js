var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.start();
connection.on("Message", function (msg) {
    var li = document.createElement("li");
    li.textContent = msg;
    document.getElementById("msglist").appendChild(li);
});