namespace POO_Proyecto_Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instancio un nuevo objeto de la clase Druida
            Druida D = new Druida("Arwen", 3);

            Console.WriteLine(D.MostrarPersonaje());

            //-----------------------

            Console.WriteLine("Ingrese el animal en el que se transforma el Druida: ");
            string FormaSalvaje = Console.ReadLine();
            Console.WriteLine(D.Transformarse(FormaSalvaje));

            Console.WriteLine("---------------------------------------");

            Console.WriteLine(D.MostrarPersonaje());


        }
    }
}
