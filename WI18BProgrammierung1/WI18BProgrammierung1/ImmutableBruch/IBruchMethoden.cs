using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableBruch
{
    interface IBruchMethoden
    {
        Bruch Add(Bruch b);
        Bruch Sub(Bruch b);
        Bruch Multi(Bruch b);
        Bruch Divi(Bruch b);
        Bruch KehrWert();
        Bruch Negiere();
        Bruch Kürze();
        Bruch Potenz(int p);

    

        bool IsEqual(Bruch b);
        

    }
}
