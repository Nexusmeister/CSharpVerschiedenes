using System;
using System.Collections.Generic;
using System.Text;

namespace MySolution.Methoden
{
    class SchuhgrößenErmittlung
    {
        public SchuhgrößenErmittlung()
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
