using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectZurKlassenVerwaltung
{
    class Zähler
    {
        public static void ZähleBis50 ()
        {
            for (int i = 1; i <= 50; i++) /* Laufvariable (i mit ganzen Zahlen), Laufbedingung 
                                            (i kleiner gleich 50), Variablenveränderung (Erhöhung um 1) */
            {
                if (i == 50)
                {
                    Console.WriteLine(" Fertig.");
                    break;
                }
                if (i % 3 == 0)
                    Console.Write(i + ", ");

            }
           
        }
    }
}
