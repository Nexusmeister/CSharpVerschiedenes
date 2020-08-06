using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._7_Swap_Methode
{
    class Program
    {
        static void Main(string[] args)
        {

            var num1 = 2.2;
            var num2 = 3.2;

            Swap(ref num1,ref num2); // Methodenaufruf - ref muss genutzt werden, da Value-Datentypen vorhanden sind

            Console.WriteLine("Zahl 1: {0} Zahl2: {1}", num1, num2);
            Console.ReadKey();
            
        }
        static void Swap(ref double a, ref double b) //Methode Swap - kopiert variablen aus dem Methodenaufruf - braucht auch wieder ref
        {
            double temp = a; 
            a=b;
            b = temp;
        }
    }
}
