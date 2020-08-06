using System;
using System.Collections.Generic;
using System.Text;

namespace MySolution.Methoden.Rechner
{
    class OberklasseRechner
    {
        public static void LeiteRechnerEin()
        {
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("<----- Rechner ----->");
            Console.WriteLine("Funktionen: Grundrechenarten, Umrechner, Zinsrechner, ...");

            EntscheideÜberOperation();
        }
        public static void EntscheideÜberOperation()
        {

            Console.Write("Geben Sie die gewünschte Operation ein: ");
            String entscheidung = Console.ReadLine();
            entscheidung = entscheidung.ToLower();

            switch (entscheidung)
            {
                case "grundrechenarten":
                    MathematischeOperatoren.OberklasseMathematik.LeiteMathematischerRechnerEin();
                    break;
                case "umrechner":
                    
                    break;
                case "zinsrechner":
                    
                    break;          
                default:
                    Console.WriteLine("Aktion unbekannt. Erneute Eingabe erforderlich.");
                    EntscheideÜberOperation();
                    break;
            }
        }


    }
}
