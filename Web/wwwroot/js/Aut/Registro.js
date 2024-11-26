document.querySelector("#formRegistro").addEventListener("submit", verificarForm)

function verificarForm(evt) {
    evt.preventDefault()
    m = dqs("mail").value;
    p = dqs("pass").value;
    n = dqs("Nombre").value;
    a = dqs("Apellido").value;
    if (m == "" || p == "" || a == "" || n == "") {
        alert("Campos no válidos")
    } else {
        this.submit()
    }

}
function dqs(id) {
    return document.querySelector("#" + id)
}