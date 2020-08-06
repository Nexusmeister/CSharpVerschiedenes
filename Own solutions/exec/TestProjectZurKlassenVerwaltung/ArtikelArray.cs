using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectZurKlassenVerwaltung
{
    class ArtikelArray
    {
        public static void ArtikelArrayAusgeben()
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

            String[,] wisArtikel2 = new String[,] { { "Vierkantschraube", "Sechskantschraube" }, { "Mutter", "Unterlegscheibe"
                }, { "Bolzen", "Kabelbinder" }, { "Handschuhe" , "Teppichmesser" } }; // Initialisierung 2D-Array
            Console.WriteLine(wisArtikel2[0, 0]); // Es wird mit 0 angefangen zu zählen
            Console.WriteLine(wisArtikel2[2, 1]); // Ausgabe von der 3. Klammer, der zweite Eintrag 

            foreach (String artikel in wisArtikel2)
            {
                Console.WriteLine(artikel);
            }

            Console.ReadKey();

        }
    }
}
