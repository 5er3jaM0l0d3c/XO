// Создаем подключение к Hub
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

// Начинаем подключение
connection.start().then(() => {
    console.log("Connected!");
}).catch(err => {
    console.error(err.toString());
});

