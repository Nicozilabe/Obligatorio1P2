using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
        private static Sistema? _instancia = null;

        private Sistema()
        {
            // ¡Aqui se meten los datos precargados!
            precargarDatos();
        }
        private void precargarDatos()
        {
            // Precargas generadas por una IA.

            // 10 clientes
            AltaCliente(new Cliente("Carlos", "Gonzalez", "carlos.gonzalez@mail.com", "password123", 10000));
            AltaCliente(new Cliente("Ana", "Martinez", "ana.martinez@mail.com", "password456", 15000));
            AltaCliente(new Cliente("Luis", "Ramirez", "luis.ramirez@mail.com", "password789", 20000));
            AltaCliente(new Cliente("Maria", "Lopez", "maria.lopez@mail.com", "password012", 25000));
            AltaCliente(new Cliente("Jose", "Hernandez", "jose.hernandez@mail.com", "password345", 30000));
            AltaCliente(new Cliente("Lucia", "Garcia", "lucia.garcia@mail.com", "password678", 18000));
            AltaCliente(new Cliente("Diego", "Perez", "diego.perez@mail.com", "password901", 22000));
            AltaCliente(new Cliente("Sofia", "Rodriguez", "sofia.rodriguez@mail.com", "password234", 17000));
            AltaCliente(new Cliente("Pedro", "Sanchez", "pedro.sanchez@mail.com", "password567", 21000));
            AltaCliente(new Cliente("Valeria", "Torres", "valeria.torres@mail.com", "password890", 19000));

            // 2 administradores
            AltaAdministrador(new Administrador("Roberto", "Fernandez", "roberto.fernandez@mail.com", "admin123"));
            AltaAdministrador(new Administrador("Sandra", "Morales", "sandra.morales@mail.com", "admin456"));

            // 50 articulos.
            AltaArticulo(new Articulo("Laptop HP", "Electrónica", 25000));
            AltaArticulo(new Articulo("Smartphone Samsung", "Electrónica", 18000));
            AltaArticulo(new Articulo("Tablet Lenovo", "Electrónica", 12000));
            AltaArticulo(new Articulo("Smart TV LG", "Electrónica", 40000));
            AltaArticulo(new Articulo("Cámara Canon", "Fotografía", 15000));
            AltaArticulo(new Articulo("Parlante JBL", "Electrónica", 5000));
            AltaArticulo(new Articulo("Auriculares Sony", "Electrónica", 8000));
            AltaArticulo(new Articulo("Mouse Logitech", "Accesorios", 2000));
            AltaArticulo(new Articulo("Teclado Mecánico", "Accesorios", 6000));
            AltaArticulo(new Articulo("Monitor Dell", "Electrónica", 35000));
            AltaArticulo(new Articulo("Impresora HP", "Oficina", 7000));
            AltaArticulo(new Articulo("Silla Gamer", "Muebles", 18000));
            AltaArticulo(new Articulo("Escritorio", "Muebles", 9000));
            AltaArticulo(new Articulo("Cafetera Nespresso", "Electrodomésticos", 5000));
            AltaArticulo(new Articulo("Refrigerador Samsung", "Electrodomésticos", 55000));
            AltaArticulo(new Articulo("Lavadora LG", "Electrodomésticos", 40000));
            AltaArticulo(new Articulo("Microondas Panasonic", "Electrodomésticos", 3000));
            AltaArticulo(new Articulo("Plancha Philips", "Electrodomésticos", 2500));
            AltaArticulo(new Articulo("Ventilador Liliana", "Electrodomésticos", 3500));
            AltaArticulo(new Articulo("Aspiradora Bosch", "Electrodomésticos", 6000));
            AltaArticulo(new Articulo("Consola PlayStation", "Videojuegos", 55000));
            AltaArticulo(new Articulo("Consola Xbox", "Videojuegos", 45000));
            AltaArticulo(new Articulo("Juegos de PS5", "Videojuegos", 6000));
            AltaArticulo(new Articulo("Juegos de Xbox", "Videojuegos", 5000));
            AltaArticulo(new Articulo("Bicicleta Mountain Bike", "Deportes", 30000));
            AltaArticulo(new Articulo("Trotadora Eléctrica", "Deportes", 35000));
            AltaArticulo(new Articulo("Set de Mancuernas", "Deportes", 5000));
            AltaArticulo(new Articulo("Guantes de Boxeo", "Deportes", 3000));
            AltaArticulo(new Articulo("Balón de Fútbol", "Deportes", 1500));
            AltaArticulo(new Articulo("Reloj Deportivo Garmin", "Deportes", 12000));
            AltaArticulo(new Articulo("Sudadera Nike", "Ropa", 2500));
            AltaArticulo(new Articulo("Zapatillas Adidas", "Ropa", 6000));
            AltaArticulo(new Articulo("Jeans Levis", "Ropa", 4500));
            AltaArticulo(new Articulo("Chaqueta North Face", "Ropa", 12000));
            AltaArticulo(new Articulo("Gafas Ray-Ban", "Accesorios", 5000));
            AltaArticulo(new Articulo("Mochila Samsonite", "Accesorios", 4000));
            AltaArticulo(new Articulo("Maleta de Viaje", "Accesorios", 9000));
            AltaArticulo(new Articulo("Colchón King Size", "Muebles", 35000));
            AltaArticulo(new Articulo("Almohada Viscoelástica", "Muebles", 2000));
            AltaArticulo(new Articulo("Lámpara de Mesa", "Iluminación", 1500));
            AltaArticulo(new Articulo("Ventana de PVC", "Construcción", 10000));
            AltaArticulo(new Articulo("Puerta de Madera", "Construcción", 15000));
            AltaArticulo(new Articulo("Set de Herramientas", "Hogar", 3000));
            AltaArticulo(new Articulo("Taladro Bosch", "Herramientas", 4500));
            AltaArticulo(new Articulo("Batería de Cocina", "Hogar", 7000));
            AltaArticulo(new Articulo("Juego de Platos", "Hogar", 3000));
            AltaArticulo(new Articulo("Tetera Eléctrica", "Electrodomésticos", 2000));
            AltaArticulo(new Articulo("Horno Eléctrico", "Electrodomésticos", 4000));
            AltaArticulo(new Articulo("FurSuit", "Vestimenta", 40000));
            AltaArticulo(new Articulo("Kamasutra", "Lectura", 600));

            // Subasta 1 - Sin ofertas
            AltaSubasta(new Subasta("Cámara Canon", "ABIERTA", DateTime.Now.AddDays(-10), null, null, DateTime.Now.AddDays(20)));

            // Subasta 2 - Sin ofertas
            AltaSubasta(new Subasta("Smart TV LG", "ABIERTA", DateTime.Now.AddDays(-25), null, null, DateTime.Now.AddDays(15)));


            // Subasta 3 - Con ofertas
            Subasta subas1 = new Subasta("Laptop HP", "ABIERTA", DateTime.Now.AddDays(-12), null, null, DateTime.Now.AddDays(18));
            subas1.AgregarOferta(new Oferta(26000, _usuarios[1] as Cliente, DateTime.Now.AddDays(-10)));
            subas1.AgregarOferta(new Oferta(27000, _usuarios[2] as Cliente, DateTime.Now.AddDays(-8)));
            AltaSubasta(subas1);

            // Subasta 4 - Con ofertas
            Subasta subas2 = new Subasta("Consola PlayStation", "ABIERTA", DateTime.Now.AddDays(-18), null, null, DateTime.Now.AddDays(22));
            subas2.AgregarOferta(new Oferta(56000, _usuarios[4] as Cliente, DateTime.Now.AddDays(-16)));
            subas2.AgregarOferta(new Oferta(57000, _usuarios[6] as Cliente, DateTime.Now.AddDays(-14)));
            AltaSubasta(subas2);


            // Subasta 5 - Sin ofertas
            AltaSubasta(new Subasta("Bicicleta Mountain Bike", "ABIERTA", DateTime.Now.AddDays(-21), null, null, DateTime.Now.AddDays(20)));

            // Subasta 6 - Sin ofertas
            AltaSubasta(new Subasta("Juegos de PS5", "ABIERTA", DateTime.Now.AddDays(-35), null, null, DateTime.Now.AddDays(25)));

            // Subasta 7 - Sin ofertas
            AltaSubasta(new Subasta("Sudadera Nike", "ABIERTA", DateTime.Now.AddDays(-27), null, null, DateTime.Now.AddDays(15)));

            // Subasta 8 - Sin ofertas
            AltaSubasta(new Subasta("Aspiradora Bosch", "ABIERTA", DateTime.Now.AddDays(-14), null, null, DateTime.Now.AddDays(10)));

            // Subasta 9 - Sin ofertas
            AltaSubasta(new Subasta("Impresora HP", "ABIERTA", DateTime.Now.AddDays(-20), null, null, DateTime.Now.AddDays(17)));

            // Subasta 10 - Sin ofertas
            AltaSubasta(new Subasta("Auriculares Sony", "ABIERTA", DateTime.Now.AddDays(-7), null, null, DateTime.Now.AddDays(15)));

            _publicaciones[0].AgregarArticulo(_articulos[4]);
            _publicaciones[1].AgregarArticulo(_articulos[3]);
            _publicaciones[2].AgregarArticulo(_articulos[0]);
            _publicaciones[3].AgregarArticulo(_articulos[20]);
            _publicaciones[4].AgregarArticulo(_articulos[24]);
            _publicaciones[5].AgregarArticulo(_articulos[22]);
            _publicaciones[6].AgregarArticulo(_articulos[30]);
            _publicaciones[7].AgregarArticulo(_articulos[19]);
            _publicaciones[8].AgregarArticulo(_articulos[10]);
            _publicaciones[9].AgregarArticulo(_articulos[6]);

            // Venta 1
            AltaVenta(new Venta("Laptop HP", "COMPLETADA", DateTime.Now.AddDays(-45), _usuarios[9] as Cliente, false, _usuarios[9] as Cliente, DateTime.Now.AddDays(-40), "COMPLETADA"));

            // Venta 2
            AltaVenta(new Venta("Smartphone Samsung", "COMPLETADA", DateTime.Now.AddDays(-33), _usuarios[7] as Cliente, false, _usuarios[7] as Cliente, DateTime.Now.AddDays(-30), "COMPLETADA"));

            // Venta 3
            AltaVenta(new Venta("Tablet Lenovo", "COMPLETADA", DateTime.Now.AddDays(-25), _usuarios[6] as Cliente, false, _usuarios[6] as Cliente, DateTime.Now.AddDays(-22), "COMPLETADA"));

            // Venta 4
            AltaVenta(new Venta("Monitor Dell", "COMPLETADA", DateTime.Now.AddDays(-20), _usuarios[5] as Cliente, false, _usuarios[5] as Cliente, DateTime.Now.AddDays(-18), "COMPLETADA"));

            // Venta 5
            AltaVenta(new Venta("Cafetera Nespresso", "COMPLETADA", DateTime.Now.AddDays(-28), _usuarios[8] as Cliente, false, _usuarios[8] as Cliente, DateTime.Now.AddDays(-25), "COMPLETADA"));

            // Venta 6
            AltaVenta(new Venta("Silla Gamer", "COMPLETADA", DateTime.Now.AddDays(-32), _usuarios[3] as Cliente, false, _usuarios[3] as Cliente, DateTime.Now.AddDays(-28), "COMPLETADA"));

            // Venta 7
            AltaVenta(new Venta("Batería de Cocina", "COMPLETADA", DateTime.Now.AddDays(-38), _usuarios[2] as Cliente, false, _usuarios[2] as Cliente, DateTime.Now.AddDays(-35), "COMPLETADA"));

            // Venta 8
            AltaVenta(new Venta("Lavadora LG", "COMPLETADA", DateTime.Now.AddDays(-12), _usuarios[7] as Cliente, false, _usuarios[7] as Cliente, DateTime.Now.AddDays(-10), "COMPLETADA"));

            // Venta 9
            AltaVenta(new Venta("Consola Xbox", "COMPLETADA", DateTime.Now.AddDays(-18), _usuarios[0] as Cliente, false, _usuarios[0] as Cliente, DateTime.Now.AddDays(-15), "COMPLETADA"));

            // Venta 10
            AltaVenta(new Venta("Parlante JBL", "COMPLETADA", DateTime.Now.AddDays(-8), _usuarios[2] as Cliente, false, _usuarios[2] as Cliente, DateTime.Now.AddDays(-5), "COMPLETADA"));

            _publicaciones[10].AgregarArticulo(_articulos[0]);
            _publicaciones[11].AgregarArticulo(_articulos[1]);
            _publicaciones[12].AgregarArticulo(_articulos[2]);
            _publicaciones[13].AgregarArticulo(_articulos[9]);
            _publicaciones[14].AgregarArticulo(_articulos[13]);
            _publicaciones[15].AgregarArticulo(_articulos[11]);
            _publicaciones[16].AgregarArticulo(_articulos[44]);
            _publicaciones[17].AgregarArticulo(_articulos[15]);
            _publicaciones[18].AgregarArticulo(_articulos[21]);
            _publicaciones[19].AgregarArticulo(_articulos[5]);
        }

        public static Sistema GetInstancia()
        {
            // Es para que no se dupliquen las instancias de Sistema.
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }

        // Altas.
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

        public void ArticuloExistente(Articulo x)
        {
            if (_articulos.Contains(x))
            {
                throw new Exception("Articulo ya existente");
            }
        }
        
        public List<Cliente> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente c)
                {
                    clientes.Add(c);
                }
            }
            return clientes;
        }
        public List<Articulo> GetArticulos()
        {
            return _articulos;
        }
        public List<Publicacion> GetPublicaciones()
        {
            return _publicaciones;
        }
        public List<Publicacion> GetPublicacionesActivas()
        {
            List <Publicacion> ret = new List<Publicacion>();
            foreach(Publicacion p in _publicaciones)
            {
                if (p.Estado == TipoEstado.Abierta)
                {
                    ret.Add(p);
                }
            }
            return ret;
        }
        public List<Usuario> GetUsuarios()
        {
            return _usuarios;
        }
        public  List<Subasta> GetSubastas(){
            List < Subasta > subastas = new List < Subasta >();
            foreach (Publicacion p in GetPublicaciones())
            {
                if(p is Subasta s)
                {
                    subastas.Add(s);
                }
            }
            return subastas;
        }
        public List<Venta> GetVentas()
        {
            List<Venta> ventas = new List <Venta>();
            foreach (Publicacion p in GetPublicaciones())
            {
                if(p is Venta v)
                {
                    ventas.Add(v);
                }
            }
            return ventas;
        }
        
        // Parte 2 del menu en Program.
        public List<Articulo> BuscarPorCategoria(string c)
        {
            //VerificarCategoria(c); realizamos la validación en el program (que no sea vacía)
            List<Articulo> ret = new List<Articulo>();
            foreach(Articulo a in _articulos)
            {
                if (Regex.Replace(a.Categoria.ToLower().Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "") == c.ToLower())
                {
                    ret.Add(a);
                }
            }
            return ret;
        }
        
        // Parte 4 del menu en Program.
        public List<Publicacion> GetPublicacionesPorFecha(DateTime inicio, DateTime fin)
        {
            List<Publicacion> publicaciones = GetPublicaciones();
            List<Publicacion> ret = new List<Publicacion>();
            foreach (Publicacion p in publicaciones)
            {
                if (p.FechaPublicacion >= inicio && p.FechaPublicacion <= fin)
                {
                    ret.Add(p);
                }
            }
            return ret;
        }
        public Cliente GetCliente(int? idCliente) {

            List<Cliente> clientes = GetClientes();
            foreach (Cliente c in clientes)
            {
                if (c.Id == idCliente)
                {
                    return c;

                } 
            }
            throw new Exception("Cliente no encontrado");
        }

        public void AgregarSaldoAUser(int? idUser, double monto)
        {
            Cliente cliente = GetCliente(idUser);
            if (cliente == null) {
                throw new Exception("Usuario no válido");
            } else {
                cliente.CargarSaldo(monto); 
            }
        }

        public Subasta GetSubastaById(int idSubasta)
        {
            foreach (Subasta s in GetSubastas())
            {
                if (s.Id == idSubasta)
                {
                    return s;
                }
            }
            throw new Exception("Subasta no encontrada.");
        }
        public Venta GetVentaById(int idVenta)
        {
            foreach (Venta v in GetVentas())
            {
                if (v.Id == idVenta)
                {
                    return v;
                }
            }
            throw new Exception("Venta no encontrada.");
        }
        public Publicacion GetPublicacionById(int idPublicacion)
        {
            foreach (Publicacion p in GetPublicaciones())
            {
                if(p.Id == idPublicacion)
                {
                    return p;
                }
            }
            throw new Exception("Publicacion no encontrada.");
        }
        public Usuario GetUsuarioById(int idUsuario)
        {
            // List<Usuario> ret = new List<Usuario>();
            foreach(Usuario u in GetUsuarios())
            {
                if (u.Id == idUsuario) 
                { 
                    return u;
                }
            }
            throw new Exception("Usuario no encontrado");
        }

        // 
        public void AgregarOfertaASubastas(int idCliente, int idSubasta,double monto)
        {
            Subasta s = GetSubastaById(idSubasta);
            Oferta o = new Oferta(monto, GetCliente (idCliente), DateTime.Now);
            o.Verificar();
            if (s != null)
            {
                s.AgregarOferta(o);
            }else
            {
                throw new Exception("Oferta no valida");
            }
        }

        public void CerrarPublicacion(int idUsuario, int idPublicacion)
        {
            Publicacion p = GetPublicacionById(idPublicacion);
            p.CerrarPublicacion(GetUsuarioById(idUsuario));
        }

        public Usuario Login(string Email, string Pass)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.Email.Equals(Email) && u.Pass.Equals(Pass))
                {
                    return u; 
                }
            }
            throw new Exception("Email o contraseña no validos.");
        }
    }
}
