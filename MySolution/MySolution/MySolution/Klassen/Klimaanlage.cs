using System;
using System.Collections.Generic;
using System.Text;

namespace MySolution.Klassen
{
    class Klimaanlage
    {
        public Klimaanlage(int temperatur) // Konstruktor
        {
            this.Temperatur = temperatur;

        }

        //Attribute
        public int Temperatur { get; set; }
        public bool HeizungEin { get; set; }
        public bool KuehlungEin { get; set; }

        public bool IsKuehlungEin()
        {
            return KuehlungEin;
        }

        public bool IsHeizungEin()
        {
            return HeizungEin;
        }



        public void KlimaanlageRegeln()  //Methode zur Regelung einer Klimaanlage
        {


            Console.WriteLine("Aktuelle Temperatur");

            int temperatur = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("<--- Regelung wird gestartet --->");

            if (temperatur > 24)
            {
                HeizungEin = false;
                KuehlungEin = true;
                Console.WriteLine("Kühlung ein - Heizung aus");
            }
            else if (temperatur < 20)
            {
                HeizungEin = false;
                KuehlungEin = true;
                Console.WriteLine("Kühlung aus - Heizung ein");
            }
            else
            {
                HeizungEin = false;
                KuehlungEin = false;
                Console.WriteLine("Kühlung aus - Heizung aus");
            }
            Console.WriteLine("<--- Regelung beendet --->");


        }
    }
}
