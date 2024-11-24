using Entrega1;
using Entrega1.Clases.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace Web.Controllers
{
    public class ClienteController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        public IActionResult AgregarSaldo()
        {
            ViewBag.rol= HttpContext.Session.GetString("logueadoRol");
            return View();
        }

        [HttpPost]
        public IActionResult AgregarSaldo(double monto)
        {
            if (double.IsNaN(monto) || monto < 0)
            {
                ViewBag.msg = "Monto no válido";
            }
            else
            {
                try
                {
                    s.AgregarSaldoAUser(HttpContext.Session.GetInt32("logueadoId"), monto);
                    Cliente c = s.GetCliente(HttpContext.Session.GetInt32("logueadoId"));
                    HttpContext.Session.SetInt32("logueadoSaldo", (int)c.Saldo);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ViewBag.msg= ex.Message;
                }
            }
            return View();
        }
    }
}
