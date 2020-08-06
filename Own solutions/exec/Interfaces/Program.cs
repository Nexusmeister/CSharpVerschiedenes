using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IHotDrink[] hotDrinks = new IHotDrink[] // New Array von allen Objekten des Interfaces
            {
                new Coffee() {Caffeine = 100, Degree = 90 }, // Eigenschaften direkt beim Erstellen des Objektes 
                new Tea() { Degree = 90 }
            };

            foreach (IHotDrink drink in hotDrinks)
            {
                Console.WriteLine("Temperatur von {0}: {1}", drink.GetType().Name, // GetType() greift auf Typinformationen des Objekts zu - Name ruft Klassenname auf
                    drink.Degree); // Gleicher Aufruf wie bei Basisklassen
            }

            Console.WriteLine();

            IHasCaffeine[] hasCaffeines = new IHasCaffeine[]
            {
                new Coke() {Caffeine = 25},
                new Coffee() {Caffeine = 100, Degree = 90}
            };

            foreach (IHasCaffeine caffeine in hasCaffeines)
            {
                Console.WriteLine("Koffeingehalt von {0}: {1}", caffeine.GetType().Name,
                    caffeine.Caffeine);
            }


            Console.ReadKey();

        }
    }
}
