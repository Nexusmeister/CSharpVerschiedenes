using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1_Invert_Methode
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Robin Kaltenbach";
            string title = "Der Eine";
            string invertedName = Invert(name);
            string invertedTitle = Invert(title);
            Console.WriteLine("Name: {0}; Invertiert: {1}", name, invertedName);
            Console.WriteLine();
            Console.ReadKey();
        }
        static string Invert(string textToInvert)
        {
            char [] theChars = new char[textToInvert.Length];
            for (int var = 1; var <= textToInvert.Length; var++)
                theChars[textToInvert.Length - var] = textToInvert[var - 1];
            return new string(theChars);
        }
    }
}
