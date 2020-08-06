using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    class ShapeFactory
    {
        public static Shape GetShape() // Statische Methode gibt in der Signatur Shape zurück
        {
            return new Square(); // Square wird ausgegeben
        }

        
    }
}
