using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medikamentenmenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Medikamentenmenge berechnen";
            Console.Write("Geben Sie die Tage ein, die vergangen sind, seit der ersten Einnahme: ");
            int verstricheneTage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Restliche Menge im Blut nach {0} Tagen: {1}mg", verstricheneTage, Methoden.Runden(verstricheneTage));
            Console.ReadKey();
        }

       

       
        
    }
}
