using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide_Methode
{
    public class DividiereZahlen
    {
        public static double Divide(double a, double b)
        {
            double result;
            if (b == 0.0)
            {
                result = 0.0;
                return result;

            }
            else
            {
                result = a / b;
                return result;
            }
        }
    }
}
