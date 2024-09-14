﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega1
{
    public class Administrador : Usuario
    {
        public Administrador():base()
        {
        }
        public Administrador(string nombre, string apellido, string email, string pass) : base(nombre, apellido, email, pass)
        {
        }
        public override string ToString()
        {
            return $"{Nombre}, {Apellido}, {Email}, {Pass}, {Id}";
        }
    }
}
