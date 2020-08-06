using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2_Referenz_Methode
{
    class Program
    {
        static void Main(string[] args)
        {
            double var1 = 2.5;
            var var2 = 5.9;
            Swap(ref var1, ref var2); // ref in Parameter übergibt Änderung des Variablenwertes
            Console.WriteLine("Variable 1: {0}; Variable 2: {1}", var1, var2);
            Console.ReadKey();
        }           
        static void Swap(ref double a, ref double b) // Swap Methode - Kein Rückgabewert, deswegen kein Datentyp
        {
            double temp = a;
            a = b;
            b = temp;
        }
    }
}
