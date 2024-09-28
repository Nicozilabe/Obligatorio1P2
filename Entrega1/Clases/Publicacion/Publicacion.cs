using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Entrega1.Clases.Usuarios;
using Entrega1.Interfaz;

namespace Entrega1.Clases.Publicacion
{
    public abstract class Publicacion: Iverificar
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
        public Publicacion(string nombre, string estado, DateTime fechaPublicacion, Cliente realizador, bool esOfertaRelampago, Cliente comprador, DateTime fechaDeFin) : this()
        {
            Nombre = nombre;
            Estado = estado;
            FechaPublicacion = fechaPublicacion;
            Realizador = realizador;
            EsOfertaRelampago = esOfertaRelampago;
            Comprador = comprador;
            FechaDeFin = fechaDeFin;
        }
        public List<Articulo> GetArticulos()
        {
            return Articulos;
        }
        public void AgregarArticulo(Articulo art1)
        {
            Articulos.Add(art1);
        }


        public override string ToString()
        {
            return $"{Nombre}, {Estado}, {FechaPublicacion}, {Realizador}, {EsOfertaRelampago}, {Comprador}, {FechaDeFin}";
        }


        public virtual void Verificar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Nombre no valido");
            }
            if (string.IsNullOrEmpty(Estado))
            {
                throw new Exception("Estado no valido");
            }
            //Verificar datetime
            if (Realizador == null)
            {
                throw new Exception("Realizador no valido");
            }
            if (Comprador == null)
            {
                throw new Exception("Realizador no valido");
            }
        }
    }
}
