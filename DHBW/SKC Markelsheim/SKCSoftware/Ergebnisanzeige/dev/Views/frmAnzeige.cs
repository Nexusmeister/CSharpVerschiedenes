using System;
using System.Drawing;
using System.Windows.Forms;
using Ergebnisanzeige.Enums;
using Ergebnisanzeige.ErgebnisanzeigenDTO;
using Ergebnisanzeige.Properties;
using Ergebnisanzeige.Tools;

namespace Ergebnisanzeige.Views
{
    public partial class frmAnzeige : Form
    {
        public Anzeige StatusAnzeige = Anzeige.GESCHLOSSEN;
        SpielDTO dto;
        public frmAnzeige()
        {
            InitializeComponent();
            Text += Application.ProductVersion;
        }

        public void LadeDatenInControls()
        {
            try
            {
                //Lade Vereinsnamen
                gbDGastName.Text = dto.GastmannschaftName;
                gbDSKCName.Text = dto.SKCMarkelsheimMannschaft;

                //Lade Spielernamen
                txtDSKC1Name.Text = dto.SpielerSKC1.Name;
                txtDSKC2Name.Text = dto.SpielerSKC2.Name;
                txtDSKC3Name.Text = dto.SpielerSKC3.Name;
                txtDSKC4Name.Text = dto.SpielerSKC4.Name;
                txtDSKC5Name.Text = dto.SpielerSKC5.Name;
                txtDSKC6Name.Text = dto.SpielerSKC6.Name;
                txtDGast1Name.Text = dto.SpielerGast1.Name;
                txtDGast2Name.Text = dto.SpielerGast2.Name;
                txtDGast3Name.Text = dto.SpielerGast3.Name;
                txtDGast4Name.Text = dto.SpielerGast4.Name;
                txtDGast5Name.Text = dto.SpielerGast5.Name;
                txtDGast6Name.Text = dto.SpielerGast6.Name;

                //Lade Spielerwerte
                txtDSKC1Satz1.Text = dto.SpielerSKC1.Satz1.ToString();
                txtDSKC1Satz2.Text = dto.SpielerSKC1.Satz2.ToString();
                txtDSKC1Satz3.Text = dto.SpielerSKC1.Satz3.ToString();
                txtDSKC1Satz4.Text = dto.SpielerSKC1.Satz4.ToString();
                txtDSKC1SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC1.Sp1);
                txtDSKC1SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC1.Sp2);
                txtDSKC1SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC1.Sp3);
                txtDSKC1SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC1.Sp4);
                txtDSKC1Ergebnis.Text = dto.SpielerSKC1.Gesamt.ToString();
                txtDSKC1SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC1.SatzPunkte);
                txtDSKC1MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC1.MannschaftsPunkt);

                txtDSKC2Satz1.Text = dto.SpielerSKC2.Satz1.ToString();
                txtDSKC2Satz2.Text = dto.SpielerSKC2.Satz2.ToString();
                txtDSKC2Satz3.Text = dto.SpielerSKC2.Satz3.ToString();
                txtDSKC2Satz4.Text = dto.SpielerSKC2.Satz4.ToString();
                txtDSKC2SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC2.Sp1);
                txtDSKC2SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC2.Sp2);
                txtDSKC2SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC2.Sp3);
                txtDSKC2SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC2.Sp4);
                txtDSKC2Ergebnis.Text = dto.SpielerSKC2.Gesamt.ToString();
                txtDSKC2SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC2.SatzPunkte);
                txtDSKC2MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC2.MannschaftsPunkt);

                txtDSKC3Satz1.Text = dto.SpielerSKC3.Satz1.ToString();
                txtDSKC3Satz2.Text = dto.SpielerSKC3.Satz2.ToString();
                txtDSKC3Satz3.Text = dto.SpielerSKC3.Satz3.ToString();
                txtDSKC3Satz4.Text = dto.SpielerSKC3.Satz4.ToString();
                txtDSKC3SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC3.Sp1);
                txtDSKC3SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC3.Sp2);
                txtDSKC3SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC3.Sp3);
                txtDSKC3SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC3.Sp4);
                txtDSKC3Ergebnis.Text = dto.SpielerSKC3.Gesamt.ToString();
                txtDSKC3SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC3.SatzPunkte);
                txtDSKC3MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC3.MannschaftsPunkt);

                txtDSKC4Satz1.Text = dto.SpielerSKC4.Satz1.ToString();
                txtDSKC4Satz2.Text = dto.SpielerSKC4.Satz2.ToString();
                txtDSKC4Satz3.Text = dto.SpielerSKC4.Satz3.ToString();
                txtDSKC4Satz4.Text = dto.SpielerSKC4.Satz4.ToString();
                txtDSKC4SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC4.Sp1);
                txtDSKC4SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC4.Sp2);
                txtDSKC4SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC4.Sp3);
                txtDSKC4SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC4.Sp4);
                txtDSKC4Ergebnis.Text = dto.SpielerSKC4.Gesamt.ToString();
                txtDSKC4SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC4.SatzPunkte);
                txtDSKC4MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC4.MannschaftsPunkt);

                txtDSKC5Satz1.Text = dto.SpielerSKC5.Satz1.ToString();
                txtDSKC5Satz2.Text = dto.SpielerSKC5.Satz2.ToString();
                txtDSKC5Satz3.Text = dto.SpielerSKC5.Satz3.ToString();
                txtDSKC5Satz4.Text = dto.SpielerSKC5.Satz4.ToString();
                txtDSKC5SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC5.Sp1);
                txtDSKC5SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC5.Sp2);
                txtDSKC5SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC5.Sp3);
                txtDSKC5SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC5.Sp4);
                txtDSKC5Ergebnis.Text = dto.SpielerSKC5.Gesamt.ToString();
                txtDSKC5SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC5.SatzPunkte);
                txtDSKC5MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC5.MannschaftsPunkt);

                txtDSKC6Satz1.Text = dto.SpielerSKC6.Satz1.ToString();
                txtDSKC6Satz2.Text = dto.SpielerSKC6.Satz2.ToString();
                txtDSKC6Satz3.Text = dto.SpielerSKC6.Satz3.ToString();
                txtDSKC6Satz4.Text = dto.SpielerSKC6.Satz4.ToString();
                txtDSKC6SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC6.Sp1);
                txtDSKC6SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC6.Sp2);
                txtDSKC6SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC6.Sp3);
                txtDSKC6SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC6.Sp4);
                txtDSKC6Ergebnis.Text = dto.SpielerSKC6.Gesamt.ToString();
                txtDSKC6SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC6.SatzPunkte);
                txtDSKC6MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerSKC6.MannschaftsPunkt);

                txtDGast1Satz1.Text = dto.SpielerGast1.Satz1.ToString();
                txtDGast1Satz2.Text = dto.SpielerGast1.Satz2.ToString();
                txtDGast1Satz3.Text = dto.SpielerGast1.Satz3.ToString();
                txtDGast1Satz4.Text = dto.SpielerGast1.Satz4.ToString();
                txtDGast1SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast1.Sp1);
                txtDGast1SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast1.Sp2);
                txtDGast1SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast1.Sp3);
                txtDGast1SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast1.Sp4);
                txtDGast1Ergebnis.Text = dto.SpielerGast1.Gesamt.ToString();
                txtDGast1SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast1.SatzPunkte);
                txtDGast1MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast1.MannschaftsPunkt);

                txtDGast2Satz1.Text = dto.SpielerGast2.Satz1.ToString();
                txtDGast2Satz2.Text = dto.SpielerGast2.Satz2.ToString();
                txtDGast2Satz3.Text = dto.SpielerGast2.Satz3.ToString();
                txtDGast2Satz4.Text = dto.SpielerGast2.Satz4.ToString();
                txtDGast2SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast2.Sp1);
                txtDGast2SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast2.Sp2);
                txtDGast2SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast2.Sp3);
                txtDGast2SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast2.Sp4);
                txtDGast2Ergebnis.Text = dto.SpielerGast2.Gesamt.ToString();
                txtDGast2SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast2.SatzPunkte);
                txtDGast2MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast2.MannschaftsPunkt);

                txtDGast3Satz1.Text = dto.SpielerGast3.Satz1.ToString();
                txtDGast3Satz2.Text = dto.SpielerGast3.Satz2.ToString();
                txtDGast3Satz3.Text = dto.SpielerGast3.Satz3.ToString();
                txtDGast3Satz4.Text = dto.SpielerGast3.Satz4.ToString();
                txtDGast3SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast3.Sp1);
                txtDGast3SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast3.Sp2);
                txtDGast3SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast3.Sp3);
                txtDGast3SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast3.Sp4);
                txtDGast3Ergebnis.Text = dto.SpielerGast3.Gesamt.ToString();
                txtDGast3SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast3.SatzPunkte);
                txtDGast3MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast3.MannschaftsPunkt);

                txtDGast4Satz1.Text = dto.SpielerGast4.Satz1.ToString();
                txtDGast4Satz2.Text = dto.SpielerGast4.Satz2.ToString();
                txtDGast4Satz3.Text = dto.SpielerGast4.Satz3.ToString();
                txtDGast4Satz4.Text = dto.SpielerGast4.Satz4.ToString();
                txtDGast4SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast4.Sp1);
                txtDGast4SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast4.Sp2);
                txtDGast4SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast4.Sp3);
                txtDGast4SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast4.Sp4);
                txtDGast4Ergebnis.Text = dto.SpielerGast4.Gesamt.ToString();
                txtDGast4SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast4.SatzPunkte);
                txtDGast4MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast4.MannschaftsPunkt);

                txtDGast5Satz1.Text = dto.SpielerGast5.Satz1.ToString();
                txtDGast5Satz2.Text = dto.SpielerGast5.Satz2.ToString();
                txtDGast5Satz3.Text = dto.SpielerGast5.Satz3.ToString();
                txtDGast5Satz4.Text = dto.SpielerGast5.Satz4.ToString();
                txtDGast5SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast5.Sp1);
                txtDGast5SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast5.Sp2);
                txtDGast5SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast5.Sp3);
                txtDGast5SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast5.Sp4);
                txtDGast5Ergebnis.Text = dto.SpielerGast5.Gesamt.ToString();
                txtDGast5SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast5.SatzPunkte);
                txtDGast5MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast5.MannschaftsPunkt);

                txtDGast6Satz1.Text = dto.SpielerGast6.Satz1.ToString();
                txtDGast6Satz2.Text = dto.SpielerGast6.Satz2.ToString();
                txtDGast6Satz3.Text = dto.SpielerGast6.Satz3.ToString();
                txtDGast6Satz4.Text = dto.SpielerGast6.Satz4.ToString();
                txtDGast6SP1.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast6.Sp1);
                txtDGast6SP2.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast6.Sp2);
                txtDGast6SP3.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast6.Sp3);
                txtDGast6SP4.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast6.Sp4);
                txtDGast6Ergebnis.Text = dto.SpielerGast6.Gesamt.ToString();
                txtDGast6SPGesamt.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast6.SatzPunkte);
                txtDGast6MP.Text = Uebertragen.FormatiereKommazahl(dto.SpielerGast6.MannschaftsPunkt);

                //Lade Gesamtergebnisse
                txtDSKCFehl.Text = dto.FehlHeim.ToString();
                txtDSKCVolle.Text = dto.VolleHeim.ToString();
                txtDSKCAbr.Text = dto.AbraeumenHeim.ToString();
                txtDSKCGesamtergebnis.Text = dto.MannschaftsErgebnisHeim.ToString();

                txtDGastFehl.Text = dto.FehlGast.ToString();
                txtDGastVolle.Text = dto.VolleGast.ToString();
                txtDGastAbr.Text = dto.AbraeumenGast.ToString();
                txtDGastGesamtergebnis.Text = dto.MannschaftsErgebnisGast.ToString();

                //Lade MP und SP
                txtDSKCMP.Text = Uebertragen.FormatiereKommazahl(dto.MannschaftspunkteHeim);
                txtDSKCSP.Text = Uebertragen.FormatiereKommazahl(dto.SatzpunkteHeim);

                txtDGastMP.Text = Uebertragen.FormatiereKommazahl(dto.MannschaftspunkteGast);
                txtDGastSP.Text = Uebertragen.FormatiereKommazahl(dto.SatzpunkteGast);

                txtDErgebnisdifferenz.Text = dto.DifferenzText;
            }
            catch (Exception e1)
            {
                Logger.LogToFile($"Fehler beim Befüllen der Anzeigencontrols: {e1.Message} {e1.StackTrace}");
                SKCMessages.ShowError($"Fehler beim Befüllen der Anzeige. {e1.Message}");
            }           
        }

        private void frmAnzeige_Load(object sender, EventArgs e)
        {
            if (Settings.Default.WindowPositionAnzeige != null)
            {
                Location = Settings.Default.WindowPositionAnzeige;
                WindowState = FormWindowState.Maximized;
            }
        }

        private void frmAnzeige_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmEingabe.counter--;
            StatusAnzeige = Anzeige.GESCHLOSSEN;
            Logger.LogToFile($"Anzeige wird geschlossen. Status: {StatusAnzeige}");
        }

        private void FrmAnzeige_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (SKCMessages.ShowFrage("Wollen Sie wirklich die Anzeige schließen? Die Anzeige kann nicht erneut geöffnet werden!", "Sicher verlassen?") == DialogResult.No)
                {
                    e.Cancel = true;
                }

                Settings.Default.WindowPositionAnzeige = Location;
                Settings.Default.Save();
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError($"Fehler bei Schließen der Anzeige aufgetreten. {e1.Message}");
                Logger.LogToFile($"Fehler bei Schließen der Anzeige aufgetreten: {e1.Message} {e1.StackTrace}");
            }
        }

        public void SendeSpieldatenAnAnzeige(SpielDTO spielDTO)
        {
            try
            {
                dto = spielDTO;
                LadeDatenInControls();
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError($"Fehler beim Senden der Daten an Spielanzeige aufgetreten. {e1.Message}");
                Logger.LogToFile($"Fehler beim Senden der Daten an Spielanzeige aufgetreten: {e1.Message} {e1.StackTrace}");
            }
        }

        private void TxtDErgebnisdifferenz_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                if (txt.Text.Trim().StartsWith("+") && txt.Text.Trim().EndsWith("+"))
                {
                    txt.BackColor = Color.LightBlue;
                    return;
                }
                if (txt.Text.Trim().StartsWith("+") || txt.BackColor.Equals(Color.Tomato))
                {
                    txt.BackColor = Color.LightGreen;
                    return;
                }
                if (txt.Text.Trim().StartsWith("-") || txt.BackColor.Equals(Color.LightGreen))
                {
                    txt.BackColor = Color.Tomato;
                    return;
                }
            }
        }
    }
}
