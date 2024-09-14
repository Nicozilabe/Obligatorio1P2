using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega1
{
    public class Cliente:Usuario
    {
        public double Saldo { get; set; }
        public Cliente()
        {
            
        }
        public Cliente(string nombre, string apellido, string email, string pass, double saldo) : base(nombre, apellido, email, pass)
        {
            Saldo = saldo;
        }
        public override string ToString()
        {
            return $"{Nombre}, {Apellido}, {Email}, {Pass}, {Id}, {Saldo}";
        }
    }
}
