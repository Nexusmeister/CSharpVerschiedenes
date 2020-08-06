using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1_Funktionen
{
    class Program
    {
        static void Main(string[] args)
        {
            string text1 = "C-Teile. Yikes ";
            char zeichen1 = text1[4];       // 5. Zeichen -> i
            byte zahl1 = (byte)zeichen1;    // 105
                Console.WriteLine(zahl1);
                Console.ReadKey();

            int len = text1.Length; //Anzahl der Zeichen eines Textes wird ermittelt
            int indexOfYikes = text1.IndexOf("Yikes"); // Ermittlung des Index vom ersten Vorkommen
            string[] words = text1.Split(' '); // Mithilfe eines angegebenen Trennzeichens wird ein Text zerlegt
            string lowerText = text1.ToLower(); // Nur Kleinbuchstaben
            string upperText = text1.ToUpper(); // Nur Großnuchstaben
            string noWhitespace = text1.Trim(); // Leerzeichen vor und nach dem Text werden entfernt
            bool containsText = String.IsNullOrEmpty(text1); // Hat String einen Wert

            Console.WriteLine();
                Console.ReadKey();
        }
    }
}
