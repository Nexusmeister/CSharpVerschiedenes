using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sternenpyramide
{
    class Programm
    {

        public static void Main(String[] args)

        {
            Console.WriteLine("==============================================================================================================");
            Console.WriteLine("\t \t Programm zur Bildung einer Sternenpyramide!");

            Pyramide1 p1 = ErzeugePyramidenObjekt();


            Console.WriteLine("Beenden Sie das Programm durch Drücken einer beliebigen Taste...");
            Console.ReadKey();
        }

        public static Pyramide1 ErzeugePyramidenObjekt()
        {
            Console.Write("Geben Sie die Anzahl der gewünschten Zeilen der Pyramide an: ");
            int zeilen = Convert.ToInt32(Console.ReadLine());
            return new Pyramide1(zeilen);
        }
    }
}
