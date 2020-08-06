using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectZurKlassenVerwaltung
{
    class DieDauerschleife
    {
        public static void DauerschleifeStarten()
        {
            int n = 1;
            while (true) //Prüfung ist durch true immer erfüllt 
            {

                Console.WriteLine("Das war dein {0}. Fehler!", n);
                n++; // Erhöhung um 1 der Variablen                     

            }
        }
    }
}
