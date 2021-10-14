window.onload = function () {
    let elem = document.getElementById("username");
    if (!elem) {
        return;
    }

    elem.onblur = function () {
        isUsernameValid(elem.value);
    }
}

function isUsernameValid(username) {
    let xhr = new XMLHttpRequest();

    xhr.open("POST", "/Login/CheckUsername");
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");

    let data = { "username": username };
    xhr.send(JSON.stringify(data));

    xhr.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE) {
            if (this.status !== 200)
                return;

            let data = JSON.parse(this.responseText);
            if (data.isOkay === false) {
                alert("Username is taken. Please use another username.");
                window.location.href = "/Login/NewUser";
            }
            
        }
    };
}