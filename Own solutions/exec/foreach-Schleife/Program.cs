using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foreach_Schleife
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] artikel1 = new string[] { "Schraube", "Mutter", "Scheibe" };
            foreach (string artikel in artikel1) // Die Laufvariable artikel druchläuft das array artikel1
            {
                Console.WriteLine(artikel);     // Und wird ausgegeben        
            }
            Console.ReadKey();
        }
    }
}
