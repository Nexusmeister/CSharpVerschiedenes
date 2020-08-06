using System;


namespace ZahlenErraten
{
    class Program
    {
        private static int zahl1;

        static void Main(string[] args)
        {

            
            RateZahl(); //Methodenaufruf
            Console.Read();
        }

        public static void RateZahl()
        {
            Console.WriteLine("Gebe eine Zahl ein. Wirst du die richtige erraten?");
            
            int richtigeZahl = 12; // Zahl, die zu erraten ist

            
            do
            {
                int zahl1 = Console.Read(); // Zahl einlesen, die der User probiert
                if (zahl1 == richtigeZahl)
                {
                    Console.WriteLine("Super! Du hast die Zahl erraten!");
                }
                else if (zahl1 > richtigeZahl)
                {
                    Console.WriteLine("Zu groß!");
                }
                else
                {
                    Console.WriteLine("Zu klein!");
                }
            }
            while (zahl1 != richtigeZahl);

            /* Problem: Zahl wird nicht mehr neu in der Schleife abgefragt und arbeitet immer mit der
             * selben Zahl. Somit bleibt das Ergebnis gleich und die Lösung kann nicht erraten werden,
             da eine Endlosschleife entsteht und man nicht mehr aus der Schleife kommt. */
        }
    }
}
