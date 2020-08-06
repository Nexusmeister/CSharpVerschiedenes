using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schachbrett
{
    class Schachbrett1
    {
        public Schachbrett1()
        {
            Console.WriteLine("Erzeuge Schachbrettfeld...");
        }

        public void ErzeugeSchachbrettFeld()
        {
            for(int i = 1; i <= 10; i++)
            {
                for(int y = 0+i; y <= i+10; y++)
                {
                    if (y < 10)
                    {
                        Console.Write(y + "  ");
                    } else
                    {
                        Console.Write(y + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
