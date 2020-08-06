using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._4_Nullable_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            int? val1 = null; // Nullable Type von int
            Console.WriteLine("Wert setzen? true/false");
            bool setValue = bool.Parse(Console.ReadLine()); // Value setten lassen ja/nein

            if (setValue == true) //if setValue true ist, dann soll ein Wertv gesetzt werden und in int32 konvertiert werden
            {
                Console.WriteLine("Bitte setze Wert");
                val1 = Convert.ToInt32(Console.ReadLine()); 
                if (val1.HasValue)
                {
                    Console.WriteLine("Der Wert ist {0}", val1.Value); //Ausgabe
                }
                else
                {
                    Console.WriteLine("Kein Wert vorhanden"); // Ansonsten
                    Console.ReadKey();
                }
                Console.ReadKey();

            }
        }
    }
}
