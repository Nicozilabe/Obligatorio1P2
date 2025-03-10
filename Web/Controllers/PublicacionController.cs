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
            if (HttpContext.Session.GetString("logueadoRol") == "Cliente")
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
            if (HttpContext.Session.GetString("logueadoRol") == "Cliente")
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
            if (HttpContext.Session.GetString("logueadoRol") == "Cliente")
            {
                if (s.GetVentaById(idVenta).Estado == TipoEstado.Abierta)
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
                }
                else
                {
                    ViewBag.msg = "Venta ya cerrada";
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
            if (HttpContext.Session.GetString("logueadoRol") == "Cliente")
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
            if (HttpContext.Session.GetString("logueadoRol") == "Cliente")
            {
                Subasta sub = s.GetSubastaById(id);
                if (double.IsNaN(monto) || monto < 0)
                {
                    ViewBag.msg = "Monto no válido";
                }
                else if (sub.Estado == TipoEstado.Abierta)
                {
                    try
                    {
                        s.AgregarOfertaASubastas(HttpContext.Session.GetInt32("logueadoId"), id, monto);

                    }
                    catch (Exception ex)
                    {
                        ViewBag.msg = ex.Message;
                    }
                }
                else
                {
                    ViewBag.msg = "Subasta ya cerrada.";
                }
                return View(s.GetSubastaById(id));
            }
            else
            {
                return RedirectToAction("NotAllowed", "Aut");
            }
        }

        public IActionResult Subastas()
        {
            if (HttpContext.Session.GetString("logueadoRol") == "Administrador")
            {
                return View(s.GetSubastas());
            }
            else
            {
                return RedirectToAction("NotAllowed", "Aut");
            }
        }
        [HttpGet]
        public IActionResult CerrarSubasta(int id)
        {
            if (HttpContext.Session.GetString("logueadoRol") == "Administrador")
            {
                return View(s.GetSubastaById(id));
            }
            else
            {
                return RedirectToAction("NotAllowed", "Aut");
            }
        }
        [HttpPost]
        public IActionResult CerrarSubasta(int id, bool check)
        {
            if (HttpContext.Session.GetString("logueadoRol") == "Administrador")
            {
                if (s.GetSubastaById(id).Estado == TipoEstado.Abierta && check)
                {
                    int? idAdmin = HttpContext.Session.GetInt32("logueadoId");
                    try
                    {
                        s.CerrarPublicacion(idAdmin, id);
                        ViewBag.msg = "Subasta finalizada exitosamente.";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.msg = ex.Message;
                    }
                }
                else if (!check)
                {
                    ViewBag.msg = "Debe seleccionar el checkbox";
                }
                else
                {
                    ViewBag.msg = "La subasta ya fue finalizada previamente.";
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

