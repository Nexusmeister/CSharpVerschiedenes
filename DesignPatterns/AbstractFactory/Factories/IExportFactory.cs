using AbstractFactoryPattern.Products;
using AbstractFactoryPattern.Products.EDI;
using AbstractFactoryPattern.Products.Excel;
using AbstractFactoryPattern.Products.PDF;

namespace AbstractFactoryPattern.Factories
{
    public interface IExportFactory
    {
        IExcel CreateExcelExport();
        IPdf CreatePdfExport();
        IEdi CreateEdiExport();
    }
}