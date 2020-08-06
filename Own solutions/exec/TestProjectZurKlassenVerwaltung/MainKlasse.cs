using System;
using Divide_Methode;
using Klimaanlagen;

namespace TestProjectZurKlassenVerwaltung
{
    public class MainKlasse
    {
        static void Main(string[] args)
        {

            Console.WriteLine("===========================================================================================");
            Console.WriteLine("Verfügbare Tools: Klimaanlage, Schuhgröße, Kühlschrank, Zählen, " +
                              "Schleife, BMI, StringBuilder, ...");
            Console.WriteLine("Geben Sie die gewünschte Aktion ein!");

            //Eingabeblock
            String eingabe = Console.ReadLine();
            eingabe = eingabe.ToLower();

            //Switchblock mit den verschiedenen Aktionen, die bisher entworfen worden sind
            switch(eingabe)
            {
                case "klimaanlage":
                    int temp = 0;
                    Klimaanlage k1 = new Klimaanlage(temp);
                    // Unterstriche vermeiden -> "Sind hässlich" - P.Mohr :D 
                    int zaehler = 0;
                    do
                    {
                        k1.KlimaanlageRegeln();
                        zaehler++;
                    }
                    while (zaehler <= 2);
                    Console.ReadKey();
                    break;
                case "schuhgröße":
                    SchuhgrößeErmitteln s1 = new SchuhgrößeErmitteln();
                    s1.ErmittleSchuhgröße();
                    break;
                case "kühlschrank":
                    EntscheidungKühlschrank.SchaueKühlschrankDurch();
                    break;
                case "zählen":
                    Zähler.ZähleBis50();
                    break;
                case "schleife":
                    Console.WriteLine("Haha! Das war ein Fehler!");
                    DieDauerschleife.DauerschleifeStarten();
                    break;
                case "array":
                    ArtikelArray.ArtikelArrayAusgeben();
                    break;
                case "bmi":
                    BmiRechner.EingabeDaten();
                    break;
                case "stringbuilder":
                    StringBuilden.BaueEinenString();
                    break;
                case "division":
                    double num1 = Convert.ToDouble(Console.ReadLine());
                    double num2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Das Ergebnis ist: " + DividiereZahlen.Divide(num1, num2));
                    break;
                case "string format":
                    break;
                case "exit":
                    
                    break;
                default:
                    Console.WriteLine("Aktion nicht bekannt!");
                break;
            }
            Console.WriteLine("===========================================================================================");
            Console.ReadKey();
        }
    }
}
