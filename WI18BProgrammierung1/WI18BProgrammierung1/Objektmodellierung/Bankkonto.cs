using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objektmodellierung
{
    class Bankkonto
    {
        private static int kontoAnzahl = 100000;
        private readonly int kontoNr = 0; 
        private double KontoStand {get; set;}
        private readonly string bic;

        public Bankkonto(double kontostand, string bic)
        {
            kontoAnzahl++;
            this.kontoNr = kontoAnzahl;
            this.KontoStand = kontostand;
            this.bic = bic;

        }

        public Bankkonto()
        {
            kontoAnzahl++;
            this.kontoNr = kontoAnzahl;

        }

        public Bankkonto(double kontostand)
        {
            kontoAnzahl++;
            this.kontoNr = kontoAnzahl;
            this.bic = "XXXXXXXX";
        }

        public void SetKontostand(double kontostand)
        {
            if (kontostand < 0)
            {
                Console.WriteLine("Konto ist unter 0€!");
                
            }
            this.KontoStand = kontostand;
        }

        public double GetKontostand()
        {
            return this.KontoStand;
        }

        public int GetKontoNr()
        {
            return this.kontoNr;
        }
    }
}
