using AbstractFactoryPattern.Products.EDI;
using AbstractFactoryPattern.Products.Excel;
using AbstractFactoryPattern.Products.PDF;

namespace AbstractFactoryPattern.Factories
{
    public class ExportAuftragFactory : IExportFactory
    {
        public IExcel CreateExcelExport()
        {
            return new ExcelAuftragExport();
        }

        public IPdf CreatePdfExport()
        {
            return new PdfAuftragExport();
        }

        public IEdi CreateEdiExport()
        {
            return new EdiAuftragExport();
        }
    }
}