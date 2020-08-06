using System;
using System.Collections.Generic;
using System.Text;

namespace MySolution.Methoden
{
    class DieDauerschleife
    {
        public static void starteDauerschleife()
        {
            int n = 1;
            while (true) //Prüfung ist durch true immer erfüllt 
            {
                Console.WriteLine("Das ist dein {0}. Fehler!", n);
                
                n++; // Erhöhung um 1 der Variablen                     

            }
        }
    }
}
