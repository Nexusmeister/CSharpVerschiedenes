using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide_Methode
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Zahl 1");
            int num1 = Convert.ToInt32(Console.ReadLine());  // string to int

            Console.WriteLine("Zahl 1");
            int num2 = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine(DividiereZahlen.Divide(num1, num2)); // Methodenaufruf

            

            Console.ReadKey();
        }
        
    }
}
