using System;
using System.Collections.Generic;
using System.Text;

namespace MySolution.Methoden.Rechner.MathematischeOperatoren
{
    class OberklasseMathematik
    {
        public static void LeiteMathematischerRechnerEin()
        {
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine("<----- Rechner ----->");
            Console.WriteLine("Funktionen: Addition, Subtraktion, Multiplikation, Division.");

            EntscheideÜberOperation();
        }
       public static void EntscheideÜberOperation ()
       {
           
            Console.Write("Geben Sie die gewünschte Operation ein: ");
            String entscheidung = Console.ReadLine();
            entscheidung = entscheidung.ToLower();

            switch(entscheidung)
            {
                case "addition":
                    Addieren.StarteAddition();
                    break;
                case "subtraktion":
                    Subtraktion.GebeSubtraktionsDatenEin();
                    break;
                case "division":
                    Division.GebeDivisionsDatenEin();
                    break;
                case "multiplikation":
                    Console.WriteLine("Nothing here.");
                    break;
                default:
                    Console.WriteLine("Aktion unbekannt. Erneute Eingabe erforderlich.");
                    EntscheideÜberOperation();
                    break;
            }
           
       }
    }
}
