using System;
using System.Collections.Generic;

namespace SKCDLL.Entities.Models
{
    public class Partie
    {
        public string SKCMarkelsheimName { get; set; }
        public string GastmannschaftName { get; set; }
        public List<Spieler> SpielerHeim { get; set; }
        public List<Spieler> SpielerGast { get; set; }
        public Spieler SpielerSKC1 { get; set; }
        public Spieler SpielerSKC2 { get; set; }
        public Spieler SpielerSKC3 { get; set; }
        public Spieler SpielerSKC4 { get; set; }
        public Spieler SpielerSKC5 { get; set; }
        public Spieler SpielerSKC6 { get; set; }
        public Spieler SpielerGast1 { get; set; }
        public Spieler SpielerGast2 { get; set; }
        public Spieler SpielerGast3 { get; set; }
        public Spieler SpielerGast4 { get; set; }
        public Spieler SpielerGast5 { get; set; }
        public Spieler SpielerGast6 { get; set; }

        public Duell Duell1 { get; set; }
        public Duell Duell2 { get; set; }
        public Duell Duell3 { get; set; }
        public Duell Duell4 { get; set; }
        public Duell Duell5 { get; set; }
        public Duell Duell6 { get; set; }

        public int MannschaftsErgebnisHeim { get; set; }
        public int MannschaftsErgebnisGast { get; set; }

        public int ErgebnisDifferenz { get; set; }
        public string DifferenzText { get; set; }

        public double MannschaftspunkteHeim { get; set; }
        public double MannschaftspunkteGast { get; set; }

        public double MannschaftsPunkteBesseresErgebnisHeim { get; set; }
        public double MannschaftsPunkteBesseresErgebnisGast { get; set; }

        public double SatzpunkteHeim { get; set; }
        public double SatzpunkteGast { get; set; }

        public int VolleHeim { get; set; }
        public int VolleGast { get; set; }
        public int AbraeumenHeim { get; set; }
        public int AbraeumenGast { get; set; }
        public int FehlHeim { get; set; }
        public int FehlGast { get; set; }

        public string Bemerkungen { get; set; }

        public Partie()
        {
            InitalisiereSpieler();
            InitialisiereDuelle();
            PutSpielerInListen();
            SKCMarkelsheimName = "SKC Markelsheim";
            GastmannschaftName = "Gast";
        }

        /// <summary>
        /// Alle Spielerobjekte werden in zwei Listen gesetzt
        /// </summary>
        private void PutSpielerInListen()
        {
            SpielerHeim = new List<Spieler>();
            SpielerGast = new List<Spieler>();

            SpielerHeim.Add(SpielerSKC1);
            SpielerHeim.Add(SpielerSKC2);
            SpielerHeim.Add(SpielerSKC3);
            SpielerHeim.Add(SpielerSKC4);
            SpielerHeim.Add(SpielerSKC5);
            SpielerHeim.Add(SpielerSKC6);

            SpielerGast.Add(SpielerGast1);
            SpielerGast.Add(SpielerGast2);
            SpielerGast.Add(SpielerGast3);
            SpielerGast.Add(SpielerGast4);
            SpielerGast.Add(SpielerGast5);
            SpielerGast.Add(SpielerGast6);
        }

        /// <summary>
        /// Erzeugt Duellobjekte aus Klasse DuellDTO
        /// </summary>
        /// <returns></returns>
        private bool InitialisiereDuelle()
        {
            try
            {
                Duell1 = new Duell(SpielerSKC1, SpielerGast1);
                Duell2 = new Duell(SpielerSKC2, SpielerGast2);
                Duell3 = new Duell(SpielerSKC3, SpielerGast3);
                Duell4 = new Duell(SpielerSKC4, SpielerGast4);
                Duell5 = new Duell(SpielerSKC5, SpielerGast5);
                Duell6 = new Duell(SpielerSKC6, SpielerGast6);
                return true;
            }
            catch (Exception e1)
            {
                //Logger.LogToFileUndVersendeMail($"Bei Spielererzeugung ist ein Fehler aufgetreten! ---> {e1.StackTrace}", "Fehler bei Objekterzeugung");
                return false;
            }

        }

