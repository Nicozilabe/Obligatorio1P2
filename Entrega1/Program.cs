namespace Entrega1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Usuario u1 = new Usuario("Alberto", "Nissman", "anisman@ort.edu.uy", "Anhero123");

            //Cliente cli1 = new Cliente("Sofía", "eso", "mylittlepony27@yahoo.com", "Pinkypie7892", 2020202);

            //Administrador admin = new Administrador("Furro", "1", "furrogenerico@aol.com", "ContraseniaFurraGenerica2");

            //Articulo a1 = new Articulo("Fur suit", "Drogas duras", 3499);

            //Publicacion pub1 = new Publicacion("verano", "abierta", DateTime.Parse("10/10/2000"), cli1, true, cli1, DateTime.Parse("10/3/2020"));

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

            Console.ReadKey();
        }
    }
}
