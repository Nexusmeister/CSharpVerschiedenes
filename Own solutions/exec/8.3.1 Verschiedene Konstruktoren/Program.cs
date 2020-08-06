using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._3._1_Verschiedene_Konstruktoren
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            Person p2 = new Person("Beckenbauer");
            Person p3 = new Person("hub", 69);

        }
    }
    class Person
    {
        public Person()
        {

        }
        public Person(string name): this /* Verwendung eines Parameters, Aufruf wird an anderen Konstruktor weitergegeben */ 
                                    (name, 0)  
        {

        }
        public Person(string name, float weight)
        {
            this.Name = name; // Aufruf aus dem zweiten Konstruktor wird hier hin geschickt
            this.Weight = weight;
        }        
        public string Name { get; set; }
        public float Weight { get; set; }
    }
}
