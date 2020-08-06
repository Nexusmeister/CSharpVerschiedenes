using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KöniglichesFinanzamt
{
    abstract class Einwohner : IMethoden
    {
        private string name;
        private double einkommen;
        public double Einkommen
        {
            get
            {
                return this.einkommen;
            }
            set
            {
                this.einkommen = value;
            }
        }

        public Einwohner(string name, double einkommen)
        {
            this.name = name;
            this.einkommen = einkommen;
        }

        public double GetZuVersteuerndesEinkommen()
        {
            return this.einkommen;
        }

        public double Steuer()
        {
            double steuerBasis = this.einkommen;
            double zuZahlendenSteuer = this.einkommen * 0.1;
            return zuZahlendenSteuer;
        }
    }
}
