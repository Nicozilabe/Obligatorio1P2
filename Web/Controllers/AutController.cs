using Entrega1;
using Entrega1.Clases.Publicacion;
using Entrega1.Clases.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Web.Models;

namespace Web.Controllers
{
    public class AutController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel lm)
        {
            // Si los datos son invalidos o el Email/Pass estan vacios, mandara un mensaje de alerta.
            if (lm == null || string.IsNullOrEmpty(lm.Email) || string.IsNullOrEmpty(lm.Pass))
            {
                ViewBag.msg = "Los datos ingresados deben ser validos.";
            }
            else
            {
                // Sino, tomara los datos, los lanza al metodo de comparacion en el sistema, y los guardara para saber que persona exactamente esta conectada en ese momento. Si el usuario ingresado es un Cliente, lo relaciona como tal y envia al usuario a una vista perteneciente a su rol especifico (redireccion). Ademas, si Usu es cliente, guarda el saldo del cliente en la sesion.
                try
                {
                    Usuario usu = s.Login(lm.Email, lm.Pass);
                    HttpContext.Session.SetInt32("logueadoId", usu.Id);
                    HttpContext.Session.SetString("logueadoRol", usu.GetType().Name);
                    HttpContext.Session.SetString("logueadoNombre", usu.Nombre);
                    if (usu is Cliente c)
                    {
                        HttpContext.Session.SetInt32("logueadoSaldo", (int)c.Saldo);
                    }
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    ViewBag.msg = e.Message;
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            //Podria quitar todo el IF y dejar el Clear.
            if (HttpContext.Session.GetInt32("logueadoId") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            HttpContext.Session.Clear();
            //TempData["Message"] = "Sesion cerrada correctamente.";
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro(Cliente cli)
        {
            try
            {
                cli.Verificar();
                s.AltaCliente(cli);
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();
        }
        public IActionResult NotAllowed()
        {
            return View();
        }
    }
}