        /// <summary>
        /// Erzeugt Spielerobjekte aus Klasse SpielerDTO
        /// </summary>
        /// <returns></returns>
        private bool InitalisiereSpieler()
        {
            try
            {
                SpielerSKC1 = new Spieler();
                SpielerSKC2 = new Spieler();
                SpielerSKC3 = new Spieler();
                SpielerSKC4 = new Spieler();
                SpielerSKC5 = new Spieler();
                SpielerSKC6 = new Spieler();
                SpielerGast1 = new Spieler();
                SpielerGast2 = new Spieler();
                SpielerGast3 = new Spieler();
                SpielerGast4 = new Spieler();
                SpielerGast5 = new Spieler();
                SpielerGast6 = new Spieler();
                return true;
            }
            catch (Exception e1)
            {
                //Logger.LogToFileUndVersendeMail($"Bei Duellerzeugung ist ein Fehler aufgetreten! ---> {e1.StackTrace}", "Fehler bei Objekterzeugung");
                return false;
            }

        }

        /// <summary>
        /// Übertrage und berechne alle Werte neu
        /// </summary>
        public void AktualisiereSpiel()
        {
            Duell1.AktualisiereErgebnisse();
            Duell2.AktualisiereErgebnisse();
            Duell3.AktualisiereErgebnisse();
            Duell4.AktualisiereErgebnisse();
            Duell5.AktualisiereErgebnisse();
            Duell6.AktualisiereErgebnisse();

            Duell1.BerechneAlleSaetze();
            Duell2.BerechneAlleSaetze();
            Duell3.BerechneAlleSaetze();
            Duell4.BerechneAlleSaetze();
            Duell5.BerechneAlleSaetze();
            Duell6.BerechneAlleSaetze();

            BerechneMannschaftsErgebnis();
            BerechneSummeSatzpunkte();
            BerechneSummeMannschaftspunkte();

            BerechneVolleSumme();
            BerechneAbraeumenSumme();
            BerechneFehlSumme();
        }

        /// <summary>
        /// Berechnung Fehlsumme der gesamten Mannschaft
        /// </summary>
        private void BerechneFehlSumme()
        {
            FehlHeim = 0;
            FehlGast = 0;
            foreach (var spieler in SpielerHeim)
            {
                FehlHeim += spieler.Fehl;
            }

            foreach (var spieler in SpielerGast)
            {
                FehlGast += spieler.Fehl;
            }
        }

        /// <summary>
        /// Berechnung Abräumergebnis der gesamten Mannschaft
        /// </summary>
        private void BerechneAbraeumenSumme()
        {
            AbraeumenHeim = 0;
            AbraeumenGast = 0;
            foreach (var spieler in SpielerHeim)
            {
                AbraeumenHeim += spieler.Abraeumen;
            }

            foreach (var spieler in SpielerGast)
            {
                AbraeumenGast += spieler.Abraeumen;
            }
        }

        /// <summary>
        /// Berechnung Volleergebnis der gesamten Mannschaft
        /// </summary>
        private void BerechneVolleSumme()
        {
            VolleHeim = 0;
            VolleGast = 0;
            foreach (var spieler in SpielerHeim)
            {
                VolleHeim += spieler.Volle;
            }

            foreach (var spieler in SpielerGast)
            {
                VolleGast += spieler.Volle;
            }
        }

        /// <summary>
        /// Berechnung aller Satzpunkte der gesamten Mannschaft
        /// </summary>
        private void BerechneSummeSatzpunkte()
        {
            SatzpunkteHeim = SpielerSKC1.SatzPunkte + SpielerSKC2.SatzPunkte + SpielerSKC3.SatzPunkte + SpielerSKC4.SatzPunkte + SpielerSKC5.SatzPunkte + SpielerSKC6.SatzPunkte;
            SatzpunkteGast = SpielerGast1.SatzPunkte + SpielerGast2.SatzPunkte + SpielerGast3.SatzPunkte + SpielerGast4.SatzPunkte + SpielerGast5.SatzPunkte + SpielerGast6.SatzPunkte;
        }

