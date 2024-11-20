let isConnected = false;
// Создаем подключение к Hub
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub", {
        timeout: 60000
    })
    .build();
connection.serverTimeoutInMilliseconds = 600000; // 600 seconds
connection.keepAliveIntervalInMilliseconds = 120000;
// Начинаем подключение
connection.start().then(() => {
    console.log("Connected!");
    isConnected = true;


    connection.invoke("SendLog", sessionStorage.getItem("name") + " : подключился(" + document.location.href + ")").catch(err => {
        console.error(err.toString());
    });
    
}).catch(err => {
    console.error(err.toString());
});
