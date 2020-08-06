using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProzessLernen.Beförderungsmittel
{
    class Lagerhilfsmittel : Fördermittel
    {
        private long lhmNr;
        public long LhmNr {
            get
            {
                return this.lhmNr;
            }
        }

        // 02.01.19 Zufällige Zahl für LHM -> damit sie größer ist, nochmals mit einer random Zahl multipliziert
        public Lagerhilfsmittel()
        {
            this.lhmNr = rand.Next(1,100) * rand.Next(1,100);
        }





        //02.01.19 Nötig für lhmNr
        Random rand = new Random();
    }
}
