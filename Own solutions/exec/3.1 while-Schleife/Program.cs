using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1_while_Schleife
{
    class Program
    {
        static void Main(string[] args)
        {
            int var1 = 1;
            while (var1 <= 50) // Prüfung - Variable ist kleiner gleich 50 (Prüfung am Anfang!)
            {
                if (var1 % 3 == 0) // Bedingung - Variable ist durch 3 teilbar ohne Rest
                    Console.Write(var1 + ", ");
                var1++; // Variable um eins erhöhen
            }
            Console.ReadKey();
        }
    }
}
