using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schachbrett
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Schachbrett";
            Console.WriteLine("==============================================================================================================");
            Console.WriteLine("\t \t Programm zur Bildung eines Schachbretts! \n ");
            Schachbrett1 s1 = new Schachbrett1();

            s1.ErzeugeSchachbrettFeld();
            

            Console.ReadKey();
        }
    }
}
