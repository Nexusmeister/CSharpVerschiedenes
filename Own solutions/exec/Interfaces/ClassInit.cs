using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Tea : IHotDrink // Sieht gleich aus wie Ableitung einer Klasse -> Interface Eigenschaften/Methoden MÜSSEN zur Verfügung gestellt werden
    {
        public int Degree { get; set; } // Muss public sein -> Interface schreibt das vor
    }

    class Coffee : IHasCaffeine, IHotDrink // Zwei Interfaces für eine Klasse -> Muss alle Attribute beider Interfaces übernehmen
    {
        public int Degree { get; set; } // Alles immer public
        public float Caffeine { get; set; } // Sichtbarkeit immer angeben!
    }

    class Coke : IHasCaffeine
    {
        public float Caffeine { get; set; }
    }
}
