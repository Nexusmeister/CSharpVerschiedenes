using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1_Enumerationen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of a weekday");
            string day = Console.ReadLine();
            Weekday myDay = (Weekday)Enum.Parse(typeof(Weekday), day);
            Console.WriteLine("Der eingegebene Wochentag im Enum-Typ ist {0}", myDay);
            Console.ReadKey();


        }
        enum Weekday //
        {            
            Monday, // Erster Wert ist 0
            Tuesday, // 1
            Wednesday, // 2
            Thursday, // ...
            Friday,
            Saturday,
            Sunday
        }



    }
}
