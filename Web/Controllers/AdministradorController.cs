using Entrega1;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AdministradorController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        public IActionResult Index()
        {
            return View();
        }
    }
}
