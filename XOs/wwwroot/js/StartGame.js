const name = sessionStorage.getItem("name");
if (name == null) {
    alert("Ошибка");
    document.location.href = "index.html";
}