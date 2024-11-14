async function endgame() {
    sessionStorage.clear();
    let response = await fetch("/api/endgame", {
        method: "GET",
        headers: {
            'Accept': "application/json",
            'Content-Type': "application/json"
        }
    })
    if (response.ok === true) {
        document.location.href = "index.html";
    }
}