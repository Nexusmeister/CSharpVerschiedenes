using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLineUndWriteLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geb deine Fußlänge in cm ein!");
            float fusslaenge = Console.Read();

            double fma = fusslaenge + 1.5;
            double shoesize = fma * 1.5;

            Console.WriteLine("Deine Schugröße ist " + shoesize);
        }
    }
}
