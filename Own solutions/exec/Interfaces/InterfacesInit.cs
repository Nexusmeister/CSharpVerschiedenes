using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IHotDrink // Werden wie Klassen definiert, nur mit Schlüsselwort interface
                        // Interface-Benennungen beginnen immer mit "I"
    {                   
        int Degree { get; set; } // Sind automatisch public in interface - keine Sichtbarkeit angeben
    }

    interface IHasCaffeine
    {
        float Caffeine { get; set; }
    }
    
}
