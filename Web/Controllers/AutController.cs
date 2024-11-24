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
            if (lm == null || string.IsNullOrEmpty(lm.Email) || string.IsNullOrEmpty(lm.Pass))
            {
                ViewBag.msg = "Los datos ingresados deben ser validos.";
            }
            else
            {
                try
                {
                    Usuario usu = s.Login(lm.Email, lm.Pass);
                    HttpContext.Session.SetInt32("logueadoId", usu.Id);
                    HttpContext.Session.SetString("logueadoRol", usu.GetType().Name);
                    HttpContext.Session.SetString("logueadoNombre", usu.Nombre);
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
            if (HttpContext.Session.GetInt32("logueadoId") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            HttpContext.Session.Clear();
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
                RedirectToAction("Login");
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();
        }
    }
}