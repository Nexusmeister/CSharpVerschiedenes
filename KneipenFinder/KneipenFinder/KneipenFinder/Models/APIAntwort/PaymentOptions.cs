namespace KneipenFinder.Models.APIAntwort
{
    public class PaymentOptions
    {
        public int Amex { get; set; }
        public int CashOnly { get; set; }
        public int Discover { get; set; }
        public int Mastercard { get; set; }
        public int Visa { get; set; }
    }
}
