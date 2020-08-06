using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorpheBuntstifte
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Polymorphe Stifte";
            Stift s1 = new Kugelschreiber();
            Stift s2 = new Buntstift("grün");
            //Stift s3 = new Stift("rot"); FEHLER: Abstrakte Klassen können nicht instanziiert werden

            Schreiben(s1);
            Schreiben(s2);

            Console.ReadKey();

        }

        public static void Schreiben(Stift s)
        {
            Console.WriteLine("Farbe des Stifts: {0} ", s.Farbe);
        }
    }
}
