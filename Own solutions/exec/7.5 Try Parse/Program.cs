using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._5_Try_Parse
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            if (int.TryParse("2", out number))
            {
                
                Console.WriteLine("Parse hat funktioniert");
            }
            else
            {
                Console.WriteLine("No valid number.");
            }
            Console.ReadKey();
        }

        
    }
}
