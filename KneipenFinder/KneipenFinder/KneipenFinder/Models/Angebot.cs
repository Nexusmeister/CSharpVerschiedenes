namespace KneipenFinder.Models
{
    public class Angebot
    {
        public string SaleDescription { get; set; }
        public string PlaceId { get; set; }

        public Angebot()
        {
            
        }

        public Angebot(string titel, string beschreibung, string placeId)
        {
            PlaceId = placeId;
            SaleDescription = beschreibung;
        }
    }
}
