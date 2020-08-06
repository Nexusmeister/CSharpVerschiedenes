using System;
using System.Collections.Generic;
using System.Text;

namespace MySolution.Methoden.Rechner.MathematischeOperatoren
{
    class Division
    {
        public static void GebeDivisionsDatenEin()
        {
            Console.Write("Geben Sie Zahl 1 ein: ");
            double num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Geben Sie Zahl 2 ein: ");
            double num2 = Convert.ToInt32(Console.ReadLine());

            double ergebnis = Dividiere(num1, num2);
            Console.WriteLine("Das Ergebnis ist: " + ergebnis);
        }

        private static double Dividiere(double num1, double num2)
        {
            if (num2 == 0)
            {
                Console.WriteLine("Keine Division durch 0 ausführbar.");
                Console.WriteLine("Geben Sie erneut Ihre Daten ein.");
                GebeDivisionsDatenEin();
                return 0;
            } 
          
              double ergebnis = num1 / num2;
                
            

            return ergebnis;

        }
    }
}
