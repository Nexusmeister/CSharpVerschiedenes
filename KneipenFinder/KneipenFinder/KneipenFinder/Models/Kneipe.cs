
using System.Collections.Generic;
using KneipenFinder.Models.APIAntwort;

namespace KneipenFinder.Models
{
    public class Kneipe
    {
        public string Name { get; set; }
        public string Strasse { get; set; }
        public string Ort { get; set; }
        public int Postleitzahl { get; set; }
        public double EntfernungInKm { get; set; }
        public string KneipenId { get; set; }
        public List<Saledata> Angebote { get; set; }

        public Kneipe(string name, string strasse, string ort, int postleitzahl)
        {
            Name = name;
            Strasse = strasse;
            Ort = ort;
            Postleitzahl = postleitzahl;
        }

        public Kneipe(string name, string strasse, string ort, int postleitzahl, double entfernung)
        {
            Name = name;
            Strasse = strasse;
            Ort = ort;
            Postleitzahl = postleitzahl;
            EntfernungInKm = entfernung;
        }

        public Kneipe(string name, string strasse, string ort, int postleitzahl, double entfernung, Saledata[] angebote, string placeId) :
            this(name, strasse, ort, postleitzahl, entfernung)
        {
            Angebote = new List<Saledata>(angebote);
            KneipenId = placeId;
        }
    }
}
