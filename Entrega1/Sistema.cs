using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entrega1.Clases.Publicacion;
using Entrega1.Clases.Usuarios;

namespace Entrega1
{
    public class Sistema
    {
        private List<Articulo> Articulos = new List<Articulo>();
        private List<Usuario> Usuarios = new List<Usuario>();
        private List<Publicacion> Publicaciones = new List<Publicacion>();
        private static Sistema? instancia = null;
        private Sistema()
        {
            precargarDatos();
        }

        private void precargarDatos()
        {
            //Cliente c1 = new Cliente(...);
            //AltaCliente(c1);
        }

        public static Sistema GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Sistema();
                
            }
            return instancia;
            
        }
    }
}
