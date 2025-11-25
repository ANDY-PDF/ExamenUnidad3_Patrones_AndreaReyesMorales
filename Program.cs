using System;

namespace AppLectura
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = " Aplicación de Lectura con Marcadores Inteligentes";

            Reading app = new Reading();
            app.Run();
        }
    }
}
