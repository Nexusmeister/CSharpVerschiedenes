using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public abstract class IO
    {
        //Ausgabe
        public static void Writeln()
        {
            Console.WriteLine();
        }
            //Zeichen/ -ketten
            public static void Write(char c)
            {
                Console.Write("" + c);
            }
            
            public static void Writeln(char c)
            {
                Console.WriteLine("" + c);
            }
            public static void Write(String s)
            {
                Console.Write("" + s);
            }

            public static void Writeln(String s)
            {
                Console.WriteLine("" + s);
            }

            //Ganzzahlen
            public static void Write(byte b)
            {
            Console.Write("" + b);
            }

            public static void Writeln(byte b)
            {
            Console.WriteLine("" + b);
            }

            public static void Write(short s)
            {
            Console.Write("" + s);
            }

            public static void Writeln(short s)
            {
            Console.WriteLine("" + s);
            }
            
            public static void Write(int i)
            {
            Console.Write("" + i);
            }
            
            public static void Writeln(int i)
            {
            Console.WriteLine("" + i);
            }

            //Fließkommzahlen
            public static void Write(float f)
            {
            Console.Write("" + f);
            }

            public static void Writeln(float f)
            {
            Console.Write("" + f);
            }

            public static void Write(double d)
            {
            Console.Write("" + d);
            }

            public static void Writeln(double d)
            {
            Console.WriteLine("" + d);
            }

            //Boolean
            public static void write(bool b)
            {

                Console.Write("" + b);
            }

            public static void writeln(bool b)
            {

                Console.Write("" + b);
            }

        //Eingabe
        

    }
}
