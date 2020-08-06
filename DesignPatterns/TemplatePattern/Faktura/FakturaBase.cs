using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern.Faktura
{
    public abstract class FakturaBase
    {
        public bool FuehreFakturaDurch()
        {
            try
            {
                HoleDaten();
                MeldeDatenAnSap();
                AktualisiereDatenbank();
            }
            catch (Exception e)
            {
                LoggeEreignis(e.ToString());
                return false;
            }

            return true;
        }

        public abstract void HoleDaten();
        public abstract void MeldeDatenAnSap();
        public abstract void AktualisiereDatenbank();

        public static void LoggeEreignis(string meldung)
        {
            Console.WriteLine($"[{DateTime.Now}]: {meldung}");
        }
    }
}
