using System;


namespace TestProjectZurKlassenVerwaltung
{
    class BmiRechner
    {
        public static void EingabeDaten() {
            Console.WriteLine("---------------------BMI-Calculator---------------------");
            Console.WriteLine("Bitte geben Sie Ihre Größe ein:");
            var height = double.Parse(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie Ihr Gewicht an:");
            var weight = double.Parse(Console.ReadLine());

            var bmi = BmiCalc(weight, height);

            Console.WriteLine("Ihr BMI ist: " + bmi);

            if(bmi <= 20)
            {
                Console.WriteLine("Sie sind untergewichtig!");
            } else if (bmi > 20 & bmi <= 25)
            {
                Console.WriteLine("Sie sind im Normalgewicht.");
            } else if (bmi > 25 & bmi <= 30)
            {
                Console.WriteLine("Sie sind übergewichtig!");
            } else if (bmi > 30 & bmi <= 40)
            {
                Console.WriteLine("Sie sind im Adipositas-Bereich!!!");
            } else
            {
                Console.WriteLine("Sie sind massiv adipös! \n" +
                    "Suchen Sie einen Arzt auf!");
            }
            

        }
        static double BmiCalc(double weight, double height = 1.80)
        {
            return weight / (height * height);
        }
    }
}


