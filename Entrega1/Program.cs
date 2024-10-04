using Entrega1.Clases.Publicacion;
using Entrega1.Clases.Usuarios;

namespace Entrega1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Sistema s = Sistema.GetInstancia();


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
                        Console.WriteLine(c);
                    }
                }
                else if (op == 2)
                {
                    ////Aqui podemos usar otro WHILE para un menu con las categorias y ya cuando uno seleccione la categoria que te salga la lista con los articulos de dicha categoria.
                }
                else if (op == 3)
                {
                    ////No nos olvidemos de las excepciones aqui.
                    Console.Clear();
                    Console.WriteLine("Alta de Articulos");
                    Console.WriteLine("Ingrese el nombre");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese la categoria");
                    string categoria = Console.ReadLine();
                    Console.WriteLine("Ingrese el precio");
                    double precio = double.Parse(Console.ReadLine());

                    Articulo nuevo = new Articulo(nombre, categoria, precio);
                    try
                    {
                        s.AltaArticulo(nuevo);
                        Console.WriteLine("Articulo Agregado exitosamente, pulse una tecla para continuar.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"El articulo no se pudo agregar: {ex.Message}, presione una tecla para coninuar");
                    };
                    Console.ReadKey();
                }
                else if (op == 4)
                {

                }
            }
            Console.ReadKey();
        }
    }
}
