using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectZurKlassenVerwaltung
{
    class SchuhgrößeErmitteln
    {
        public SchuhgrößeErmitteln()
        {

        }

        public void ErmittleSchuhgröße()
        {
            Console.WriteLine("Geb deine Fußlänge in cm ein!");
            float fusslaenge = Console.Read();

            double fma = fusslaenge + 1.5;
            double shoesize = fma * 1.5;

            Console.WriteLine("Deine Schugröße ist " + shoesize);

            Console.Read();
        }
    }
}
