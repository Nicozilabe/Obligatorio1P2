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
            if (HttpContext.Session.GetString("logueadoRol") == "Cliente")
            {
                ViewBag.rol = HttpContext.Session.GetString("logueadoRol");
                return View();
            }
            else
            {
                return RedirectToAction("NotAllowed", "Aut");
            }


        }

        [HttpPost]
        public IActionResult AgregarSaldo(double monto)
        {
            if (HttpContext.Session.GetString("logueadoRol") == "Cliente")
            {
                if (double.IsNaN(monto) || monto < 0)
                {
                    ViewBag.msg = "Monto no válido";
                }
                else
                {
                    //Pasa al metodo en Sistema la id del usuario actual a traves del LogueadoId y el monto agregado. Actualiza el saldo en la sesion LogueadoSaldo con el actual (c.Saldo)
                    try
                    {
                        s.AgregarSaldoAUser(HttpContext.Session.GetInt32("logueadoId"), monto);
                        Cliente c = s.GetCliente(HttpContext.Session.GetInt32("logueadoId"));
                        HttpContext.Session.SetInt32("logueadoSaldo", (int)c.Saldo);
                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.msg = ex.Message;
                    }
                }
                return View();
            }
            else
            {
                return RedirectToAction("NotAllowed", "Aut");
            }


        }
    }
}
