using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
