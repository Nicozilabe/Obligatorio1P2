document.querySelector("#formSubasta").addEventListener("submit", verificarForm())

function verificarForm(evt) {
    evt.preventDefault()
    m = dqs(montoSubasta).value
    if (m == "" || m < 0 || m.isNaN()) {
        alert("Monto no válido")
    } else {
        this.submit()
    }
}
function dqs(id) {
    return document.querySelector("#"+id)
}