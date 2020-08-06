using System;
using AbstractFactoryPattern.Factories;
using AbstractFactoryPattern.Products.EDI;
using AbstractFactoryPattern.Products.Excel;
using AbstractFactoryPattern.Products.PDF;

namespace AbstractFactoryPattern
{
    class Program
    {
        private static IExportFactory _factory;
        private static IExcel _excel;
        private static IEdi _edi;
        private static IPdf _pdf;

        private static void Main(string[] args)
        {
            _factory = new ExportAuftragFactory();
            _excel = _factory.CreateExcelExport();

            _excel.Exportiere();
            _pdf = _factory.CreatePdfExport();
            _pdf.DruckePdf();

            _edi = _factory.CreateEdiExport();
            _edi.SendeAnSchnittstelle();

            Console.ReadKey();
            Console.WriteLine();

            _factory = new ExportKundenlisteFactory();

            _excel = _factory.CreateExcelExport();
            _excel.Exportiere();

            _pdf = _factory.CreatePdfExport();
            _pdf.DruckePdf();

            _edi = _factory.CreateEdiExport();
            _edi.SendeAnSchnittstelle();

            Console.ReadKey();
        }
    }
}
