using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entrega1.Clases.Usuarios;
using Entrega1.Interfaz;

namespace Entrega1.Clases.Publicacion
{
    public class Subasta : Publicacion
    {
        public List<Oferta> _ofertas = new List<Oferta>();

        public Subasta()
        { }

        //contructor posta
        public Subasta(string nombre) : base(nombre)
        { }

        //constructor precarga
        public Subasta(string nombre, string estado, DateTime fechaPublicacion, Cliente realizador, Cliente comprador, DateTime fechaDeFin) : base(nombre, estado, fechaPublicacion, realizador, comprador, fechaDeFin)
        { }

        public override string ToString()
        {
            return "Subasta: " + base.ToString() + $", Cantidad de ofertas{_ofertas.Count()}";
        }
        //valida si no hay una oferta igual o de mayor valor
        public void OfertaValida(Oferta o)
        {
            if (_ofertas.Contains(o))
            {
                throw new Exception("Oferta ya existente");
            }
            else
            {
                foreach (Oferta oferta in _ofertas)
                {
                    if (oferta.Monto >= o.Monto)
                    {
                        throw new Exception("El monto debe ser superior a la anterior oferta");
                    }
                }
            }
        }

        public void AgregarOferta(Oferta o)
        {
            o.Verificar();
            OfertaValida(o);
            _ofertas.Add(o);
        }

        public override void CerrarPublicacion(Usuario u)
        {
            if (u is Administrador a)
            {
                bool encontrado = false;
                for (int i = _ofertas.Count() - 1; i > 0 && !encontrado; i--)
                {
                    Oferta o = _ofertas[i];
                    o.Verificar();
                    // oferta.Verificar ya verifica que el cliente posea el saldo suficiente
                    o.Usuario.DescontarSaldo(o.Monto);
                    Realizador = a;
                    Comprador = o.Usuario;
                    Estado = TipoEstado.Cerrada;
                    FechaDeFin = DateTime.Now;
                    encontrado = true;
                }
                if (!encontrado)
                {
                    throw new Exception("No se encuentran ofertas validas.");
                }
            }
            else
            {
                throw new Exception("La subasta debe ser cerrada por un adminstrador.");
            }
        }
    }
}
