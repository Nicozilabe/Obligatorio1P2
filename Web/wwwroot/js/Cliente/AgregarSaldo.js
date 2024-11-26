document.querySelector("#formAgregarSaldo").addEventListener("submit", verificarForm)

function verificarForm(evt) {
    evt.preventDefault()
    m = dqs("montoCliente").value
    if (m == "" || m < 0 || isNaN(m)) {
        alert("Monto no válido")
    } else {
        this.submit()
    }

}
function dqs(id) {
    return document.querySelector("#" + id)
}