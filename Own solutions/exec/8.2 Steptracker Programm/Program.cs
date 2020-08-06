using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._2_Steptracker_Programm
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            Console.WriteLine("Name des Läufers");
            p1.Name = Console.ReadLine();
            Console.WriteLine("Schritte gelaufen");
            p1.Walk(Convert.ToInt32(Console.ReadLine()));
            Person[] persons = new Person[] { p1 };
            Console.WriteLine("Steps today: {0} and walked km: {1}", p1.Footsteps, p1.WalkedKm);
            Console.WriteLine("Average walking count: {0}", Person.AvgWalkKm(persons));

            Console.ReadKey();
        }

        class Person
        {
            public string Name { get; set; }
            public float WalkedKm
            {
                get
                {
                    return this.Footsteps * 0.75F / 1000.0F;
                }
            }
            public float Weight { get; set; }
            public int Footsteps { get; private set; }
            public void Walk(int Footsteps)
            {
                if (Footsteps >= 0)
                {
                    this.Footsteps += Footsteps;
                }
            }
            public static float AvgWalkKm (Person[] persons)
            {
                int amount = persons.Length;
                float walkSum = 0;
                foreach (Person p in persons)
                    walkSum += p.WalkedKm;
                return walkSum / (float)amount;
            }
        }
    }
}
