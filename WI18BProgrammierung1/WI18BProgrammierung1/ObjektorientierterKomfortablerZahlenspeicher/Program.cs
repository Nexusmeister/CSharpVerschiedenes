using System;


namespace KomfortablerZahlenspeicher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Komfortabler Zahlenspeicher";
            Zahlenspeicher zs1 = new Zahlenspeicher(5);
            zs1.Hinzufügen(5);
            zs1.Hinzufügen(4);
            zs1.Hinzufügen(4);
            zs1.Hinzufügen(4);
            zs1.Hinzufügen(4);

            Console.Write("Ausgabe des Zahlenspeichers: ");
            Console.WriteLine(zs1.ToString());
            Console.WriteLine("Ist die Zahl 3 im Speicher?");
            Console.WriteLine(zs1.SucheZahl(3));
            Console.WriteLine("Ist die Zahl 4 im Speicher?");
            Console.WriteLine(zs1.SucheZahl(4));

            Console.WriteLine("\nZahlen löschen");
            zs1.LöscheLetzteZahl();
            zs1.LöscheLetzteZahl(6);

            Console.WriteLine();
            Console.WriteLine(zs1.ToString());

            Console.WriteLine("Vergleiche zwei Arrays");
            Console.WriteLine("Ist in Arbeit...");
            Zahlenspeicher zs2 = new Zahlenspeicher(5);
            Zahlenspeicher zs3 = new Zahlenspeicher(5);

            zs2.Hinzufügen(1);
            zs2.Hinzufügen(2);
            zs2.Hinzufügen(3);
            zs2.Hinzufügen(4);

            zs3.Hinzufügen(1);
            zs3.Hinzufügen(2);
            zs3.Hinzufügen(3);
            zs3.Hinzufügen(4);

            

            Console.ReadKey();
        }
    }
}
