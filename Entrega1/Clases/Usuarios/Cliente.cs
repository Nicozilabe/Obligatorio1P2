using Entrega1.Clases.Publicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega1.Clases.Usuarios
{
    public class Cliente : Usuario
    {
        public double Saldo { get; set; }

        public Cliente()
        {
            Saldo = 0;
        }
        public Cliente(string nombre, string apellido, string email, string pass, double saldo) : base(nombre, apellido, email, pass)
        {
            Saldo = saldo;
        }
        public override string ToString()
        {
            return $"{Nombre}, {Apellido}, {Email}, {Pass}, id: {Id}, {Saldo}";
        }
        
        public override void Verificar()
        {
            base.Verificar();
            if (double.IsNaN(Saldo) || Saldo < 0)
            {
                throw new Exception("Saldo no valido");
            }
        }
        // Metodo para cargar saldo.
        public void CargarSaldo(double montonero)
        {
            if (montonero < 0 || double.IsNaN(montonero)) { 
                throw new Exception("Monto ingresado no válido"); 
            } else {
                Saldo += montonero;
            }
        }
        public void DescontarSaldo(double montonero)
        {
            if (montonero < 0 || double.IsNaN(montonero))
            {
                throw new Exception("Monto a descontar no válido");
            }
            else
            {
                Saldo -= montonero;
            }
        }
        public bool SaldoSuficiente(double monto)
        {
            return (Saldo >= monto);
        }
    }
}
