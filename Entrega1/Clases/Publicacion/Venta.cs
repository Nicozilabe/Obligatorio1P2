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

        public Venta()
        {

        }
        public Venta(string nombre, string estado, DateTime fechaPublicacion, Cliente realizador, bool esOfertaRelampago, Cliente comprador, DateTime fechaDeFin, string estadoVenta) : base(nombre, estado, fechaPublicacion, realizador, esOfertaRelampago, comprador, fechaDeFin)
        {
            EstadoVenta = estadoVenta;
        }
        public override string ToString()
        {
            return "Venta: "+base.ToString() + $",{EstadoVenta}";
        }

        public override void Verificar()
        {
            base.Verificar();
            if (string.IsNullOrEmpty(EstadoVenta))
            {
                throw new Exception("Estado venta no valido");
            }

        }
    }
}
