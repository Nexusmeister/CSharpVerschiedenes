using System;

namespace if_else_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GF da? true false");
            bool freundinDa = bool.Parse(Console.ReadLine());

            if (freundinDa == true)
            {
                Console.WriteLine("Heute: Titanic");
                Console.WriteLine("Titanic on Channel:");
                var kanal = int.Parse(Console.ReadLine());
                Console.WriteLine("Titanic on Channel " + kanal);
            }
            else
            {
                Console.WriteLine("Horror?");
                bool horror = bool.Parse(Console.ReadLine());

                if (horror == true)
                {
                    Console.WriteLine("Heute: horror");
                }
                else
                { 
                    Console.WriteLine("Action?");
                    bool action = bool.Parse(Console.ReadLine());

                    if (action == true)
                    {
                        Console.WriteLine("Heute: Action");
                    }
                    else
                    {
                        Console.WriteLine("Thriller?");
                        bool thriller = bool.Parse(Console.ReadLine());

                        if (thriller == true)
                        {
                            Console.WriteLine("Heute: Thriller");
                        }
                        else
                        {
                            Console.WriteLine("Go read a book!");
                        }
                    }
                }                
            }
            Console.ReadKey();
        }
    }
}
