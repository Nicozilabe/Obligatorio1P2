namespace Entrega1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario u1 = new Usuario("Alberto","Nissman","anisman@ort.edu.uy","Anhero123");
            Cliente cliente = new Cliente("Sofía","eso","mylittlepony27@yahoo.com","Pinkypie7892",2020202);
            Administrador admin = new Administrador("Furro", "1", "furrogenerico@aol.com", "ContraseniaFurraGenerica2");
            Articulo a1 = new Articulo("Fur suit","Drogas duras",3499);
            Console.WriteLine(u1);
            Console.WriteLine(cliente);
            Console.WriteLine(admin);
            Console.WriteLine(a1);
            Console.ReadKey();
        }
    }
}
