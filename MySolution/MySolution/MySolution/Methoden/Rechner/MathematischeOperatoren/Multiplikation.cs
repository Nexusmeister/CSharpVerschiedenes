using System;
using System.Collections.Generic;
using System.Text;

namespace MySolution.Methoden.Rechner.MathematischeOperatoren
{
    class Multiplikation
    {
        public static void StarteMultiplikation()
        {
            double num1 = Hilfsmethoden.Dateneingabe.GebeZahlEin();
            double num2 = Hilfsmethoden.Dateneingabe.GebeZahlEin();
            double ergebnis = Multipliziere(num1, num2);

            Console.WriteLine("Das Ergebnis ist: " + ergebnis);
        }
       
        public static double Multipliziere(double a, double b)
        {

            return a * b;
        }
    }
}
