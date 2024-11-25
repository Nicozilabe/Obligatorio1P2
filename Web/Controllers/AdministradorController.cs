using Entrega1;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AdministradorController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        //roberto.fernandez@mail.com admin123
        public IActionResult Index()
        {
            return View();
        }
    }
}
