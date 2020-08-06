using System;
using System.Collections.Generic;
using System.Text;

namespace MySolution.Methoden
{
    class StringBuildern
    {
        public static void BuildeEinenString()
        {
            Console.WriteLine("Füge einige Wörter ein!");
            var word1 = Console.ReadLine() + " ";
            var word2 = Console.ReadLine() + " ";
            var word3 = Console.ReadLine() + " ";
            var word4 = Console.ReadLine() + " ";
            var word5 = Console.ReadLine() + " ";
            var word6 = Console.ReadLine() + " ";

            string[] words = { word1, word2, word3, word4, word5, word6 }; //Array
            StringBuilder sb1 = new StringBuilder(); // Ein Objekt des StringBuilder wird erzeugt
            for (int i = 0; i < words.Length; i++) // So lange i kleiner ist, als die Arraylänge, erhöhe i um 1
                sb1.Append(words[i]); // StringBuilder nimmt words und ruft sie alle nacheinander auf
                                      // Kopien der Wörter sind nun in sb1 gespeichert

            Console.WriteLine("Baue einen String...");
            Console.WriteLine(sb1.ToString()); //sb1 wird zu einem String umgewandelt
        }
    }
}
