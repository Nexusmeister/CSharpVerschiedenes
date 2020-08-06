using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medikamentenmenge
{
    class Methoden
    {
        private static double Medikamentenmenge(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            return (Medikamentenmenge(n - 1)) * 0.6 + 5;
        }

        public static double Runden(int tage)
        {
            double restemenge = Medikamentenmenge(tage);
            double gerundeteRestMenge = Math.Round(restemenge, 3);
            Console.WriteLine("{0}", gerundeteRestMenge);
            return gerundeteRestMenge;
        }
    }
}
