using System;
using System.Text;


namespace MySolution
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===========================================================================================");

            HauptmenüAnzeigen();
            
            Console.WriteLine("===========================================================================================");

            Console.ReadKey();
        }

        public static void HauptmenüAnzeigen()
        {
            Console.WriteLine("Verfügbare Tools: Klimaanlage, Schuhgröße, Kühlschrank, Zählen, " +
                              "Schleife, BMI, StringBuilder, Array, Rechner, " +
                              " ...");
            Console.WriteLine("Geben Sie die gewünschte Aktion ein!");

            //Eingabeblock
            String eingabe = Console.ReadLine();
            eingabe = eingabe.ToLower();

            //Switchblock mit den verschiedenen Aktionen, die bisher entworfen worden sind
            switch (eingabe)
            {
                case "schuhgröße":
                    Methoden.SchuhgrößenErmittlung schuh1 = new Methoden.SchuhgrößenErmittlung();
                    schuh1.ErmittleSchuhgröße();
                    break;
                case "zählen":
                    Methoden.KlasseZählen.ZähleBis50();
                    break;
                case "klimaanlage":
                    int temp = 0;
                    Klassen.Klimaanlage k1 = new Klassen.Klimaanlage(temp);
                    // Unterstriche vermeiden -> "Sind hässlich" - P.Mohr :D 
                    int zaehler = 0;
                    do
                    {
                        k1.KlimaanlageRegeln();
                        zaehler++;
                    }
                    while (zaehler <= 2);
                    break;
                case "kühlschrank":
                    Methoden.KühlschrankEntscheidung.SchaueKühlschrankDurch();
                    break;
                case "schleife":
                    Console.WriteLine("Haha! Das war ein Fehler!");
                    Methoden.DieDauerschleife.starteDauerschleife();
                    break;
                case "array":
                    Methoden.ArtikelArray.GebeArrayAus();
                    break;
                case "bmi":
                    Methoden.BmiRechner.GebeDatenEin();
                    break;
                case "stringbuilder":
                    Methoden.StringBuildern.BuildeEinenString();
                    break;
                case "rechner":
                    Methoden.Rechner.MathematischeOperatoren.OberklasseMathematik.LeiteMathematischerRechnerEin();
                    break;
            }
        }
    }
}
