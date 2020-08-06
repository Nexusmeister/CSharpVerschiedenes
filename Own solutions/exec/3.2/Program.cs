using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2
{
    class Program
    {
        static void Main(string[] args)
        {
           var num1 = 50;
            do
            {
                if (num1 % 3 == 0) // Bedingung, dass Variable durch 3 teilbar sein soll.
                    Console.Write(num1 + ", ");
                num1--; // Variable um 1 senken
            }
            while (num1 >= 0); // Prüfung - Solange Variable kleiner 50 ist (Hier Prüfung erst am Ende!)
            Console.WriteLine(" ");

            var num2 = 0;
            do
            {
                if (num2 % 3 == 0) // Bedingung, dass Variable durch 3 teilbar sein soll.
                    Console.Write(num2 + ", ");
                num2++; // Variable um 1 erhöhen
            }
            while (num2 <= 50); // Prüfung - Solange Variable kleiner 50 ist (Hier Prüfung erst am Ende!)
            Console.ReadKey();

            var wert2 = 0;
            
            Console.WriteLine(" ");
            var sum = zaehlen(wert2);
            Console.ReadKey();
        }
        static int zaehlen(int wert1) //Methode die zählt
        {
            do
            {
                if (wert1 % 3 == 0)
                    Console.Write(wert1 + ", ");        //Wenn der wert durch ´3 teilbar ist, wird diese Zahl ausgegeben
                wert1++; //Nach der Ausgabe der Zahl, wird die Var um 1 erhöht
            }
            while (wert1 <= 50); // Bis Variable bei 50 angelangt ist, dann ist die Schleife beendet

            return wert1; // Ausgabe der Werte
        }
    }
}
