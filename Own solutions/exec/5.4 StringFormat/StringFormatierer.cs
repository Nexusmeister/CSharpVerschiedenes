using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFormat

{
    class StringFormatierer
    {
        public static void StringFormatieren()
        {
            string text1 = "Hello World!";
            int len = text1.Length; // Zeichenzahl Hello World
            string[] words = text1.Split(' ');
            string text2 = string.Format("Die Länge: {0}. Anzahl der Wörter: {1}", len, words.Length); // Array intitialisiert

            Console.WriteLine(text2);
            Console.ReadKey();

            string a = String.Format("{0} {1} {2} {0}", "!", "Hallo", "Schrödinger");
            Console.WriteLine(a);
            Console.ReadKey();

            string b = String.Format("{1} {2} {3} {4} {0}", "!", "Gimme", "that", "freakin'", "Soda");
            Console.WriteLine(b);
            Console.ReadKey();
        }
    }
}
