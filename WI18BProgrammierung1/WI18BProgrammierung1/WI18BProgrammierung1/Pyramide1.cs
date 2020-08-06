using System;


namespace Sternenpyramide
{
    class Pyramide1
    {

        private int zeilen;

        public Pyramide1(int zeilen)
        {
            this.zeilen = zeilen;
            Console.WriteLine("Erzeuge eine Pyramide!");
            this.ErzeugePyramide(this.zeilen);
        }

        public void ErzeugePyramide(int zeilen)
        {
            for(int i = 1; i <= this.zeilen; i++)
            {
                Console.Write("Zeile: {0} \t", i);
                for(int y = 1; y <= i; y++ )
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

        }
        
    }
}
