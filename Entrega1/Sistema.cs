using System;
using System.Collections.Generic;
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
        private static Sistema? instancia = null;

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

            // Subasta 1 - Sin ofertas
            AltaSubasta(new Subasta("Cámara Canon", "ABIERTA", DateTime.Now.AddDays(-10), new Cliente("Jose", "Hernandez", "jose.hernandez@mail.com", "password345", 30000), false, null, DateTime.Now.AddDays(20)));

            // Subasta 2 - Sin ofertas
            AltaSubasta(new Subasta("Smart TV LG", "ABIERTA", DateTime.Now.AddDays(-25), new Cliente("Lucia", "Garcia", "lucia.garcia@mail.com", "password678", 18000), false, null, DateTime.Now.AddDays(15)));


            // Subasta 3 - Con ofertas
            Subasta subas1 = new Subasta("Laptop HP", "ABIERTA", DateTime.Now.AddDays(-12), new Cliente("Carlos", "Gonzalez", "carlos.gonzalez@mail.com", "password123", 10000), false, null, DateTime.Now.AddDays(18));
            subas1.AgregarOferta(new Oferta(26000, new Cliente("Ana", "Martinez", "ana.martinez@mail.com", "password456", 15000), DateTime.Now.AddDays(-10)));
            subas1.AgregarOferta(new Oferta(27000, new Cliente("Luis", "Ramirez", "luis.ramirez@mail.com", "password789", 20000), DateTime.Now.AddDays(-8)));
            AltaSubasta(subas1);

            // Subasta 4 - Con ofertas
            Subasta subas2 = new Subasta("Consola PlayStation", "ABIERTA", DateTime.Now.AddDays(-18), new Cliente("Diego", "Perez", "diego.perez@mail.com", "password901", 22000), false, null, DateTime.Now.AddDays(22));
            subas2.AgregarOferta(new Oferta(56000, new Cliente("Sofia", "Rodriguez", "sofia.rodriguez@mail.com", "password234", 17000), DateTime.Now.AddDays(-16)));
            subas2.AgregarOferta(new Oferta(57000, new Cliente("Pedro", "Sanchez", "pedro.sanchez@mail.com", "password567", 21000), DateTime.Now.AddDays(-14)));
            AltaSubasta(subas2);


            // Subasta 5 - Sin ofertas
            AltaSubasta(new Subasta("Bicicleta Mountain Bike", "ABIERTA", DateTime.Now.AddDays(-21), new Cliente("Valeria", "Torres", "valeria.torres@mail.com", "password890", 19000), false, null, DateTime.Now.AddDays(20)));

            // Subasta 6 - Sin ofertas
            AltaSubasta(new Subasta("Juegos de PS5", "ABIERTA", DateTime.Now.AddDays(-35), new Cliente("Lucia", "Garcia", "lucia.garcia@mail.com", "password678", 18000), false, null, DateTime.Now.AddDays(25)));

            // Subasta 7 - Sin ofertas
            AltaSubasta(new Subasta("Sudadera Nike", "ABIERTA", DateTime.Now.AddDays(-27), new Cliente("Carlos", "Gonzalez", "carlos.gonzalez@mail.com", "password123", 10000), false, null, DateTime.Now.AddDays(15)));

            // Subasta 8 - Sin ofertas
            AltaSubasta(new Subasta("Aspiradora Bosch", "ABIERTA", DateTime.Now.AddDays(-14), new Cliente("Ana", "Martinez", "ana.martinez@mail.com", "password456", 15000), false, null, DateTime.Now.AddDays(10)));

            // Subasta 9 - Sin ofertas
            AltaSubasta(new Subasta("Impresora HP", "ABIERTA", DateTime.Now.AddDays(-20), new Cliente("Luis", "Ramirez", "luis.ramirez@mail.com", "password789", 20000), false, null, DateTime.Now.AddDays(17)));

            // Subasta 10 - Sin ofertas
            AltaSubasta(new Subasta("Auriculares Sony", "ABIERTA", DateTime.Now.AddDays(-7), new Cliente("Pedro", "Sanchez", "pedro.sanchez@mail.com", "password567", 21000), false, null, DateTime.Now.AddDays(15)));



            // Venta 1
            AltaVenta(new Venta("Laptop HP", "COMPLETADA", DateTime.Now.AddDays(-45), new Cliente("Carlos", "Gonzalez", "carlos.gonzalez@mail.com", "password123", 10000), false, new Cliente("Ana", "Martinez", "ana.martinez@mail.com", "password456", 15000), DateTime.Now.AddDays(-40), "COMPLETADA"));

            // Venta 2
            AltaVenta(new Venta("Smartphone Samsung", "COMPLETADA", DateTime.Now.AddDays(-33), new Cliente("Luis", "Ramirez", "luis.ramirez@mail.com", "password789", 20000), false, new Cliente("Maria", "Lopez", "maria.lopez@mail.com", "password012", 25000), DateTime.Now.AddDays(-30), "COMPLETADA"));

            // Venta 3
            AltaVenta(new Venta("Tablet Lenovo", "COMPLETADA", DateTime.Now.AddDays(-25), new Cliente("Diego", "Perez", "diego.perez@mail.com", "password901", 22000), false, new Cliente("Sofia", "Rodriguez", "sofia.rodriguez@mail.com", "password234", 17000), DateTime.Now.AddDays(-22), "COMPLETADA"));

            // Venta 4
            AltaVenta(new Venta("Monitor Dell", "COMPLETADA", DateTime.Now.AddDays(-20),  new Cliente("Jose", "Hernandez", "jose.hernandez@mail.com", "password345", 30000), false, new Cliente("Lucia", "Garcia", "lucia.garcia@mail.com", "password678", 18000), DateTime.Now.AddDays(-18), "COMPLETADA"));

            // Venta 5
            AltaVenta(new Venta("Cafetera Nespresso", "COMPLETADA", DateTime.Now.AddDays(-28), new Cliente("Pedro", "Sanchez", "pedro.sanchez@mail.com", "password567", 21000), false, new Cliente("Valeria", "Torres", "valeria.torres@mail.com", "password890", 19000), DateTime.Now.AddDays(-25), "COMPLETADA"));

            // Venta 6
            AltaVenta(new Venta("Silla Gamer", "COMPLETADA", DateTime.Now.AddDays(-32), new Cliente("Maria", "Lopez", "maria.lopez@mail.com", "password012", 25000), false, new Cliente("Carlos", "Gonzalez", "carlos.gonzalez@mail.com", "password123", 10000), DateTime.Now.AddDays(-28), "COMPLETADA"));

            // Venta 7
            AltaVenta(new Venta("Batería de Cocina", "COMPLETADA", DateTime.Now.AddDays(-38), new Cliente("Maria", "Lopez", "maria.lopez@mail.com", "password012", 25000), false, new Cliente("Carlos", "Gonzalez", "carlos.gonzalez@mail.com", "password123", 10000), DateTime.Now.AddDays(-35), "COMPLETADA"));

            // Venta 8
            AltaVenta(new Venta("Lavadora LG", "COMPLETADA", DateTime.Now.AddDays(-12), new Cliente("Ana", "Martinez", "ana.martinez@mail.com", "password456", 15000), false, new Cliente("Diego", "Perez", "diego.perez@mail.com", "password901", 22000), DateTime.Now.AddDays(-10), "COMPLETADA"));

            // Venta 9
            AltaVenta(new Venta("Consola Xbox", "COMPLETADA", DateTime.Now.AddDays(-18), new Cliente("Lucia", "Garcia", "lucia.garcia@mail.com", "password678", 18000), false, new Cliente("Sofia", "Rodriguez", "sofia.rodriguez@mail.com", "password234", 17000), DateTime.Now.AddDays(-15), "COMPLETADA"));

            // Venta 10
            AltaVenta(new Venta("Parlante JBL", "COMPLETADA", DateTime.Now.AddDays(-8), new Cliente("Valeria", "Torres", "valeria.torres@mail.com", "password890", 19000), false, new Cliente("Jose", "Hernandez", "jose.hernandez@mail.com", "password345", 30000), DateTime.Now.AddDays(-5), "COMPLETADA"));
        }

        public static Sistema GetInstancia()
        {
            // Es para que no se dupliquen las instancias de Sistema.
            if (instancia == null)
            {
                instancia = new Sistema();
            }
            return instancia;
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
        
        // Parte 2 del menu en Program.
        public List<Articulo> BuscarPorCategoria(string c)
        {
            VerificarCategoria(c);
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
        private void VerificarCategoria(string c)
        {
            if (string.IsNullOrEmpty(c))
            {
                throw new Exception("Categoría no valida");
            }
        }
        
        // Parte 4 del menu en Program.
        public List<Publicacion> GetPublicacionesPorFecha(DateTime inicio, DateTime fin)
        {
            VerificarFecha(inicio,fin);

            List<Publicacion> ret = new List<Publicacion>();
            foreach (Publicacion p in _publicaciones)
            {
                if (p.FechaPublicacion >= inicio && p.FechaPublicacion <= fin)
                {
                    ret.Add(p);
                }
            }
            return ret;
        }
        private void VerificarFecha(DateTime inicio, DateTime fin) {
            string errores = "";
            if (inicio > DateTime.Now) {
                errores += "La fecha de inicio no puede ser superior a la actual";
            }
            if (fin > DateTime.Now)
            {
                errores += " La fecha de inicio no puede ser superior a la actual";
            }
            if (inicio > fin) 
            { 
                errores += " La fecha de inicio no puede ser mayor a la de fin"; 
            }
            if (inicio < DateTime.Parse("31-12-2015"))
            {
                errores += " La fecha de inicio de busqueda no puede ser menor al 31 de diciembre de 2015";
            }
            if (!string.IsNullOrEmpty(errores))
            {
                throw new Exception(errores);
            }
        }
    }
}
