using Entrega1;
using Entrega1.Clases.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PublicacionController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        public IActionResult Index()
        {
            return View(s.GetPublicacionesActivas());
        }
        [HttpGet]
        public IActionResult Venta(int id) {
            ViewBag.idCliente = HttpContext.Session.GetInt32("logueadoId");
            return View(s.GetVentaById(id));
        }
        [HttpPost]
        public IActionResult Venta(int idVenta, int idCliente)
        {
            ViewBag.idCliente = HttpContext.Session.GetInt32("logueadoId");
            //El metodo se encarga de registrar la compra, actualizar el estado de la publicacion y descontar el saldo del cliente. Luego se actualiza el saldo del cliente en la sesion LogueadoSoldo
            try
            {
                s.CerrarPublicacion(idCliente, idVenta);
                Cliente c = s.GetCliente(HttpContext.Session.GetInt32("logueadoId"));
                HttpContext.Session.SetInt32("logueadoSaldo", (int)c.Saldo);
                ViewBag.msg = "Compra realizada efectivamente";
            }
            catch (Exception ex) { 
                ViewBag.msg = ex.Message;
            }
            return View(s.GetVentaById(idVenta));
        }
    }
}
