using Entrega1.Clases.Publicacion;
using Entrega1.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega1.Clases.Usuarios
{
    public abstract class Usuario:Iverificar
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
        public Usuario(string nombre, string apellido, string email, string pass) : this()
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

        public virtual void Verificar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Nombre no valido");
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("Apellido no valida");
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("Email no valido");
            }
            if (!ValidarPass(Pass))
            {
                throw new Exception("Password no valida");
            }

        }
        public bool ValidarPass(string pass)
        {
            bool letra = false;
            bool numero = false;
            if (!string.IsNullOrEmpty(Pass) && pass.Length > 7)
            {
                foreach (char c in pass)
                {
                    if (char.IsLetter(c))
                    {
                        letra = true;
                    }else if (char.IsDigit(c))
                    {
                        numero = true;
                    }
                }
            }
            return (letra && numero);
        }
        public  override bool Equals(object? obj)
        {
            return obj is Usuario usuario && Email == usuario.Email;
        }
    }
}
