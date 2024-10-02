using Entrega1.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega1.Clases.Publicacion
{
    public class Articulo : Iverificar
    {
        private static int _ultimoId = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }

        public Articulo()
        {
            Id = _ultimoId++;
        }

        public Articulo(string nombre, string categoria, double precio) : this()
        {
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"{Nombre}, {Categoria}, {Precio}, id:{Id}";
        }

        public void Verificar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Nombre no valido");
            }
            if (string.IsNullOrEmpty(Categoria))
            {
                throw new Exception("Categoria no valida");
            }
            if (double.IsNaN(Precio) || Precio < 1)
            {
                throw new Exception("Precio no valido");
            }

        }
    }
}
