namespace KneipenFinder.Models.APIAntwort
{
    public class Requestresult
    {
        public bool Enriched { get; set; }
        public string Id { get; set; }
        public string About { get; set; }
        public CategoryList[] Category_List { get; set; }
        public Cover Cover { get; set; }
        public Hour[] Hours { get; set; }
        public bool Is_Permanently_Closed { get; set; }
        public string Link { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public float Overall_Star_Rating { get; set; }
        public Parking Parking { get; set; }
        public PaymentOptions Payment_Options { get; set; }
        public string Phone { get; set; }
        public string Price_Range { get; set; }
        public int Rating_Count { get; set; }
        public RestaurantServices Restaurant_Services { get; set; }
        public string Website { get; set; }
        public Saledata[] SaleData { get; set; }
    }
}