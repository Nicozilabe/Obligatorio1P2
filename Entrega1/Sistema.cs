using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Entrega1.Clases.Publicacion;
using Entrega1.Clases.Usuarios;

namespace Entrega1
{
    public class Sistema
    {
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Cliente> _clientes = new List<Cliente>();
        private List<Administrador> _administradores = new List<Administrador>();
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
        public List<Cliente> GetClientes()
        {
            return _clientes;
        }

        public void AltaVenta(Venta x)
        {
            x.Verificar();
            _publicaciones.Add(x);
        }
        public void AltaSubasta(Subasta x)
        {
            x.Verificar();
            _publicaciones.Add(x);
        }
        public void AltaArticulo(Articulo x)
        {
            x.Verificar();
            _articulos.Add(x);
        }
        public void AltaCliente(Cliente x)
        {
            x.Verificar();
            if (!_clientes.Contains(x))
            {
                _clientes.Add(x);
            }
            else
            {
                throw new Exception("El cliente ya existe");
            }
        }
        public void AltaAdministrador(Administrador x)
        {
            x.Verificar();
            if (!_administradores.Contains(x))
            {
                _administradores.Add(x);
            }
            else
            {
                throw new Exception("El administrador ya existe");
            }
        }
        //public void AltaOferta(Oferta o, int idPublicación)
        //{
        //     No se que onda aca.
        //}


        public List<Articulo> GetArticulos()
        {
            return _articulos;
        }
        public List<Publicacion> GetPublicaciones()
        {
            return _publicaciones;
        }

    }
}
