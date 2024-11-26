document.querySelector("#formLogin").addEventListener("submit", verificarForm)

function verificarForm(evt) {
    evt.preventDefault()
    m = dqs("mail").value
    p = dqs("pass").value
    if (m == "" || p=="" ) {
        alert("Campos no válidos")
    } else {
        this.submit()
    }

}
function dqs(id) {
    return document.querySelector("#" + id)
}