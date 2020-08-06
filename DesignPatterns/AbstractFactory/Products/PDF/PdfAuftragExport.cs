using System;

namespace AbstractFactoryPattern.Products.PDF
{
    public class PdfAuftragExport : IPdf
    {
        public void DruckePdf()
        {
            Console.WriteLine("Drucke Auftrag.pdf an Drucker...");
        }
    }
}