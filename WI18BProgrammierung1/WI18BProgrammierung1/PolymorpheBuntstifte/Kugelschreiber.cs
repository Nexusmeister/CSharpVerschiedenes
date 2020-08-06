using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorpheBuntstifte
{
    class Kugelschreiber : Stift
    {
        private new readonly string farbe = "blau";

        public Kugelschreiber()
        {
            base.farbe = farbe;
        }
    }
}
