using System;

namespace AbstractFactoryPattern.Products.PDF
{
    public class PdfKundenlisteExport : IPdf
    {
        public void DruckePdf()
        {
            Console.WriteLine("Drucke Kundenliste.pdf an Drucker..");
        }
    }
}