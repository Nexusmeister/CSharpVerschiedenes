using System;


namespace _7._8_BMI_Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------BMI-Calculator---------------------");
            Console.WriteLine("Bitte geben Sie Ihre Größe ein:");
            var height = double.Parse(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie Ihr Gewicht an:");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Ihr BMI ist: " + BmiCalc(height, weight));
            Console.ReadKey();

        }
        static double BmiCalc (double weight, double height = 1.80)
        {
            return height / (weight * weight);
        }
    }
}
