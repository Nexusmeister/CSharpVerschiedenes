using System;
using System.Collections.Generic;
using System.Text;

namespace MySolution.Methoden
{
    class KühlschrankEntscheidung
    {
        public static void SchaueKühlschrankDurch()
        {
            Console.WriteLine("Fridge is empty?");
            bool emptyFridge = bool.Parse(Console.ReadLine());
            if (emptyFridge == true)
            {
                Console.WriteLine("Go to Walmart and buy food!");
            }
            else
            {
                Console.WriteLine("You want Pizza (true) or Chicken Nuggets (false)?");
                bool food1 = bool.Parse(Console.ReadLine());
                if (food1 == true)
                {
                    Console.WriteLine("Pizza is on the right side of the fridge!");
                }
                else
                {
                    Console.WriteLine("Bottom of the fridge!");
                }
            }

        }
    }
}
