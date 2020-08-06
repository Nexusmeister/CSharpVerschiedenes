using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.for_Schleife
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 50; i++) /* Laufvariable (i mit ganzen Zahlen), Laufbedingung 
                                            (i kleiner gleich 50), Variablenveränderung (Erhöhung um 1) */
            {
                if (i % 3 == 0)
                    Console.WriteLine(i + ", ");
                
            }
            Console.ReadKey();
        }
       
    }
}
