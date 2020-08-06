using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomfortablerZahlenspeicher
{
    class Zahlenspeicher
    {
        //Attribute
        public int[] Speicher { get; }
        public int Position { get; set; }
        public int Speichergröße { get; }

        //Konstruktor
        public Zahlenspeicher(int speichergröße)
        {
            this.Speichergröße = speichergröße;
            this.Speicher = new int[speichergröße];
            this.Position = 0;
        }

        public bool Hinzufügen(int zahl)
        {
            if(this.Position >= Speicher.Length)
            {
                return false;
            } else
            {
                this.Speicher[this.Position] = zahl;
                this.Position++;
                return true;
            }
        }

        //Zahlen werden aus dem Speicher gelöscht
        public void LöscheLetzteZahl()
        {

            if(this.Position == 0)
            {
                Console.WriteLine("Speicher ist leer!");

            } else
            {
                this.Position--;
                this.Speicher[this.Position] = 0;
            }

        }

        public void LöscheLetzteZahl(int anzahl)
        {
            for(int i = 0; i <= anzahl; i++)
            {
                if (this.Position == 0)
                {
                    Console.WriteLine("Speicher ist leer!");
                    break;
                }
                else
                {
                    this.LöscheLetzteZahl();
                }
            }
        }

        public bool SucheZahl(int zahl)
        {
            for(int i = 0; i < this.Position; i++)
            {
                if(this.Speicher[i] == zahl)
                {
                    return true;
                } 
                
            }
            return false;
        }

       
        public override string ToString()
        {
            string stringBuffer = "[";
            for(int i = 0; i < this.Position; i++)
            {
                if (i == 0)
                {
                    stringBuffer = stringBuffer + this.Speicher[i];
                }
                else
                {
                    stringBuffer = stringBuffer + " " + this.Speicher[i];
                }
            }
            stringBuffer = stringBuffer + "]";
            return stringBuffer;
        }

        public static bool IstGleich(int[] a, int[] b)
        {
            if(a.Length != b.Length)
            {
                return false;
            }

            for(int i = 0; i < a.Length; i++)
            {
                if(a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
