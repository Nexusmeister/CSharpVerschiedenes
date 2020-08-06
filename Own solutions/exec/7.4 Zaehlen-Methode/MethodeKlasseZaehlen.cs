using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._4_Zaehlen_Methode
{
    public class MTZ
    {
        public static int Zaehlen(int wert1)        //Methode die zählt
        {
            do
            {
                if (wert1 % 3 == 0)
                    Console.WriteLine(wert1);       //Wenn der wert durch ´3 teilbar ist, wird diese Zahl ausgegeben
                wert1++;                            //Nach der Ausgabe der Zahl, wird die Var um 1 erhöht
            }
            while (wert1 <= 5000);                    // Bis Variable bei 50 angelangt ist, dann ist die Schleife beendet

            return wert1;                           // Ausgabe der Werte
        }
    }
}
