using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1._1_Enum2
{
    class Program
    {
        static void Main(string[] args)
        {
            WoWVolk meinVolk = WoWVolk.Gnome;

            if (meinVolk == WoWVolk.Gnome)
            {

                Console.WriteLine("Dieses Volk spielt Eddy: {0}", meinVolk);
            }
            else
            {

            }



            Console.WriteLine();

            Console.ReadKey();

        }


        enum WoWVolk
        {
            Menschen,
            Zwerge,
            Gnome,
            Nachtelfen,
            Draenei,
            Worgen,
            Orcs,
            Untote,
            Tauren,
            Trolle,
            Blutelfen,
            Gobline,
            Pandaren
        }
        
    }
}
