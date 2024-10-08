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
        private List<Oferta> _ofertas = new List<Oferta>();

        public Subasta()
        {

        }
        //contructor posta
        public Subasta(string nombre) : base(nombre)
        {

        }
        //constructor precarga
        public Subasta(string nombre, string estado, DateTime fechaPublicacion, Cliente realizador,  Cliente comprador, DateTime fechaDeFin) : base(nombre, estado, fechaPublicacion, realizador, comprador, fechaDeFin)
        {

        }
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
    }
}
