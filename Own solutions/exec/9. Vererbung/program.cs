using System;

namespace _9._1_Vererbung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Der erste Geist:"); 
            Ghost ghost5 = new Ghost("Spooky"); // Objekt wird aus Klasse Ghost erzeugt und ruft Methode haunt auf
            ghost5.Haunt();
            Console.WriteLine();

            Console.WriteLine("Der zweite Geist:");
            Ghost2 ghost6 = new Ghost2("Slimey"); // Objekt wird aus Unterklasse Ghost2 erzeugt
            ghost6.Haunt();     // MEthodenaufruf der überschriebenen Methode haunt
            Console.WriteLine();

            Console.WriteLine("Der dritte Geist");
            Ghost ghost7 = new Ghost("Smeargol")
            {
                Size = 5 // Attribut Size 
            };
            ghost7.Haunt();
            Console.WriteLine();

            Kannibale ghost8 = new Kannibale("Eeater")
            {
                Size = 5
            };
            ghost8.EatGhost(ref ghost7); // Referenz wird auf Referenz übergeben
            Console.WriteLine("Eeater ist nun {0} groß", ghost8.Size );

            Console.WriteLine();
            Ghost victim = new Ghost("Smergooo");
            victim.Size = 7;
            Kannibale eeater = new Kannibale("Hungry Dude");
            eeater.Size = 5;
            eeater.EatGhost(ref victim);
            Console.WriteLine("Die Größe von {0}: {1}", eeater.Name, eeater.Size);

            Console.WriteLine();
            Ghost2 victim2 = new Ghost2("Smergooolol");
            victim2.Size = 9;           
            eeater.EatGhost(ref victim2); // KannibalenGeist wird immer größer, umso mehr Geister er isst
            Console.WriteLine("Die Größe von {0}: {1}", eeater.Name, eeater.Size);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Array-Methodenaufruf");
            Console.WriteLine();
            Ghost[] ghosts = new Ghost[] { ghost6, ghost5 }; // Via Array wird für zwei Geister die Methode Haunt aufgerufen
            foreach (Ghost g in ghosts)
                g.Haunt();

            Console.ReadKey();
                      
        }


    }
   
}

