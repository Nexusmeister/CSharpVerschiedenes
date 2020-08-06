using System;

namespace AbstractFactoryPattern.Products.EDI
{
    public class EdiKundenlisteExport : IEdi
    {
        public void SendeAnSchnittstelle()
        {
            Console.WriteLine("Sende Kundenliste an irgendeine andere Schnittstelle");
        }
    }
}