using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega1
{
    public class Usuario
    {
        private static int _ultimoId = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }

        public Usuario()
        {
            Id = _ultimoId++;
        }

        public Usuario(string nombre, string apellido, string email, string pass):this()
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Pass = pass;
        }

        public override string ToString()
        {
            return $"{Nombre}, {Apellido}, {Email}, {Pass}, {Id}";
        }
    }
}
