using System;
using System.Collections.Generic;
using System.Text;

namespace MySolution
{
    public abstract class IO
    {
        //Ausgabe
        public static void writeln()
        {
            Console.WriteLine();
        }

        //Zeichen- (ketten)
            //String
            public static void write(String s)
            {
            Console.Write("" + s);
            }
    }
}
