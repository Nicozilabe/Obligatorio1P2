using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega1
{
    public class Articulo
    {
        private static int _ultimoId = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        //Es enumerado, creo :(
        public double Precio { get; set; }

        public Articulo()
        {
            Id = _ultimoId++;
        }

        public Articulo(string nombre, string categoria, int precio):this()
        {
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
        }
        public override string ToString()
        {
            return $"{Nombre}, {Categoria}, {Precio}, id:{Id}";
        }
    }
}
