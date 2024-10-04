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
        private static Sistema? instancia = null;
        private Sistema()
        {
            precargarDatos();
        }

        private void precargarDatos()
        {
            List<Usuario> _usuarios = new List<Usuario>();


            // Administradores
            AltaAdministrador(new Administrador("Carlos", "Gomez", "carlos@admin.com", "admin123"));
            AltaAdministrador(new Administrador("Lucia", "Martinez", "lucia@admin.com", "admin456"));


            // Clientes
            AltaCliente(new Cliente("Ana", "Lopez", "al@gmail.com", "al222", 222));
            AltaCliente(new Cliente("Luis", "Fernandez", "lf@gmail.com", "lf333", 500));
            AltaCliente(new Cliente("Maria", "Sanchez", "ms@gmail.com", "ms444", 300));
            AltaCliente(new Cliente("Pedro", "Gonzalez", "pg@gmail.com", "pg555", 150));
            AltaCliente(new Cliente("Sara", "Perez", "sp@gmail.com", "sp666", 120));
            AltaCliente(new Cliente("Jose", "Rodriguez", "jr@gmail.com", "jr777", 350));
            AltaCliente(new Cliente("Marta", "Diaz", "md@gmail.com", "md888", 700));
            AltaCliente(new Cliente("Javier", "Martinez", "jm@gmail.com", "jm999", 100));
            AltaCliente(new Cliente("Raul", "Lopez", "rl@gmail.com", "rl000", 450));
            AltaCliente(new Cliente("Elena", "Jimenez", "ej@gmail.com", "ej111", 600));


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
            List<Cliente> clientes = new List<Cliente>();
            foreach(Usuario u in _usuarios)
            {
                if (u is Cliente c)
                {
                    clientes.Add(c);
                }
            }
            return clientes;
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
            ArticuloExistente(x);
            _articulos.Add(x);
        }
        public void AltaCliente(Cliente x)
        {
            x.Verificar();
            if (!_usuarios.Contains(x))
            {
                _usuarios.Add(x);
            }
            else
            {
                throw new Exception("El cliente ya existe");
            }
        }
        public void AltaAdministrador(Administrador x)
        {
            x.Verificar();
            if (!_usuarios.Contains(x))
            {
                _usuarios.Add(x);
            }
            else
            {
                throw new Exception("El administrador ya existe");
            }
        }
        //public void AltaOferta(Oferta o, int idPublicación)
        //{
        //     no es necesario aun
        //}

        public void ArticuloExistente(Articulo x)
        {
            if (_articulos.Contains(x))
            {
                throw new Exception("Articulo ya existente");
            }
        }
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
