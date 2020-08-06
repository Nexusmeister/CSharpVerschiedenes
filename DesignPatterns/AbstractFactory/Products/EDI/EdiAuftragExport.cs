using System;

namespace AbstractFactoryPattern.Products.EDI
{
    public class EdiAuftragExport : IEdi
    {
        public void SendeAnSchnittstelle()
        {
            Console.WriteLine("Sende Auftrag an Seeburger...");
        }
    }
}