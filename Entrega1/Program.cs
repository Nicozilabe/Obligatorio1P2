using Entrega1.Clases.Publicacion;
using Entrega1.Clases.Usuarios;

namespace Entrega1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Cliente cli1 = new Cliente("Sofía", "eso", "mylittlepony27@yahoo.com", "Pinkypie7892", 2020202);

            //Administrador admin = new Administrador("Furro", "1", "furrogenerico@aol.com", "ContraseniaFurraGenerica2");

            //Articulo a1 = new Articulo("Fur suit", "Drogas duras", 3499);

            //Venta v1 = new Venta("Verano en siberia", "desconocido", DateTime.Parse("04/10/1947"), cli1, true, cli1, DateTime.Parse("29/12/1991"), "ffff");

            //Oferta of1 = new Oferta(899, cli1, DateTime.Parse("21/07/1964"));

            //Subasta sub1 = new Subasta("Vacaciones en Tiawmen", "grrrr", DateTime.Parse("17/1/2017"), cli1, false, cli1, DateTime.Parse("18/03/2019"));

            
            //Console.WriteLine(u1);
            //Console.WriteLine(cli1);
            //Console.WriteLine(admin);
            //Console.WriteLine(a1);
            //Console.WriteLine(pub1);
            //Console.WriteLine(v1);
            //Console.WriteLine(of1);
            //Console.WriteLine(sub1);

            Sistema s = Sistema.GetInstancia();

            //s.AltaCliente(cli1);
            //s.AltaAdministrador(admin);
            //s.AltaArticulo(a1);
            //v1.AgregarArticulo(a1);
            //s.AltaVenta(v1);
            //sub1.OfertaValida(of1);
            //sub1.AgregarOferta(of1);
            //s.AltaSubasta(sub1);
           
            int op = -1;
            while (op != 0)
            {
                Console.Clear();
                Console.WriteLine("1 - Mostrar lista de Clientes");
                Console.WriteLine("2 - Elija por Categoria su articulo");
                Console.WriteLine("3 - Alta de articulo!");
                Console.WriteLine("4 - Encuentre Publicaciones por fechas dadas");
                Console.WriteLine("0 - Salir");

                op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    List<Cliente> clientes = s.GetClientes();
                    foreach (Cliente c in clientes)
                    {
                        Console.WriteLine(c.Nombre);
                    }
                }
                else if (op == 2)
                {
                    ////Aqui podemos usar otro WHILE para un menu con las categorias y ya cuando uno seleccione la categoria que te salga la lista con los articulos de dicha categoria.
                }
                else if (op == 3)
                {
                    ////No nos olvidemos de las excepciones aqui.

                    Console.WriteLine("Alta de Articulos");
                    Console.WriteLine("Ingrese el nombre");
                    string nombre = Console.ReadLine();
                    ////Es probable que las categorias sean a seleccion 
                    Console.WriteLine("Ingrese la categoria");
                    string categoria = Console.ReadLine();
                    Console.WriteLine("Ingrese el precio");
                    double precio = double.Parse(Console.ReadLine());

                    Articulo nuevo = new Articulo(nombre, categoria, precio);
                }
                else if (op == 4)
                {

                }
            }
            Console.ReadKey();
        }
    }
}
