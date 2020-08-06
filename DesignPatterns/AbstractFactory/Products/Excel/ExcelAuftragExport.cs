using System;

namespace AbstractFactoryPattern.Products.Excel
{
    public class ExcelAuftragExport : IExcel
    {
        public void Exportiere()
        {
            Console.WriteLine("Exportiere einen Auftrag nach Excel");
        }
    }
}