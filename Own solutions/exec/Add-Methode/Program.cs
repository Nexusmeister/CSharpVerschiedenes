using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._3_Add_Methode
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = Add(2, 3); // Variable initialisiert mithilfe Add-Methode
            Console.WriteLine(sum); //Ausgabe
            Console.ReadKey();
            
        }

        static int Add(int a, int b) // Methode Datentyp int - Zwei Variablen mit int werden verwendet
        {
            return a + b;       // Rückgabe ist die Addition von a und b
        }

     
    }
}
