using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._1_Vererbung

{

    public class Ghost  // Ghost ist im gleichen Namespace wie ghost2 -> Ghost kann ghost2 Attribute veerben
        {               // Ghost wurde ausgelagert in eigene Klassendatei -> Übersichtlichkeit improved

            public Ghost(string name)
            {
                this.Name = name;
            }

            public int Size { get; set; }
            public string Name { get; set; }
            public virtual void Haunt()
            {
                Console.WriteLine("{0} says Hello", this.Name);
            }
        }
}

