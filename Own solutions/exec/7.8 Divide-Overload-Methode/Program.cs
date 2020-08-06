using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._6._2_Divide_Overload_Methode
{
    class Program
    {
        static void Main(string[] args)
        {
            var var1 = 5;
            byte var2 = 3;
            var var3 = 1.1;
            double var4 = 2.2654;
            
            
          
            Console.WriteLine(Divide(var1, var2));
            Console.WriteLine(Divide(var2, var4));
            Console.WriteLine(Divide(var3, var4));
            Console.WriteLine(Divide()); // Keine Parameter aufgerufen -> Standardwerte werden aufgerufen
            Console.ReadKey();




        }

        static double Divide(double a = 2, double b = 2) // MEthodenkopf mit Standardwerten versehen
        {
           double result = (a / b);
            return result;                          //Rückgabe
           
        }
    }
}
