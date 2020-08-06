using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._3_Konstruktor_und_Destruktor
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
     class Person
     {
        public Person(string name)
        {
            this.Name = name;
        }
        ~Person()
        {
            //Void
        }
        public string Name { get; set; }
     }

    
}
