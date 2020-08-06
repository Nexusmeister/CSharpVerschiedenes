using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KöniglichesFinanzamt
{
    interface IMethoden
    {
        double GetZuVersteuerndesEinkommen();
        double Steuer();
    }
}
