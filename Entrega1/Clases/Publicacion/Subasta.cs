﻿using System;
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
        private List<Oferta> Ofertas = new List<Oferta>();

        public Subasta()
        {

        }
        public Subasta(string nombre, string estado, DateTime fechaPublicacion, Cliente realizador, bool esOfertaRelampago, Cliente comprador, DateTime fechaDeFin) : base(nombre, estado, fechaPublicacion, realizador, esOfertaRelampago, comprador, fechaDeFin)
        {

        }
        public override string ToString()
        {
            return $"";
        }
        
    }
}
