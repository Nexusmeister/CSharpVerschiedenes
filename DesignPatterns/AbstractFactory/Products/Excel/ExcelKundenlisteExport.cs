using System;

namespace AbstractFactoryPattern.Products.Excel
{
    public class ExcelKundenlisteExport : IExcel
    {
        public void Exportiere()
        {
            Console.WriteLine("Exportiere Kundenliste nach Excel");
        }
    }
}