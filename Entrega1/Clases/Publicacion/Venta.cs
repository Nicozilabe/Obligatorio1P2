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
        public string EstadoVenta { get; set; }
        // Esto probablemente no sea String.
        public bool EsOfertaRelampago { get; set; }
        //constructor posta
        public Venta(string nombre) : base(nombre)
        {

        }
        //Constructor precarga
        public Venta(string nombre, string estado, DateTime fechaPublicacion, Cliente realizador, bool esOfertaRelampago, Cliente comprador, DateTime fechaDeFin, string estadoVenta) : base(nombre, estado, fechaPublicacion, realizador, comprador, fechaDeFin)
        {
            EstadoVenta = estadoVenta;
            EsOfertaRelampago = esOfertaRelampago;
        }

        public override string ToString()
        {
            string s = "No es oferta relampago";
            if (EsOfertaRelampago)
            {
                s = "Es oferta relampago";
            }
            return "Venta: " + base.ToString() + $",{EstadoVenta}, {s}";
        }

        public override void Verificar()
        {
            base.Verificar();
            if (string.IsNullOrEmpty(EstadoVenta))
            {
                throw new Exception("Estado de venta no valido.");
            }
        }
    }
}
