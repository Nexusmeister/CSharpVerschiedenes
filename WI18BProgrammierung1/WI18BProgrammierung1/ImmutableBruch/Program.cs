using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableBruch
{
    class Program
    {
        static void Main(string[] args)
        {

            Bruch b1 = new Bruch(5, 3);
            Console.WriteLine(b1.ToString());
            Bruch b2 = b1.KehrWert();
            Console.WriteLine(b2.ToString());
            Bruch b3 = b1.Multi(b2);
            Console.WriteLine(b3.ToString());
            Bruch b4 = b2.Negiere();
            Console.WriteLine(b4.ToString());
            Bruch b5 = b3.Kürze();
            Console.WriteLine(b5.ToString());
            Bruch b6 = b1.Add(b5);
            Console.WriteLine(b6.ToString());
            Bruch b7 = new Bruch(2, 2);
            Bruch b8 = b7.Potenz(2);
            Console.WriteLine(b8.ToString());
            Console.WriteLine(b1.Potenz(2).ToString());
            Bruch b9 = b1.Potenz(2);
            double b9Betrag = b9.Betrag();
            Console.WriteLine(b9Betrag);
            Console.WriteLine(b8.Betrag());
            Console.WriteLine(b1.Ordnung(b2));
            Console.WriteLine(b2.Ordnung(b1));




            Console.ReadKey();
        }
    }
}
