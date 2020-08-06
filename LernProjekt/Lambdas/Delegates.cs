using Lambdas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lambdas
{
    public class Delegates
    {
        // Definition eines Delegaten
        public delegate int Rechenoperation(int x, int y);
        public delegate bool Mensch(int input);

        public static void Execute()
        {
            Rechenoperation op = new Rechenoperation(Addition);
            Student person = new Student();
            Mensch mensch = new Mensch(person.KannLaufen);
            mensch += new Mensch(person.BestehtKlausuren);
            Mensch bestehen = new Mensch(person.BestehtKlausuren);
            Console.WriteLine(mensch(23));
            Console.WriteLine(op(1, 5));
        }

        public static int Addition(int x, int y)
        {
            return x + y;
        }
    }
}
