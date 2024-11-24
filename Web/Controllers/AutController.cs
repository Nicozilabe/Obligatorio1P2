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
        public IActionResult Index()
        {
            return View();
        }

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
                catch (Exception ex)
                {
                    //ViewBag.msg = e.Message;
                }
            }
            return View();
        }
        public IActionResult Logout() 
        { 
            if(HttpContext.Session.GetInt32("logueadoId") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}