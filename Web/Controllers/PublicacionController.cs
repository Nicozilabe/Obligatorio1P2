﻿using Entrega1;
using Entrega1.Clases.Publicacion;
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
            if (HttpContext.Session.GetString("logeadoRol") == "Cliente")
            {
                return View(s.GetPublicaciones());
            }
            else
            {
                return RedirectToAction("NotAllowed", "Aut");
            }
        }
        [HttpGet]
        public IActionResult Venta(int id)
        {
            if (HttpContext.Session.GetString("logeadoRol") == "Cliente")
            {
                ViewBag.idCliente = HttpContext.Session.GetInt32("logueadoId");
                return View(s.GetVentaById(id));
            }
            else
            {
                return RedirectToAction("NotAllowed", "Aut");
            }

        }
        [HttpPost]
        public IActionResult Venta(int idVenta, int idCliente)
        {
            if (HttpContext.Session.GetString("logeadoRol") == "Cliente")
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
                catch (Exception ex)
                {
                    ViewBag.msg = ex.Message;
                }
                return View(s.GetVentaById(idVenta));
            }
            else
            {
                return RedirectToAction("NotAllowed", "Aut");
            }

        }
        [HttpGet]
        public IActionResult Subasta(int id)
        {
            if (HttpContext.Session.GetString("logeadoRol") == "Cliente")
            {
                return View(s.GetSubastaById(id));
            }
            else
            {
                return RedirectToAction("NotAllowed", "Aut");
            }

        }
        [HttpPost]
        public IActionResult Subasta(int id, double monto)
        {
            if (HttpContext.Session.GetString("logeadoRol") == "Cliente")
            {
                Subasta sub = s.GetSubastaById(id);
                if (double.IsNaN(monto) || monto < 0)
                {
                    ViewBag.msg = "Monto no válido";
                }
                else if (sub._ofertas.Count() != 0)
                {
                    if (monto < sub._ofertas.Last().Monto)
                    {
                        ViewBag.msg = "El monto debe ser mayor a la anterior oferta";
                    }
                }
                else
                {
                    try
                    {
                        s.AgregarOfertaASubastas(HttpContext.Session.GetInt32("logueadoId"), id, monto);

                    }
                    catch (Exception ex)
                    {
                        { ViewBag.msg = ex.Message; }

                    }

                }
                return View(s.GetSubastaById(id));
            }
            else
            {
                return RedirectToAction("NotAllowed", "Aut");
            }


        }
    }
}
