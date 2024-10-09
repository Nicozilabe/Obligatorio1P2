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
        public Cliente? Realizador { get; set; }
        
        public Cliente? Comprador { get; set; }
        public DateTime? FechaDeFin { get; set; }

        public Publicacion()
        {
            Id=_ultimoId++;
        }
        //Constructor para precarga
        public Publicacion(string nombre, string estado, DateTime fechaPublicacion, Cliente realizador, Cliente comprador, DateTime fechaDeFin) : this()
        {
            Nombre = nombre;
            Estado = estado;
            FechaPublicacion = fechaPublicacion;
            Realizador = realizador;
            Comprador = comprador;
            FechaDeFin = fechaDeFin;
        }
        //constructor posta
        public Publicacion(string nombre)
        {
            Nombre = nombre;
            Estado = "ABIERTO";
            FechaPublicacion = DateTime.Now;
            Realizador = null;
            Comprador = null;
            FechaDeFin = null;

        }
        // Para saber que artículos tiene cada publicación.
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
            string s = "No es oferta rempalago";
            string comp = "---";
            string real = "---";
            if (Comprador != null)
            {
                comp = Comprador.Nombre;
            }
            if (Realizador != null)
            {
                real = Realizador.Nombre;
            }
            return $"Id:{Id}, {Nombre},Cantidad artículos:{Articulos.Count()} {Estado}, {FechaPublicacion}, {real}, {comp}, {FechaDeFin}";
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

        }
    }
}
