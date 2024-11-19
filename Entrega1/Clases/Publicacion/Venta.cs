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
        
        // Esto probablemente no sea String.
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

        public override void PublicacionComprada(Cliente c)
        {
            if (c.SaldoSuficiente(this.CalcularPrecio()))
            {
                Realizador = c;
                Comprador = c;
                c.DescontarSaldo(this.CalcularPrecio());
                Estado = TipoEstado.Cerrada;
            }
            else{
                throw new Exception("Saldo no valido");
            }
        }
    }
}
