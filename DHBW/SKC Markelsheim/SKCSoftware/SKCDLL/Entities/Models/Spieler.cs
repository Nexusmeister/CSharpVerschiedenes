using System.Windows.Forms;

namespace SKCDLL.Entities.Models
{
    public class Spieler
    {
        public string Name { get; set; }
        public int? Satz1 { get; set; }
        public int? Satz2 { get; set; }
        public int? Satz3 { get; set; }
        public int? Satz4 { get; set; }
        public int Volle { get; set; }

        int _v1;
        public int V1
        {
            get
            {
                return _v1;
            }
            set
            {
                _v1 = value;
                BerechneEinzelneSaetze();
            }
        }

        int _v2;
        public int V2
        {
            get
            {
                return _v2;
            }
            set
            {
                _v2 = value;
                BerechneEinzelneSaetze();
            }
        }

        int _v3;
        public int V3
        {
            get
            {
                return _v3;
            }
            set
            {
                _v3 = value;
                BerechneEinzelneSaetze();
            }
        }

        int _v4;
        public int V4
        {
            get
            {
                return _v4;
            }
            set
            {
                _v4 = value;
                BerechneEinzelneSaetze();
            }
        }

        public int Abraeumen { get; set; }

        int _a1;
        public int A1
        {
            get
            {
                return _a1;
            }
            set
            {
                _a1 = value;
                BerechneEinzelneSaetze();
            }
        }

        int _a2;
        public int A2
        {
            get
            {
                return _a2;
            }
            set
            {
                _a2 = value;
                BerechneEinzelneSaetze();
            }
        }

        int _a3;
        public int A3
        {
            get
            {
                return _a3;
            }
            set
            {
                _a3 = value;
                BerechneEinzelneSaetze();
            }
        }

        int _a4;
        public int A4
        {
            get
            {
                return _a4;
            }
            set
            {
                _a4 = value;
                BerechneEinzelneSaetze();
            }
        }
        public int Fehl { get; set; }
        public int F1 { get; set; }
        public int F2 { get; set; }
        public int F3 { get; set; }
        public int F4 { get; set; }
        public int Gesamt { get; set; }
        public double Sp1 { get; set; }

        public double Sp2 { get; set; }
        public double Sp3 { get; set; }
        public double Sp4 { get; set; }
        public double SatzPunkte { get; set; }
        public double MannschaftsPunkt { get; set; }

        public Spieler()
        {
            Name = "Kein Spieler ausgewählt";
        }

        public void BerechneVolle()
        {
            Volle = V1 + V2 + V3 + V4;
        }

        public void BerechneAbraeumen()
        {
            Abraeumen = A1 + A2 + A3 + A4;
        }

        public void BerechneFehl()
        {
            Fehl = F1 + F2 + F3 + F4;
        }

        public void BerechneAlles()
        {
            BerechneVolle();
            BerechneAbraeumen();
            BerechneFehl();
            BerechneGesamtergebnis();
            BerechneSatzpunkte();
        }

        public void BerechneGesamtergebnis()
        {
            BerechneSatzergebnis(1);
            BerechneSatzergebnis(2);
            BerechneSatzergebnis(3);
            BerechneSatzergebnis(4);

            Gesamt = Satz1.GetValueOrDefault() + Satz2.GetValueOrDefault() + Satz3.GetValueOrDefault() + Satz4.GetValueOrDefault();
        }

        public void BerechneSatzpunkte()
        {
            SatzPunkte = Sp1 + Sp2 + Sp3 + Sp4;
        }

        private void BerechneEinzelneSaetze()
        {
            Satz1 = V1 + A1;
            Satz2 = V2 + A2;
            Satz3 = V3 + A3;
            Satz4 = V4 + A4;
        }

        public void SetzeVolle(TextBox txt)
        {
            int.TryParse(txt.Text.Trim(), out int result);
            if (txt.Name.ToLower().Contains("v1"))
            {
                V1 = result;
                BerechneVolle();
                BerechneSatzergebnis(1);
            }
            if (txt.Name.ToLower().Contains("v2"))
            {
                V2 = result;
                BerechneVolle();
                BerechneSatzergebnis(2);
            }
            if (txt.Name.ToLower().Contains("v3"))
            {
                V3 = result;
                BerechneVolle();
                BerechneSatzergebnis(3);
            }
            if (txt.Name.ToLower().Contains("v4"))
            {
                V4 = result;
                BerechneVolle();
                BerechneSatzergebnis(4);
            }
        }

        private void BerechneSatzergebnis(int satzNr)
        {
            switch (satzNr)
            {
                case 1:
                    Satz1 = V1 + A1;
                    break;
                case 2:
                    Satz2 = V2 + A2;
                    break;
                case 3:
                    Satz3 = V3 + A3;
                    break;
                case 4:
                    Satz4 = V4 + A4;
                    break;
                default:
                    //Logger.LogToFile($"Kein case gefunden bei SpielerDTO/VergebeSatzpunkt (SatzNr: {satzNr})");
                    break;
            }
        }

        public void SetzeAbraeumen(TextBox txt)
        {
            int.TryParse(txt.Text.Trim(), out int result);
            if (txt.Name.ToLower().Contains("abr1"))
            {
                A1 = result;
                BerechneAbraeumen();
                BerechneSatzergebnis(1);
            }
            if (txt.Name.ToLower().Contains("abr2"))
            {
                A2 = result;
                BerechneAbraeumen();
                BerechneSatzergebnis(2);
            }
            if (txt.Name.ToLower().Contains("abr3"))
            {
                A3 = result;
                BerechneAbraeumen();
                BerechneSatzergebnis(3);
            }
            if (txt.Name.ToLower().Contains("abr4"))
            {
                A4 = result;
                BerechneAbraeumen();
                BerechneSatzergebnis(4);
            }
        }

        public void SetzeFehl(TextBox txt)
        {
            int.TryParse(txt.Text.Trim(), out int result);
            if (txt.Name.ToLower().Contains("fw1"))
            {
                F1 = result;
            }
            if (txt.Name.ToLower().Contains("fw2"))
            {
                F2 = result; ;
            }
            if (txt.Name.ToLower().Contains("fw3"))
            {
                F3 = result;
            }
            if (txt.Name.ToLower().Contains("fw4"))
            {
                F4 = result;
            }

            BerechneFehl();
        }
    }
}
