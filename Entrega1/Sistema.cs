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

            // Creación de Administradores
            _usuarios.Add(new Administrador("Juan", "Pérez", "juan.perez@empresa.com", "admin123"));
            _usuarios.Add(new Administrador("Ana", "Lopez", "ana.lopez@empresa.com", "admin456"));

            // Creación de Clientes
            _usuarios.Add(new Cliente("Carlos", "Gomez", "carlos.gomez@cliente.com", "cliente1123", 1000));
            _usuarios.Add(new Cliente("Maria", "Martinez", "maria.martinez@cliente.com", "cliente2123", 2000));
            _usuarios.Add(new Cliente("Luis", "Rodriguez", "luis.rodriguez@cliente.com", "cliente3123", 3000));
            _usuarios.Add(new Cliente("Laura", "Fernandez", "laura.fernandez@cliente.com", "cliente4123", 4000));
            _usuarios.Add(new Cliente("Jose", "Gonzalez", "jose.gonzalez@cliente.com", "cliente5123", 5000));
            _usuarios.Add(new Cliente("Sofia", "Perez", "sofia.perez@cliente.com", "cliente6123", 6000));
            _usuarios.Add(new Cliente("Pedro", "Diaz", "pedro.diaz@cliente.com", "cliente7123", 7000));
            _usuarios.Add(new Cliente("Marta", "Hernandez", "marta.hernandez@cliente.com", "cliente8123", 8000));
            _usuarios.Add(new Cliente("Antonio", "Sanchez", "antonio.sanchez@cliente.com", "cliente9123", 9000));
            _usuarios.Add(new Cliente("Elena", "Ramirez", "elena.ramirez@cliente.com", "cliente10123", 10000));

        }

        public static Sistema GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Sistema();
            }
            return instancia;
        }
        public List<Usuario> GetClientes()
        {
            return _usuarios;
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
        //     No se que onda aca.
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
