using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entrega1
{
    public class Publicacion
    {
        private static int _ultimoId = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        // Prob enumerado.
        public DateTime FechaPublicacion { get; set; }
        private List<Articulo> Articulos = new List<Articulo>();
        public Cliente Realizador { get; set; }
        public bool EsOfertaRelampago { get; set; }
        public Cliente Comprador { get; set; }
        public DateTime FechaDeFin { get; set; }

        public Publicacion()
        {
            _ultimoId++;
        }
        public Publicacion(string nombre, string estado, DateTime fechaPublicacion, Cliente realizador, bool esOfertaRelampago, Cliente comprador, DateTime fechaDeFin):this()
        {
            Nombre = nombre;
            Estado = estado;
            FechaPublicacion = fechaPublicacion;
            Realizador = realizador;
            EsOfertaRelampago = esOfertaRelampago;
            Comprador = comprador;
            FechaDeFin = fechaDeFin;
        }

        public override string ToString()
        {
            return $"{Nombre}, {Estado}, {FechaPublicacion}, {Realizador}, {EsOfertaRelampago}, {Comprador}, {FechaDeFin}";
        }

        public List<Articulo> GetArticulos()
        {
            return Articulos;
        }
        public void AgregarArticulo(Articulo art1)
        {
            Articulos.Add(art1);
        }
    }
}
