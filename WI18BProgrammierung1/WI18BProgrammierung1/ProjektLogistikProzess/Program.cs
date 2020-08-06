using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProzessLernen
{
    class Program
    {
        static void Main(string[] args)
        {

           

            try
            {
                var txt = System.IO.File.ReadAllText("C:\\Text.txt");
                Console.WriteLine("TEXT: ");
                Console.WriteLine(txt);
            }
            catch (Exception e1)
            {
                Console.WriteLine("FEHLER");
                Console.WriteLine(e1.Message);
            }
            Console.ReadKey();

            string input = Console.ReadLine();
            DateiZugriff.SchreibeDatei(input);
            var zusätzlicherInput = Console.ReadLine();
            DateiZugriff.SchreibeDateiWeiter(zusätzlicherInput);
            FileInfo myInfo = new System.IO.FileInfo("D:\\Test.txt");
            DateiZugriff.GebeLaufwerkeAus();
            Console.ReadKey();
            File.Delete(@"D:\\Test.txt");

            Beförderungsmittel.Lagerhilfsmittel lhm1 = new Beförderungsmittel.Lagerhilfsmittel();

            
            string buffer = null;
            foreach (var artikel in Enum.GetNames(typeof(Artikel.EnumArtikel)))
            {
                buffer += artikel + ", "; 
               
            }
            Console.WriteLine(buffer);

            
            Artikel.ArtikelAufLager art1 = new Artikel.ArtikelAufLager(Artikel.EnumArtikel.Bolzen.ToString(), 10000, 680.0);
            Console.WriteLine("{0}, {1}, {2}", art1.GewichtInKG, art1.ArtikelID, art1.Artikelbeschreibung);
            //Console.WriteLine(art1.GetTypeOfBeförderungsmittel());

            Test v1 = new Test
            {
                X = 1,
                Y = 2,
                Z = 3

            };
            
             
            Console.ReadKey();
        }
    }
}
