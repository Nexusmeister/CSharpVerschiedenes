using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapitalberechnung
{
    class Kapitalrechner
    {
        private readonly double zinssatz;
        public double Zinssatz
        {
            get
            {
                return this.zinssatz;
            }
        }

        private double kapital;
        public double Kapital
        {
            get
            {
                return this.kapital;
            }
            set
            {
                kapital = value;
            }
        }

        private readonly int laufzeit;
        public int Laufzeit
        {
            get
            {
                return this.laufzeit;
            }
        }

        public Kapitalrechner(int n)
            :this(n, 1000.0, 5.0)
        {
        }

        public Kapitalrechner(int n, double kapital, double zinssatz)
        {
            this.zinssatz = zinssatz / 100;
            this.kapital = kapital;
        }

       
        public double BerechneKapital(int n)
        {
            n = this.laufzeit;
            if (n < 1)
            {
                return this.kapital;
            }
            

            return BerechneKapital(n - 1) * (1 + this.zinssatz);
        }

        public double RundeEndkapital()
        {
            // Rundung auf 2 Kommastellen -> Währung!
            double gerundetesKapital = Math.Round(this.kapital, 2);
            return gerundetesKapital;
        }
    }
}
