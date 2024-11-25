using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entrega1.Clases.Usuarios;
using Entrega1.Interfaz;

namespace Entrega1.Clases.Publicacion
{
    public class Venta : Publicacion
    {
        public bool EsOfertaRelampago { get; set; }

        //constructor posta
        public Venta(string nombre) : base(nombre)
        {

        }
        //Constructor precarga
        public Venta(string nombre, string estado, DateTime fechaPublicacion, Cliente realizador, bool esOfertaRelampago, Cliente comprador, DateTime fechaDeFin, string estadoVenta) : base(nombre, estado, fechaPublicacion, realizador, comprador, fechaDeFin)
        {
            EsOfertaRelampago = esOfertaRelampago;
        }

        public override string ToString()
        {
            string s = "No es oferta relampago";
            if (EsOfertaRelampago)
            {
                s = "Es oferta relampago";
            }
            return "Venta: " + base.ToString() + s;
        }

        public override void CerrarPublicacion(Usuario u)
        {
            if (u is Cliente c && Estado == TipoEstado.Abierta)
            {
                if (c.SaldoSuficiente(this.CalcularPrecio()))
                {
                    Realizador = c;
                    Comprador = c;
                    c.DescontarSaldo(this.CalcularPrecio());
                    Estado = TipoEstado.Cerrada;
                }
                else
                {
                    throw new Exception("Saldo no valido");
                }
            }
            else if (Estado != TipoEstado.Abierta)
            {
                throw new Exception("Publicación ya cerrada");
            }else{
                throw new Exception("La compra debe ser realizada por clientes.");
            }
        }
        public double CalcularPrecio()
        {
            double ret = 0;
            foreach (Articulo a in Articulos)
            {
                ret += a.Precio;
            }
            return ret;
        }
    }
}
