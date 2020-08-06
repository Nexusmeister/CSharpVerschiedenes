using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProzessLernen.Beförderungsmittel
{
    class Tablar : Fördermittel
    {
        private static long tablarID = 10000000;
        public long TablarID
        {
            get
            {
                return tablarID;
            }
        }
        public Tablar()
        {
            tablarID++;
        }
    }
}
