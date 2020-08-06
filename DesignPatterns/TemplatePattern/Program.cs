using System;
using TemplatePattern.Faktura;

namespace TemplatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            FakturaTaeglich fakturaTaeglich = new FakturaTaeglich();
            fakturaTaeglich.FuehreFakturaDurch();
        }
    }
}
