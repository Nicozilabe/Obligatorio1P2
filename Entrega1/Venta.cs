using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega1
{
    public class Venta:Publicacion
    {
        public string EstadoVenta { get; set; }
        // Esto probablemente no sea String.

        public Venta()
        {

        }
        public Venta(string nombre, string estado, DateTime fechaPublicacion, Cliente realizador, bool esOfertaRelampago, Cliente comprador, DateTime fechaDeFin, string estadoVenta):base(nombre, estado, fechaPublicacion, realizador, esOfertaRelampago, comprador, fechaDeFin)
        {
            EstadoVenta = estadoVenta;
        }
        public override string ToString()
        {
            return $"{Nombre}, {Estado}, {FechaPublicacion}, {Realizador}, {EsOfertaRelampago}, {Comprador}, {FechaDeFin}, {EstadoVenta}"; 
        }
    }
}
