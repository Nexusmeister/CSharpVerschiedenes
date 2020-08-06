using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._6._1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Zahl 1");
            int num1 = Convert.ToInt32(Console.ReadLine());  // string to int

            Console.WriteLine("Zahl 1");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Divide(num1, num2, out double result)); // Methodenaufruf



            Console.ReadKey();
        }
        static bool Divide(double a, double b, out double result)
        {
            
            if (b == 0.0)
            {
                result = 0.0;
                return false;

            }
            else
            {
                result = a / b;
                return true;
            }
        }
    }
}
        
