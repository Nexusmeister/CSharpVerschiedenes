using AbstractFactoryPattern.Products.EDI;
using AbstractFactoryPattern.Products.Excel;
using AbstractFactoryPattern.Products.PDF;

namespace AbstractFactoryPattern.Factories
{
    public class ExportKundenlisteFactory : IExportFactory
    {
        
        public IExcel CreateExcelExport()
        {
            return new ExcelKundenlisteExport();
        }

        public IPdf CreatePdfExport()
        {
            return new PdfKundenlisteExport();
        }

        public IEdi CreateEdiExport()
        {
            return new EdiKundenlisteExport();
        }
    }
}