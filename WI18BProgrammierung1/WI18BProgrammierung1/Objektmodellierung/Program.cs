using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objektmodellierung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Objektmodellierung";
                
                
                
            
            Console.WriteLine("MODELLIERUNG EINES BANKKONTOS");
            Bankkonto b1 = new Bankkonto(122.55, "GENODE81WTH");
            Console.WriteLine("Konto b1: " + b1.GetKontoNr() + ": " + b1.GetKontostand());
            
            b1.SetKontostand(250);
            Console.WriteLine(b1.GetKontostand());
            b1.SetKontostand(-55);
            Console.WriteLine(b1.GetKontostand());

            Bankkonto b2 = new Bankkonto();
            Console.WriteLine(b2.GetKontoNr());
            Bankkonto b3 = new Bankkonto(250);
            Console.WriteLine(b3.GetKontoNr() + ": " + b3.GetKontostand() );
            Console.WriteLine("=============================================================");
            Console.WriteLine("\n ");
            Console.WriteLine("MODELLIERUNG VON STUDENTEN");

            Student s1 = new Student("Robin Kaltenbach", Studienfach.WIRTSCHAFTSINFORMATIK);
            Console.WriteLine(s1.MatrikelNr + ": " + s1.Studienfach);
            Student s2 = new Student("Hans Franz", Studienfach.MASCHINENBAU);
            Console.WriteLine(s2.MatrikelNr + ": " + s2.Studienfach);

            Console.ReadKey();
        }
    }
}
