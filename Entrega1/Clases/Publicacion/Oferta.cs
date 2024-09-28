using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entrega1.Clases.Usuarios;
using Entrega1.Interfaz;

namespace Entrega1.Clases.Publicacion
{
    public class Oferta: Iverificar
    {
        private static int _ultimoId = 1;
        public int Id { get; set; }
        public double Monto { get; set; }
        public Cliente Usuario { get; set; }
        //Le cambio algo?
        public DateTime Fecha { get; set; }

        public Oferta()
        {
            _ultimoId++;
        }
        public Oferta(double monto, Cliente usuario, DateTime fecha) : this()
        {
            Monto = monto;
            Usuario = usuario;
            Fecha = fecha;
        }
        public override string ToString()
        {
            return $"{Monto}, {Usuario}, {Fecha}";
        }

        public void Verificar()
        {
            if (double.IsNaN(Monto)|| Monto < 1)
            {
                throw new Exception("Monto no valido");
            }
            if(Usuario == null)
            {
                throw new Exception("Usuario no valido");
            }
        }
    }
}
