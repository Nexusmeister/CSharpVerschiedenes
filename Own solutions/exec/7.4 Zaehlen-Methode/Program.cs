using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._4_Zaehlen_Methode
{
    class Program
    {
        static void Main(string[] args)
        {
            var wert2 = 0;            // Variable intitialisiert und den Wert 0 vergeben           
            var sum = MTZ.Zaehlen(wert2); /* Methode zaehlen aus Klasse MTZ wird aufgerufen, 
                                            wert2 wird in die Methode geworfen */

            Console.ReadKey();
        }
       
    }
}  