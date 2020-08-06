using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wisArtikel = new string[] { "Schraube", "Mutter", "Scheibe", "Gewindestange", "Kabelbinder" }; 
                                                /* Initialisierung eines Arrays
                                               Datentyp [] Variablenname = Wertzuweisungen der Variablen*/                                                                                                                   
                     // ODER

            string[] mehrArtikel = new string[2]; // Anzahl der Wertzuweisungen festlegen
            mehrArtikel[0] = "Sechskantschraube"; // Schraube ist abrufbar durch Nr. 0
            mehrArtikel[1] = "Sicherheitsschuhe"; 

            Console.WriteLine(mehrArtikel[0]);    // Aufruf des ersten Artikels in Array mehrArtikel

            foreach (string artikel in wisArtikel)
            {
                Console.WriteLine(artikel);
            }
            Console.ReadKey();

            for (int i = 0; i < wisArtikel.Length; i++)  // Schleife durchläuft alle Einträge des Arrays wisArtikel
            {
                var element = wisArtikel[i];
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
