namespace SKCDLL.Entities.Models
{
    public class Duell
    {
        public Spieler SpielerHeim { get; set; }
        public Spieler SpielerGast { get; set; }

        public Duell(Spieler spH, Spieler spG)
        {
            SpielerHeim = spH;
            SpielerGast = spG;
        }

        /// <summary>
        /// Vergibt einen Mannschaftspunkt aufgrund der vergebenen Satzpunkte
        /// </summary>
        public void VergebeMannschaftspunkt()
        {
            // Sicherheit, damit auch die aktuellsten Werte genutzt werden
            AktualisiereErgebnisse();

            double spHeim = SpielerHeim.SatzPunkte;
            double spGast = SpielerGast.SatzPunkte;

            if (spHeim + spGast < 4.0)
            {
                SpielerHeim.MannschaftsPunkt = 0.0;
                SpielerGast.MannschaftsPunkt = 0.0;
            }
            else
            {
                if (spHeim > spGast)
                {
                    SpielerHeim.MannschaftsPunkt = 1.0;
                    SpielerGast.MannschaftsPunkt = 0.0;
                }
                else if (spGast > spHeim)
                {
                    SpielerHeim.MannschaftsPunkt = 0.0;
                    SpielerGast.MannschaftsPunkt = 1.0;
                }
                else if (spGast == spHeim)
                {
                    SpielerHeim.BerechneGesamtergebnis();
                    SpielerGast.BerechneGesamtergebnis();
                    if (SpielerHeim.Gesamt > SpielerGast.Gesamt)
                    {
                        SpielerHeim.MannschaftsPunkt = 1.0;
                        SpielerGast.MannschaftsPunkt = 0.0;
                    }
                    else if (SpielerHeim.Gesamt < SpielerGast.Gesamt)
                    {
                        SpielerHeim.MannschaftsPunkt = 0.0;
                        SpielerGast.MannschaftsPunkt = 1.0;
                    }
                    else if (SpielerHeim.Gesamt == SpielerGast.Gesamt)
                    {
                        SpielerHeim.MannschaftsPunkt = 0.5;
                        SpielerGast.MannschaftsPunkt = 0.5;
                    }
                }
            }
        }

        /// <summary>
        /// Vergibt einen Satzpunkt innerhalb eines Duells
        /// </summary>
        /// <returns></returns>
        public bool VergebeSatzpunktAufgrundDerEingabe()
        {
            AktualisiereErgebnisse();
            if (SpielerHeim.Satz1 != null && SpielerGast.Satz1 != null)
            {
                return VergebeSatzpunkt(1);
            }
            if (SpielerHeim.Satz2 != null && SpielerGast.Satz2 != null)
            {
                return VergebeSatzpunkt(2);
            }
            if (SpielerHeim.Satz3 != null && SpielerGast.Satz3 != null)
            {
                return VergebeSatzpunkt(3);
            }
            if (SpielerHeim.Satz4 != null && SpielerGast.Satz4 != null)
            {
                return VergebeSatzpunkt(4);
            }

            return false;
        }

        /// <summary>
        /// Satzpunktvergabelogik
        /// </summary>
        /// <param name="satzNr"></param>
        /// <returns></returns>
        private bool VergebeSatzpunkt(int satzNr)
        {
            AktualisiereErgebnisse();
            bool berechnungErfolgreich = false;
            int ergebnisHeim = 0;
            int ergebnisGast = 0;
            double spHeim = 0;
            double spGast = 0;
            switch (satzNr)
            {
                case 1:
                    ergebnisHeim = SpielerHeim.Satz1.GetValueOrDefault();
                    ergebnisGast = SpielerGast.Satz1.GetValueOrDefault();
                    break;
                case 2:
                    ergebnisHeim = SpielerHeim.Satz2.GetValueOrDefault();
                    ergebnisGast = SpielerGast.Satz2.GetValueOrDefault();
                    break;
                case 3:
                    ergebnisHeim = SpielerHeim.Satz3.GetValueOrDefault();
                    ergebnisGast = SpielerGast.Satz3.GetValueOrDefault();
                    break;
                case 4:
                    ergebnisHeim = SpielerHeim.Satz4.GetValueOrDefault();
                    ergebnisGast = SpielerGast.Satz4.GetValueOrDefault();
                    break;
                default:
                    break;
            }

            if (ergebnisHeim == 0 && ergebnisGast == 0)
            {
                spHeim = 0.0;
                spGast = 0.0;
            }
            else
            {
                //Entscheidungslogik 
                if (ergebnisHeim == ergebnisGast)
                {
                    spHeim = 0.5;
                    spGast = 0.5;
                    berechnungErfolgreich = true;
                }
                else if (ergebnisHeim > ergebnisGast)
                {
                    spHeim = 1.0;
                    spGast = 0;
                    berechnungErfolgreich = true;
                }
                else if (ergebnisHeim < ergebnisGast)
                {
                    spHeim = 0.0;
                    spGast = 1.0;
                    berechnungErfolgreich = true;
                }
            }

            switch (satzNr)
            {
                case 1:
                    SpielerHeim.Sp1 = spHeim;
                    SpielerGast.Sp1 = spGast;
                    break;
                case 2:
                    SpielerHeim.Sp2 = spHeim;
                    SpielerGast.Sp2 = spGast;
                    break;
                case 3:
                    SpielerHeim.Sp3 = spHeim;
                    SpielerGast.Sp3 = spGast;
                    break;
                case 4:
                    SpielerHeim.Sp4 = spHeim;
                    SpielerGast.Sp4 = spGast;
                    break;
                default:
                    //Logger.LogToFile("Kein case für Satzvergabe gefunden (DuellDTO/VergebeSatzpunkt)");
                    break;
            }

            SpielerHeim.BerechneSatzpunkte();
            SpielerGast.BerechneSatzpunkte();

            VergebeMannschaftspunkt();


            return berechnungErfolgreich;
        }

        /// <summary>
        /// Aktualisiert Spielerwerte
        /// </summary>
        public void AktualisiereErgebnisse()
        {
            SpielerHeim.BerechneAlles();
            SpielerGast.BerechneAlles();
        }

        /// <summary>
        /// Vergibt alle Sätze
        /// </summary>
        public void BerechneAlleSaetze()
        {
            VergebeSatzpunkt(1);
            VergebeSatzpunkt(2);
            VergebeSatzpunkt(3);
            VergebeSatzpunkt(4);
        }
    }
}
