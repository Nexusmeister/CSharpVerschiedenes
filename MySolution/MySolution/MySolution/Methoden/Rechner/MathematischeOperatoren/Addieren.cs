﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MySolution.Methoden.Rechner.MathematischeOperatoren
{
    class Addieren
    {
        public static void StarteAddition()
        {
            Console.Write("Geben Sie Zahl 1 ein: ");
            double num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Geben Sie Zahl 2 ein: ");
            double num2 = Convert.ToInt32(Console.ReadLine());

            double ergebnis = Addiere(num1, num2);
            Console.WriteLine("Das Ergebnis ist: " + ergebnis);
        }
        public static double Addiere(double a, double b)
        {
                return a + b;       // Rückgabe ist die Addition von a und b
        }

    }
}
