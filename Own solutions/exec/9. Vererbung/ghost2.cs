using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._1_Vererbung
{
    public class Ghost2 : Ghost
    {
        public Ghost2(string name) 
            : base(name) // Aufgabe wird an Konstruktor der Basisklasse übergeben
        {
        }
        public override void Haunt() // haunt existiert in hauptklasse schon, override überschreibt methode in ghost2 
        {
            
                this.Slime();
                base.Haunt(); // base lässt auf Basis-Methode der Basisklasse zugreifen
            
        }
        public void Slime() //Methode slime gibt eingegebenen Namen des Objektes aus
        {
            Console.WriteLine("{0} ist slimy", this.Name);
        }
    }
    
}
