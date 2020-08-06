using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._1_Vererbung
{
    class Kannibale : Ghost
    {
        public Kannibale(string name) //Konstruktor abrufen von Basisklasse
            : base(name)
        {

        }
        public Kannibale() // Leerer Konstruktor
            : base("")
        {

        }
        public void EatGhost(ref Ghost g) //Methode "frisst" anderen Geist aus Klasse Ghost
        {
            IncreaseSize(g.Size);    // Größe von Kannibalen Objekt + Size des anderen Objektes Ghost
            g = null;               // Geist wird auf null gesetzt, damit er nicht weiter verwendet werden kann
        }
        public void EatGhost(ref Ghost2 g)  //Overload der Methode EatGhost
        {
            IncreaseSize(g.Size);
            g = null;
        }
        public void EatGhost(ref Kannibale g)  //Overload der Methode EatGhost - Kann auch Kannibalen essen
        {
            IncreaseSize(g.Size);
            g = null;
        }

        // Methode zum increase von Kannibalen, wenn Kannibale EatGhost aufruft
        public void IncreaseSize(int size)
        {
            this.Size += size;
        }
    }
}
