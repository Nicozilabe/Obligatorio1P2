document.querySelector("#formRegistro").addEventListener("submit", verificarForm)

function verificarForm(evt) {
    evt.preventDefault()
    m = dqs("mail").value;
    p = dqs("pass").value;
    n = dqs("Nombre").value;
    a = dqs("Apellido").value;
    if (m == "" || a == "" || n == "") {
        alert("Campos no válidos")
    } else if (!validarPass(p)) {
        alert("La contraseña debe ser alfanumerica con 8 cáracteres como mínimo")
    } else {
        this.submit()
    }

}
function validarPass(pass) {
    let letra = false;
    let numero = false;
    let largo = false;
    if (pass.length >= 8) {
        largo = true;
    }
    for (let i = 0; i < pass.length; i++) {
        const actual = pass.charCodeAt(i);
        if (actual >= 48 && actual <= 57) {
            numero = true;
        }
        if (actual >= 97 && actual <= 122) {
            letra = true;
        }
        if (actual >= 65 && actual <= 90) {
            letra = true;
        }
    } return (largo && letra && numero);
}
function dqs(id) {
    return document.querySelector("#" + id)
}