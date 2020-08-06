using ProjektProzessLernen.Beförderungsmittel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProzessLernen.Artikel
{
    class ArtikelAufLager
    {
        //Beförderungsmittel.Fördermittel mittel1;
        private readonly string artikelbeschreibung;
        public string Artikelbeschreibung
        {
            get
            {
               return this.artikelbeschreibung;
            }
        }
        private readonly long artikelID;
        public long ArtikelID
        {
            get
            {
                return this.artikelID;
            }
        }

        private int bestand;
        public int Bestand
        {
            get
            {
                return this.bestand;
            }

            set
            {
                this.bestand = value;
            }
        }

        private double gewichtInKG;
        public double GewichtInKG
        {
            get
            {
                return this.gewichtInKG;
            }
            set
            {
                this.gewichtInKG = value;
            }
        }


      
        

        public ArtikelAufLager(string artikelbez, int bestand, double gewichtInKG)
        {
            int buffer = 1;
            foreach (var artikel in Enum.GetNames(typeof(Artikel.EnumArtikel)))
            {
                
                if(artikelbez == artikel)
                {
                    this.artikelbeschreibung = artikel.ToString();
                    this.artikelID = buffer;
                    this.bestand = bestand;
                    this.gewichtInKG = gewichtInKG;
                   
                }
                buffer++;
            }






        }

        /*
        private Fördermittel EntscheideÜberBeförderungsMittel()
        {
            if (this.gewichtInKG >= 28.0)
            {
               return Fördermittel mittel1 = new Beförderungsmittel.Lagerhilfsmittel();
            }
            else
            {
                return Beförderungsmittel.Fördermittel mittel1 = new Beförderungsmittel.Tablar();
            }
        }
        
        
        public string GetTypeOfBeförderungsmittel()
        {
            string mittel = mittel1.ToString();

            return null;
        }
        */
    }
}
