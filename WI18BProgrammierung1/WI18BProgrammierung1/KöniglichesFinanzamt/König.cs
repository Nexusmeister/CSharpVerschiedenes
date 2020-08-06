using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KöniglichesFinanzamt
{
    class König : Einwohner
    {

        public König(string name, double einkommen)
            : base(name, einkommen)
        {
            
        }

        //Override von Oberklassenfunktion
        public new double Steuer()
        {
            return 1;
        }
    }
}
