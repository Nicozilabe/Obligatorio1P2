using System.Text.RegularExpressions;
using System.Text;
using Entrega1.Clases.Publicacion;
using Entrega1;
using Entrega1.Clases.Usuarios;
using System.Reflection.Metadata;

namespace UiConsola
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
                Console.WriteLine("3 - ¡Alta de articulo!");
                Console.WriteLine("4 - Encuentre Publicaciones por fechas dadas");
                Console.WriteLine("0 - Salir");

                try
                {
                    op = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error : {e.Message}, presione una tecla para volver a intentar.");
                    Console.ReadKey();
                }

                if (op == 1)
                {
                    Console.Clear();

                    List<Cliente> clientes = s.GetClientes();
                    if (clientes.Count > 0)
                    {
                        Console.WriteLine("Lista clientes:");
                        Console.WriteLine("----- Inicio -----");
                        foreach (Cliente c in clientes)
                        {
                            Console.WriteLine(c);
                        }
                        Console.WriteLine("------ Fin ------");
                    }
                    else
                    {
                        Console.WriteLine("Lista de clientes vacía.");
                    }
                    Console.WriteLine("Presione una tecla para volver al menú.");
                    Console.ReadKey();
                }
                else if (op == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Búsqueda de articulos por categoria. \n");
                    Console.WriteLine("Ingrese categoría. \n");

                    List<Articulo> articulos = new List<Articulo>();
                    try
                    {

                        string c = Regex.Replace(Console.ReadLine().Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
                        if (string.IsNullOrEmpty(c))
                        {
                            throw new Exception("Categoría no válida");
                        }
                        else
                        {
                            articulos = s.BuscarPorCategoria(c);
                        }
                        if (articulos.Count != 0)
                        {
                            Console.WriteLine("Articulos");
                            Console.WriteLine("----- Inicio -----");
                            foreach (Articulo a in articulos)
                            {
                                Console.WriteLine(a);
                            }
                            Console.WriteLine("------ Fin ------");
                        }
                        else
                        {
                            Console.WriteLine("No hay articulos con esa categoría.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error {ex.Message}.");
                    }
                    Console.WriteLine("Presione una tecla cualquiera para volver al menú.");
                    Console.ReadKey();
                }
                else if (op == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Alta de Articulos");
                    try
                    {
                        Console.WriteLine("Ingrese el nombre.");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese la categoria.");
                        string categoria = Console.ReadLine();
                        Console.WriteLine("Ingrese el precio.");
                        double precio = double.Parse(Console.ReadLine());
                        string error = "";
                        if (Double.IsNaN(precio) || (precio <= 0))
                        {
                            error += "Precio no valido,";
                        }
                        if (string.IsNullOrEmpty(nombre))
                        {
                            error += " Nombre no valido,";
                        }
                        if (string.IsNullOrEmpty(categoria))
                        {
                            error += " Categoria no válida";
                        }

                        if (error == "")
                        {
                            Articulo nuevo = new Articulo(nombre, categoria, precio);

                            s.AltaArticulo(nuevo);
                            Console.WriteLine("Articulo Agregado exitosamente. Pulse una tecla cualquiera para volver al menú.");
                        }
                        else
                        {
                            throw new Exception(error);
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"El articulo no se pudo agregar: {ex.Message}. Presione una tecla cualuiera para volver al menú.");
                    }
                    Console.ReadKey();
                }
                else if (op == 4)
                {
                    Console.Clear();
                    try
                    {
                        Console.WriteLine("Ingrese fecha inicio busqueda (DD-MM-AAAA):");
                        DateTime inicio = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("\nIngrese fecha fin busqueda (DD-MM-AAAA):");
                        DateTime fin = DateTime.Parse(Console.ReadLine());
                        //No consideramos necesaria más validacion de la que realiza el parce tirando error si no es correcto el input
                        List<Publicacion> publicaciones = new List<Publicacion>();
                        string errores = "";
                        if (inicio > DateTime.Now)
                        {
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
                        if (errores == "")
                        {
                            publicaciones = s.GetPublicacionesPorFecha(inicio, fin);
                            ;
                            if (publicaciones.Count != 0)
                            {
                                Console.WriteLine("Publicaciónes");
                                Console.WriteLine("----- Inicio -----");
                                foreach (Publicacion p in publicaciones)
                                {
                                    Console.WriteLine(p);
                                }
                                Console.WriteLine("\n------ Fin ------");
                            }
                            else
                            {
                                Console.WriteLine("No hay publicaciones entre esas fechas");
                            }
                        }
                        else
                        {
                            throw new Exception(errores);
                        }
                    }
                    catch (Exception ex) { Console.WriteLine($"Error {ex.Message}."); }
                    Console.WriteLine("Presione una tecla cualquiera para volver al menú");
                    Console.ReadKey();
                }
            }
            
        }
    }

}
