using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2_Mehrdimensionales_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            String[,] wisArtikel2 = new String[, ] {
                { "Vierkantschraube", "Sechskantschraube" }, 
                { "Mutter", "Unterlegscheibe"}, 
                { "Bolzen", "Kabelbinder" }, 
                { "Handschuhe" , "Teppichmesser" } }; // Initialisierung 2D-Array
            Console.WriteLine(wisArtikel2[0,0]); // Es wird mit 0 angefangen zu zählen
            Console.WriteLine(wisArtikel2[2, 1]); // Ausgabe von der 3. Klammer, der zweite Eintrag 

            foreach (String artikel in wisArtikel2)
            {
                Console.WriteLine(artikel);
            }

            Console.ReadKey();
        }
    }
}
    