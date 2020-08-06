using System;

namespace TemplatePattern.Faktura
{
    public class FakturaTaeglich : FakturaBase
    {
        public override void HoleDaten()
        {
            var sql = "SELECT * FROM Faktura...";
            Console.WriteLine(sql);
        }

        public override void MeldeDatenAnSap()
        {
            Console.WriteLine("xxx an SAP gemeldet");
        }

        public override void AktualisiereDatenbank()
        {
            var sql = "Update...";
            Console.WriteLine(sql);
        }
    }
}