        /// <summary>
        /// Berechnung Mannschaftsergebnis der gesamten Mannschaft
        /// </summary>
        private void BerechneMannschaftsErgebnis()
        {
            MannschaftsErgebnisHeim = SpielerSKC1.Gesamt + SpielerSKC2.Gesamt + SpielerSKC3.Gesamt + SpielerSKC4.Gesamt + SpielerSKC5.Gesamt + SpielerSKC6.Gesamt;
            MannschaftsErgebnisGast = SpielerGast1.Gesamt + SpielerGast2.Gesamt + SpielerGast3.Gesamt + SpielerGast4.Gesamt + SpielerGast5.Gesamt + SpielerGast6.Gesamt;
            ErmittleMannschaftsdifferenz();
        }

        /// <summary>
        /// Berechnet die Differenz zwischen den Gesamtholz
        /// </summary>
        public void ErmittleMannschaftsdifferenz()
        {
            //Wenn negativ, dann + für Gastmannschaft
            ErgebnisDifferenz = MannschaftsErgebnisHeim - MannschaftsErgebnisGast;
        }

        /// <summary>
        /// MP-Vergabe für das bessere Mannschaftsergebnis
        /// </summary>
        public void VergebeMPFuerBesseresErgebnis()
        {
            if (MannschaftsErgebnisHeim > MannschaftsErgebnisGast)
            {
                MannschaftsPunkteBesseresErgebnisHeim = 2.0;
                MannschaftsPunkteBesseresErgebnisGast = 0.0;
            }
            if (MannschaftsErgebnisHeim < MannschaftsErgebnisGast)
            {
                MannschaftsPunkteBesseresErgebnisHeim = 0.0;
                MannschaftsPunkteBesseresErgebnisGast = 2.0;
            }
            if (MannschaftsErgebnisHeim == MannschaftsErgebnisGast)
            {
                MannschaftsPunkteBesseresErgebnisHeim = 1.0;
                MannschaftsPunkteBesseresErgebnisGast = 1.0;
            }
        }

        /// <summary>
        /// Berechnet die gesamten Mannschaftspunkte beider Mannschaften
        /// </summary>
        public void BerechneSummeMannschaftspunkte()
        {
            MannschaftspunkteHeim = SpielerSKC1.MannschaftsPunkt + SpielerSKC2.MannschaftsPunkt + SpielerSKC3.MannschaftsPunkt + SpielerSKC4.MannschaftsPunkt + SpielerSKC5.MannschaftsPunkt + SpielerSKC6.MannschaftsPunkt;
            MannschaftspunkteGast = SpielerGast1.MannschaftsPunkt + SpielerGast2.MannschaftsPunkt + SpielerGast3.MannschaftsPunkt + SpielerGast4.MannschaftsPunkt + SpielerGast5.MannschaftsPunkt + SpielerGast6.MannschaftsPunkt;

            if (MannschaftspunkteHeim + MannschaftspunkteGast == 6.0)
            {
                VergebeMPFuerBesseresErgebnis();
                MannschaftspunkteHeim = SpielerSKC1.MannschaftsPunkt + SpielerSKC2.MannschaftsPunkt + SpielerSKC3.MannschaftsPunkt + SpielerSKC4.MannschaftsPunkt + SpielerSKC5.MannschaftsPunkt + SpielerSKC6.MannschaftsPunkt + MannschaftsPunkteBesseresErgebnisHeim;
                MannschaftspunkteGast = SpielerGast1.MannschaftsPunkt + SpielerGast2.MannschaftsPunkt + SpielerGast3.MannschaftsPunkt + SpielerGast4.MannschaftsPunkt + SpielerGast5.MannschaftsPunkt + SpielerGast6.MannschaftsPunkt + MannschaftsPunkteBesseresErgebnisGast;
            }
        }
    }
}
