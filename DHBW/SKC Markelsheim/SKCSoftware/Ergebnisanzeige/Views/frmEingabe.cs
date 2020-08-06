using Ergebnisanzeige.Enums;
using Ergebnisanzeige.OwnForms;
using Ergebnisanzeige.Ressourcen;
using Ergebnisanzeige.Tools;
using SKCDLL.Entities.Models;
using SKCDLL.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ergebnisanzeige.Views
{
    public partial class frmEingabe : Form
    {
        private frmAnzeige _anzeige;
        private Partie _partie;
        private string[] _spielerliste;
        //private EingabeViewmodel _vm;
      
        public frmEingabe()
        {
            InitializeComponent();
            Text += Application.ProductVersion;
            Logger.LogToFile("Initialisiere Eingabe.");
            Logger.LogToFile("Anwendungsversion: v" + Application.ProductVersion);
            var spiel = new Partie();
            //_vm = new EingabeViewmodel(spiel);
            //TODO
            //cboMannschaftsbezeichnung.DataBindings.Add("Text", _vm, "SKCMarkelsheimName", true, DataSourceUpdateMode.OnPropertyChanged);
            //DataBindings.Add("Text", txtSKC1V1, "SKC1V1", true, DataSourceUpdateMode.OnPropertyChanged);
            
            //Temporär, damit die Controls nicht in der Anwendung auftauchen
            tabControlEingabe.TabPages.Remove(tabAuswechsel);
            lblSKCSpieler7.Visible = false;
            lblSKCSpieler8.Visible = false;
            lblSKCSpieler9.Visible = false;
            cboSKCSpieler7.Visible = false;
            cboSKCSpieler8.Visible = false;
            cboSKCSpieler9.Visible = false;
            lblGastSpieler7.Visible = false;
            lblGastSpieler8.Visible = false;
            lblGastSpieler9.Visible = false;
            txtGastSpieler7.Visible = false;
            txtGastSpieler8.Visible = false;
            txtGastSpieler9.Visible = false;

            try
            {
                _spielerliste = Spielerliste.HoleSpielerAusTextFile();
            }
            catch (Exception e1) 
            {
                SKCMessages.ShowError(e1, "Quelle für Spielerliste nicht vorhanden!" + e1.Message);
                Logger.LogToFile($"Fehler in Abruf der Spielerliste aufgetaucht: {e1.Message} {e1.StackTrace}");
            }


            if (_spielerliste != null)
            {      
                ComboBinding.BindeSpielerListeAnKomboBoxen(cboSKCSpieler1, _spielerliste);
                ComboBinding.BindeSpielerListeAnKomboBoxen(cboSKCSpieler2, _spielerliste);
                ComboBinding.BindeSpielerListeAnKomboBoxen(cboSKCSpieler3, _spielerliste);
                ComboBinding.BindeSpielerListeAnKomboBoxen(cboSKCSpieler4, _spielerliste);
                ComboBinding.BindeSpielerListeAnKomboBoxen(cboSKCSpieler5, _spielerliste);
                ComboBinding.BindeSpielerListeAnKomboBoxen(cboSKCSpieler6, _spielerliste);
                ComboBinding.BindeSpielerListeAnKomboBoxen(cboSKCSpieler7, _spielerliste);
                ComboBinding.BindeSpielerListeAnKomboBoxen(cboSKCSpieler8, _spielerliste);
                ComboBinding.BindeSpielerListeAnKomboBoxen(cboSKCSpieler9, _spielerliste);
            }

            _partie = new Partie();
            _anzeige = new frmAnzeige();
           
            //Teste Logging...
            //throw new Exception("Teste Fehleremail");
            AktualisiereControls(0);
        }

        private void BtnAnzeigeOeffnen_Click(object sender, EventArgs e)
        {
            try
            {
                if (_anzeige.StatusAnzeige == Anzeige.OFFEN)
                {
                    SKCMessages.ShowInfo("Anzeige ist bereits geöffnet!");
                    return;
                }

                _anzeige.Show();               
                AktualisiereControls(0);
                gbAnzeige.Text = "Nicht mehr verfügbar!";
                btnAnzeigeOeffnen.Enabled = false;
                _anzeige.StatusAnzeige = Anzeige.OFFEN;
                Logger.LogToFile($"Anzeige wurde initalisiert. Status: {_anzeige.StatusAnzeige}");
                // Test Fehler
                //throw new Exception();
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, "Fehler beim Öffnen der Anzeige.");
                EMail.VersendeMailMitLog($"Automatisch als Mail versendet: {e1.Message}\n{e1.StackTrace}", "Fehler bei Öffnen der Anzeige.");
            }
        }

        private void FrmEingabe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult result = SKCMessages.ShowFrage("Wollen Sie wirklich die Anwendung schließen? Alle eingtragenen Daten gehen verloren!", "Sicher verlassen?");
                if (result == DialogResult.Yes)
                {
                    Logger.LogToFile("Anwendung wird geschlossen.");
                }
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, $"Fehler beim Schließen der Anwendung aufgetreten.");
                EMail.VersendeMailMitLog($"Automatisch als Mail versendet: Fehler beim Schließen der Anwendung aufgetreten. {e1.Message}\n{e1.StackTrace}", "Fehler in FrmEingabe_FormClosing");
            }
        }

        #region Eingabenprüfung
        private void EingabeInTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is TextBox txt)
                {
                    //Logger.LogToFile("Ist Textbox");
                    if (txt.Name.ToLower().Contains("fw"))
                    {
                        PruefeFehlwurfEingabenAufgrundDerQuelle(txt);
                    }
                    if (txt.Name.ToLower().Contains("v"))
                    {
                        PruefeVolleEingabenAufgrundDerQuelle(txt);
                    }
                    if (txt.Name.ToLower().Contains("abr"))
                    {
                        PruefeAbraeumenEingabenAufgrundDerQuelle(txt);
                    }
                }
                else
                {
                    SKCMessages.ShowError($"Aufruf nicht über eine Textbox! Sendertyp: {sender.GetType()}!");
                }
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, $"Fehler bei Erkennung des Steuerelements.");
                EMail.VersendeMailMitLog($"Automatisch als Mail versendet: {e1.Message}\n{e1.StackTrace}", "EingabeInTextbox_TextChanged Fehler");
            }          
        }

        private void PruefeAbraeumenEingabenAufgrundDerQuelle(TextBox txt)
        {
            Validierung.PruefeEingabenAbraeumen(txt);
            PruefeEingabenAufgrundDerQuelle(txt);
        }

        private void PruefeVolleEingabenAufgrundDerQuelle(TextBox txt)
        {
            Validierung.PruefeEingabenVolle(txt);
            PruefeEingabenAufgrundDerQuelle(txt);
        }

        private void PruefeFehlwurfEingabenAufgrundDerQuelle(TextBox txt)
        {
            Validierung.PruefeEingabenFehl(txt);
            PruefeEingabenAufgrundDerQuelle(txt);
        }

        private void PruefeEingabenAufgrundDerQuelle(TextBox txt)
        {
            string textboxName = txt.Name.ToLower();
            /*
             * Tag = 1: Volle
             * Tag = 2: Abräumen
             * Tag = 3: Fehl
             */
            switch (txt.Tag)
            {
                case "1":
                    if (textboxName.Contains("skc1"))
                    {
                        _partie.SpielerSKC1.SetzeVolle(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("gast1"))
                    {
                        _partie.SpielerGast1.SetzeVolle(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("skc2"))
                    {
                        _partie.SpielerSKC2.SetzeVolle(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("gast2"))
                    {
                        _partie.SpielerGast2.SetzeVolle(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("skc3"))
                    {
                        _partie.SpielerSKC3.SetzeVolle(txt);

                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("gast3"))
                    {
                        _partie.SpielerGast3.SetzeVolle(txt);

                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("skc4"))
                    {
                        _partie.SpielerSKC4.SetzeVolle(txt);

                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("gast4"))
                    {
                        _partie.SpielerGast4.SetzeVolle(txt);


                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("skc5"))
                    {
                        _partie.SpielerSKC5.SetzeVolle(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    if (textboxName.Contains("gast5"))
                    {
                        _partie.SpielerGast5.SetzeVolle(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    if (textboxName.Contains("skc6"))
                    {
                        _partie.SpielerSKC6.SetzeVolle(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    if (textboxName.Contains("gast6"))
                    {
                        _partie.SpielerGast6.SetzeVolle(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    break;
                case "2":
                    if (textboxName.Contains("skc1"))
                    {
                        _partie.SpielerSKC1.SetzeAbraeumen(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("gast1"))
                    {
                        _partie.SpielerGast1.SetzeAbraeumen(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("skc2"))
                    {
                        _partie.SpielerSKC2.SetzeAbraeumen(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("gast2"))
                    {
                        _partie.SpielerGast2.SetzeAbraeumen(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("skc3"))
                    {
                        _partie.SpielerSKC3.SetzeAbraeumen(txt);

                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("gast3"))
                    {
                        _partie.SpielerGast3.SetzeAbraeumen(txt);

                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("skc4"))
                    {
                        _partie.SpielerSKC4.SetzeAbraeumen(txt);

                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("gast4"))
                    {
                        _partie.SpielerGast4.SetzeAbraeumen(txt);

                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("skc5"))
                    {
                        _partie.SpielerSKC5.SetzeAbraeumen(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    if (textboxName.Contains("gast5"))
                    {
                        _partie.SpielerGast5.SetzeAbraeumen(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    if (textboxName.Contains("skc6"))
                    {
                        _partie.SpielerSKC6.SetzeAbraeumen(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    if (textboxName.Contains("gast6"))
                    {
                        _partie.SpielerGast6.SetzeAbraeumen(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    break;
                case "3":
                    if (textboxName.Contains("skc1"))
                    {
                        _partie.SpielerSKC1.SetzeFehl(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("gast1"))
                    {
                        _partie.SpielerGast1.SetzeFehl(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("skc2"))
                    {
                        _partie.SpielerSKC2.SetzeFehl(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("gast2"))
                    {
                        _partie.SpielerGast2.SetzeFehl(txt);

                        AktualisiereControls(1);
                        return;
                    }
                    if (textboxName.Contains("skc3"))
                    {
                        _partie.SpielerSKC3.SetzeFehl(txt);

                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("gast3"))
                    {
                        _partie.SpielerGast3.SetzeFehl(txt);

                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("skc4"))
                    {
                        _partie.SpielerSKC4.SetzeFehl(txt);

                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("gast4"))
                    {
                        _partie.SpielerGast4.SetzeFehl(txt);

                        AktualisiereControls(2);
                        return;
                    }
                    if (textboxName.Contains("skc5"))
                    {
                        _partie.SpielerSKC5.SetzeFehl(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    if (textboxName.Contains("gast5"))
                    {
                        _partie.SpielerGast5.SetzeFehl(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    if (textboxName.Contains("skc6"))
                    {
                        _partie.SpielerSKC6.SetzeFehl(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    if (textboxName.Contains("gast6"))
                    {
                        _partie.SpielerGast6.SetzeFehl(txt);

                        AktualisiereControls(3);
                        return;
                    }
                    break;
                default:
                    SKCMessages.ShowError("Keine Berechnungsoption für diese Eingaben gefunden. Fehler wird gespeichert...", "Keine Rechenmöglichkeit gefunden.");
                    Logger.LogToFile($@"frmEingabe/PruefeEingabenAufgrundDerQuelle konnte im Switch kein entsprechender case gefunden werden. \n Betreffendes Control: 
                                        {textboxName} (Inhalt: {txt.Text}). Tag = {txt.Tag}");
                    EMail.VersendeMailMitLog($@"Automatisch als Mail versendet: In frmEingabe/PruefeEingabenAufgrundDerQuelle konnte im Switch kein entsprechender case gefunden werden. 
                                                \n Betreffendes Control: {textboxName} (Inhalt: {txt.Text}). Tag = {txt.Tag}", "Kein switch-case gefunden");
                    AktualisiereControls(0);
                    break;
            }
        }

        #endregion

        #region Spielerauswahl Übertrag in Duelle
        private void SpielerAuswahl_TextOrIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is ComboBox cbo)
                {
                    string spielerNr = string.Empty;
                    try
                    {
                        spielerNr = cbo.Name.Substring(13);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    if (cbo.Name.EndsWith("1"))
                    {
                        _partie.SpielerSKC1.Name = cbo.Text;
                        Uebertragen.UebertrageText(_partie.SpielerSKC1.Name, txtSKC1Spieler, txtDrckSKC1Name);
                    }
                    if (cbo.Name.EndsWith("2"))
                    {
                        _partie.SpielerSKC2.Name = cbo.Text;
                        Uebertragen.UebertrageText(_partie.SpielerSKC2.Name, txtSKC2Spieler, txtDrckSKC2Name);
                    }
                    if (cbo.Name.EndsWith("3"))
                    {
                        _partie.SpielerSKC3.Name = cboSKCSpieler3.Text;
                        Uebertragen.UebertrageText(_partie.SpielerSKC3.Name, txtSKC3Spieler, txtDrckSKC3Name);
                    }
                    if (cbo.Name.EndsWith("4"))
                    {
                        _partie.SpielerSKC4.Name = cboSKCSpieler4.Text;
                        Uebertragen.UebertrageText(_partie.SpielerSKC4.Name, txtSKC4Spieler, txtDrckSKC4Name);
                    }
                    if (cbo.Name.EndsWith("5"))
                    {
                        _partie.SpielerSKC5.Name = cboSKCSpieler5.Text;
                        Uebertragen.UebertrageText(_partie.SpielerSKC5.Name, txtSKC5Spieler, txtDrckSKC5Name);
                    }
                    if (cbo.Name.EndsWith("6"))
                    {
                        _partie.SpielerSKC6.Name = cboSKCSpieler6.Text;
                        Uebertragen.UebertrageText(_partie.SpielerSKC6.Name, txtSKC6Spieler, txtDrckSKC6Name);
                    }

                    Logger.LogToFile($"SKC Spieler {spielerNr} {cbo.Text} wurde ausgewählt.");
                }
                if (sender is TextBox txt)
                {
                    if (txt.Name.EndsWith("1"))
                    {
                        _partie.SpielerGast1.Name = txt.Text.Trim();
                        Uebertragen.UebertrageText(_partie.SpielerGast1.Name, txtGast1Spieler, txtDrckGast1Name);
                    }
                    if (txt.Name.EndsWith("2"))
                    {
                        _partie.SpielerGast2.Name = txt.Text.Trim();
                        Uebertragen.UebertrageText(_partie.SpielerGast2.Name, txtGast2Spieler, txtDrckGast2Name);
                    }
                    if (txt.Name.EndsWith("3"))
                    {
                        _partie.SpielerGast3.Name = txt.Text.Trim();
                        Uebertragen.UebertrageText(_partie.SpielerGast3.Name, txtGast3Spieler, txtDrckGast3Name);
                    }
                    if (txt.Name.EndsWith("4"))
                    {
                        _partie.SpielerGast4.Name = txt.Text.Trim();
                        Uebertragen.UebertrageText(_partie.SpielerGast4.Name, txtGast4Spieler, txtDrckGast4Name);
                    }
                    if (txt.Name.EndsWith("5"))
                    {
                        _partie.SpielerGast5.Name = txt.Text.Trim();
                        Uebertragen.UebertrageText(_partie.SpielerGast5.Name, txtGast5Spieler, txtDrckGast5Name);
                    }
                    if (txt.Name.EndsWith("6"))
                    {
                        _partie.SpielerGast6.Name = txt.Text.Trim();
                        Uebertragen.UebertrageText(_partie.SpielerGast6.Name, txtGast6Spieler, txtDrckGast6Name);
                    }
                }

                AktualisiereControls();
            }
            catch (Exception e1)
            {
                Logger.LogToFile($"Fehler bei Spieler auswählen: {e1}");
                SKCMessages.ShowError($"Fehler bei Spielerauswahl aufgetreten. {e1.Message}");
            }
            
        }
     
        #endregion

        //Wenn ein Mannschaftsname eingegeben wurde, dann wird das Aussehen der Textbox modifiziert
        private void TxtGastName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtGastName.Text.Trim()) || txtGastName.Text.Trim() != "Gastmannschaft")
                {
                    txtGastName.BackColor = Color.White;
                    txtDrckGastName.Text = txtGastName.Text;
                    _partie.GastmannschaftName = txtGastName.Text.Trim();
                    AktualisiereControls();
                }
            }
            catch (Exception e1)
            {
                Logger.LogToFile($"Fehler bei Eingabe von Gastvereinsname");
                SKCMessages.ShowError(e1, $"Fehler bei Eingabe von Gastvereinsname aufgetreten.");                
            }           
        }

        private void CboMannschaftsbezeichnung_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is ComboBox cbo)
                {
                    string skcmarkelsheim = "SKC Markelsheim";
                    skcmarkelsheim += cbo.Text;
                    _partie.SKCMarkelsheimName = skcmarkelsheim;
                    AktualisiereControls();
                    Logger.LogToFile($"{skcmarkelsheim} als Mannschaft ausgewählt.");
                }
            }
            catch (Exception e1)
            {
                Logger.LogToFile($"Fehler bei Auswahl von Mannschaft");
                SKCMessages.ShowError(e1, $"Fehler beim Auswählen der Mannschaft aufgetreten.");
            }           
        }     

        private void MnuDrucken_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelExport export = new ExcelExport(_partie);
                export.ExportToExcel();
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, $"Fehler bei Export nach Excel aufgetreten.");
            }
        }

        private void FrmEingabe_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            LadeAutoCompletionSpielernamen();
        }

        private void LadeAutoCompletionSpielernamen()
        {
            var listeGespeicherteSpieler = Spielerliste.HoleAlleDatensaetze();
            var listeEingabeControls = Spielerliste.GetAll(this, typeof(TextBox));
            AutoCompleteStringCollection complete = new AutoCompleteStringCollection();
            complete.AddRange(listeGespeicherteSpieler.ToArray());
            foreach (var txt in listeEingabeControls)
            {
                if (txt is TextBox textBox)
                {
                    textBox.AutoCompleteCustomSource = complete;
                }
            }
        }

        private void FrmEingabe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ToolStripMenuItemExcelSpielberichtErzeugenUndAlsMailVersenden.PerformClick();
            }
            if (e.KeyCode == Keys.F4)
            {
                ToolStripMenuItemErzeugeSpielberichtExcel.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                ToolStripMenuItemEingabeAktualisieren.PerformClick();
            }
            if (e.KeyCode == Keys.F6)
            {
                ToolStripMenuItemDruckanzeigeAktualisieren.PerformClick();
            }
            if (e.KeyCode == Keys.F7)
            {
                ToolStripMenuItemEingabenZuruecksetzen.PerformClick();
            }
            if (e.KeyCode == Keys.F11)
            {
                btnNamenSpeichern.PerformClick();
            }
            
        }

        #region Toolstrip Menü
        private void ToolStripMenuItemExcelSpielberichtErzeugenUndAlsMailVersenden_Click(object sender, EventArgs e)
        {
            string empfaenger = string.Empty;
            try
            {
                frmInput input = new frmInput("Eingabe der Empfänger-Adresse", "E-Mail Empfänger");
                input.ShowDialog();
                if (input.DialogResult == DialogResult.Yes)
                {
                    empfaenger = input.GetInput();
                    ExcelExport excel = new ExcelExport(_partie, empfaenger);
                    excel.ExportToExcelUndVersendeMail();
                }
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, $"Beim Versenden eines Spielberichts an {empfaenger} ist ein Fehler aufgetreten.");
            }
        }

        private void ToolStripMenuItemEingabenZuruecksetzen_Click(object sender, EventArgs e)
        {
            try
            {
                if (SKCMessages.ShowFrage("Wollen Sie die Eingaben wirklich zurücksetzen?", "Eingaben wirklich zurücksetzen?") == DialogResult.Yes)
                {
                    Logger.LogToFile($"Setze Spiel zurück. Partie: {_partie.SKCMarkelsheimName} - {_partie.GastmannschaftName}");
                    //Erzeuge neues Spiel und überschreibe altes Spielobjekt
                    _partie = new Partie();
                    ResetEingaben();
                    AktualisiereControls(0);
                }
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, $"Fehler beim Zurücksetzen der Eingaben aufgetreten.");
            }
        }

        private void ToolStripMenuItemSpielberichteAnzeigen_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> listeColumns = new List<string>();
                listeColumns.AddRange(new string[3] { "Datum", "Spielbericht", "Dateipfad" });
                frmShowInDataGrid dataGrid = new frmShowInDataGrid(listeColumns, "Spielberichtsmanager");
                dataGrid.Show();
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, "Beim Anzeigen der Spielberichte ist ein Fehler aufgetreten.");
            }
        }

        private void ToolStripMenuItemEingabeAktualisieren_Click(object sender, EventArgs e)
        {
            try
            {
                AktualisiereControls();
            }
            catch (Exception e1)
            {
                Logger.LogToFile($"Fehler in Eingaben aktualisieren");
                SKCMessages.ShowError(e1, $"Fehler beim Aktualisieren der Steuerelemente aufgetaucht.");
            }
        }

        private void ToolStripMenuItemDruckanzeigeAktualisieren_Click(object sender, EventArgs e)
        {
            try
            {
                AktualisiereDruckControls();
            }
            catch (Exception e1)
            {
                Logger.LogToFile($"Fehler bei Aktualisierung der Druckanzeige aufgetreten");
                SKCMessages.ShowError(e1, $"Fehler bei Aktualisierung der Druckanzeige aufgetreten.");
            }
        }

        #endregion

        private void SetzeTeamDifferenz()
        {
            if (_partie.ErgebnisDifferenz > 0)
            {
                _partie.DifferenzText = $"+ {_partie.ErgebnisDifferenz} -";
            }
            if (_partie.ErgebnisDifferenz < 0)
            {
                _partie.DifferenzText = $"- {Math.Abs(_partie.ErgebnisDifferenz)} +";
            }
            if (_partie.ErgebnisDifferenz == 0)
            {
                _partie.DifferenzText = $"+ {_partie.ErgebnisDifferenz} +";
            }

            lblGesamtVergleich.Text = _partie.DifferenzText;
        }   

        /// <summary>
        /// Aktualisierung aller Controls
        /// </summary>
        public void AktualisiereControls()
        {
            AktualisiereControls(0);
        }

        /// <summary>
        /// Aktualisierung der Controls aufgrund der Stufe (Start = 1, Mittel = 2, Schluss = 3, Alle Controls = 0)
        /// </summary>
        /// <param name="berechnungsStufe"></param>
        public void AktualisiereControls(int berechnungsStufe)
        {
            try
            {
                _partie.AktualisiereSpiel();

                if (berechnungsStufe == 1 || berechnungsStufe == 0)
                {
                    //Duell 1
                    _partie.Duell1.VergebeSatzpunktAufgrundDerEingabe();

                    txtSKC1VG.Text = _partie.SpielerSKC1.Volle.ToString();
                    txtGast1VG.Text = _partie.SpielerGast1.Volle.ToString();
                    txtSKC1AbrG.Text = _partie.SpielerSKC1.Abraeumen.ToString();
                    txtGast1AbrG.Text = _partie.SpielerGast1.Abraeumen.ToString();
                    txtSKC1FWG.Text = _partie.SpielerSKC1.Fehl.ToString();
                    txtGast1FWG.Text = _partie.SpielerGast1.Fehl.ToString();

                    txtSKC1SG1.Text = _partie.SpielerSKC1.Satz1.GetValueOrDefault().ToString();
                    txtGast1SG1.Text = _partie.SpielerGast1.Satz1.GetValueOrDefault().ToString();
                    txtSKC1SG2.Text = _partie.SpielerSKC1.Satz2.GetValueOrDefault().ToString();
                    txtGast1SG2.Text = _partie.SpielerGast1.Satz2.GetValueOrDefault().ToString();
                    txtSKC1SG3.Text = _partie.SpielerSKC1.Satz3.GetValueOrDefault().ToString();
                    txtGast1SG3.Text = _partie.SpielerGast1.Satz3.GetValueOrDefault().ToString();
                    txtSKC1SG4.Text = _partie.SpielerSKC1.Satz4.GetValueOrDefault().ToString();
                    txtGast1SG4.Text = _partie.SpielerGast1.Satz4.GetValueOrDefault().ToString();

                    txtSKC1SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC1.Sp1);
                    txtGast1SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast1.Sp1);
                    txtSKC1SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC1.Sp2);
                    txtGast1SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast1.Sp2);
                    txtSKC1SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC1.Sp3);
                    txtGast1SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast1.Sp3);
                    txtSKC1SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC1.Sp4);
                    txtGast1SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast1.Sp4);

                    txtSKC1G.Text = _partie.SpielerSKC1.Gesamt.ToString();
                    txtGast1G.Text = _partie.SpielerGast1.Gesamt.ToString();

                    txtSKC1MP.Text = _partie.SpielerSKC1.MannschaftsPunkt.ToString();
                    txtGast1MP.Text = _partie.SpielerGast1.MannschaftsPunkt.ToString();

                    //Duell 2
                    _partie.Duell2.VergebeSatzpunktAufgrundDerEingabe();

                    txtSKC2VG.Text = _partie.SpielerSKC2.Volle.ToString();
                    txtGast2VG.Text = _partie.SpielerGast2.Volle.ToString();
                    txtSKC2AbrG.Text = _partie.SpielerSKC2.Abraeumen.ToString();
                    txtGast2AbrG.Text = _partie.SpielerGast2.Abraeumen.ToString();
                    txtSKC2FWG.Text = _partie.SpielerSKC2.Fehl.ToString();
                    txtGast2FWG.Text = _partie.SpielerGast2.Fehl.ToString();

                    txtSKC2SG1.Text = _partie.SpielerSKC2.Satz1.GetValueOrDefault().ToString();
                    txtGast2SG1.Text = _partie.SpielerGast2.Satz1.GetValueOrDefault().ToString();
                    txtSKC2SG2.Text = _partie.SpielerSKC2.Satz2.GetValueOrDefault().ToString();
                    txtGast2SG2.Text = _partie.SpielerGast2.Satz2.GetValueOrDefault().ToString();
                    txtSKC2SG3.Text = _partie.SpielerSKC2.Satz3.GetValueOrDefault().ToString();
                    txtGast2SG3.Text = _partie.SpielerGast2.Satz3.GetValueOrDefault().ToString();
                    txtSKC2SG4.Text = _partie.SpielerSKC2.Satz4.GetValueOrDefault().ToString();
                    txtGast2SG4.Text = _partie.SpielerGast2.Satz4.GetValueOrDefault().ToString();

                    txtSKC2SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC2.Sp1);
                    txtGast2SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast2.Sp1);
                    txtSKC2SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC2.Sp2);
                    txtGast2SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast2.Sp2);
                    txtSKC2SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC2.Sp3);
                    txtGast2SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast2.Sp3);
                    txtSKC2SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC2.Sp4);
                    txtGast2SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast2.Sp4);

                    txtSKC2G.Text = _partie.SpielerSKC2.Gesamt.ToString();
                    txtGast2G.Text = _partie.SpielerGast2.Gesamt.ToString();

                    txtSKC2MP.Text = _partie.SpielerSKC2.MannschaftsPunkt.ToString();
                    txtGast2MP.Text = _partie.SpielerGast2.MannschaftsPunkt.ToString();
                }
                if (berechnungsStufe == 2 || berechnungsStufe == 0)
                {
                    //Duell 3
                    _partie.Duell3.VergebeSatzpunktAufgrundDerEingabe();

                    txtSKC3VG.Text = _partie.SpielerSKC3.Volle.ToString();
                    txtGast3VG.Text = _partie.SpielerGast3.Volle.ToString();
                    txtSKC3AbrG.Text = _partie.SpielerSKC3.Abraeumen.ToString();
                    txtGast3AbrG.Text = _partie.SpielerGast3.Abraeumen.ToString();
                    txtSKC3FWG.Text = _partie.SpielerSKC3.Fehl.ToString();
                    txtGast3FWG.Text = _partie.SpielerGast3.Fehl.ToString();

                    txtSKC3SG1.Text = _partie.SpielerSKC3.Satz1.GetValueOrDefault().ToString();
                    txtGast3SG1.Text = _partie.SpielerGast3.Satz1.GetValueOrDefault().ToString();
                    txtSKC3SG2.Text = _partie.SpielerSKC3.Satz2.GetValueOrDefault().ToString();
                    txtGast3SG2.Text = _partie.SpielerGast3.Satz2.GetValueOrDefault().ToString();
                    txtSKC3SG3.Text = _partie.SpielerSKC3.Satz3.GetValueOrDefault().ToString();
                    txtGast3SG3.Text = _partie.SpielerGast3.Satz3.GetValueOrDefault().ToString();
                    txtSKC3SG4.Text = _partie.SpielerSKC3.Satz4.GetValueOrDefault().ToString();
                    txtGast3SG4.Text = _partie.SpielerGast3.Satz4.GetValueOrDefault().ToString();

                    txtSKC3SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC3.Sp1);
                    txtGast3SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast3.Sp1);
                    txtSKC3SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC3.Sp2);
                    txtGast3SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast3.Sp2);
                    txtSKC3SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC3.Sp3);
                    txtGast3SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast3.Sp3);
                    txtSKC3SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC3.Sp4);
                    txtGast3SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast3.Sp4);

                    txtSKC3G.Text = _partie.SpielerSKC3.Gesamt.ToString();
                    txtGast3G.Text = _partie.SpielerGast3.Gesamt.ToString();

                    txtSKC3MP.Text = _partie.SpielerSKC3.MannschaftsPunkt.ToString();
                    txtGast3MP.Text = _partie.SpielerGast3.MannschaftsPunkt.ToString();

                    //Duell 4
                    _partie.Duell4.VergebeSatzpunktAufgrundDerEingabe();

                    txtSKC4VG.Text = _partie.SpielerSKC4.Volle.ToString();
                    txtGast4VG.Text = _partie.SpielerGast4.Volle.ToString();
                    txtSKC4AbrG.Text = _partie.SpielerSKC4.Abraeumen.ToString();
                    txtGast4AbrG.Text = _partie.SpielerGast4.Abraeumen.ToString();
                    txtSKC4FWG.Text = _partie.SpielerSKC4.Fehl.ToString();
                    txtGast4FWG.Text = _partie.SpielerGast4.Fehl.ToString();

                    txtSKC4SG1.Text = _partie.SpielerSKC4.Satz1.GetValueOrDefault().ToString();
                    txtGast4SG1.Text = _partie.SpielerGast4.Satz1.GetValueOrDefault().ToString();
                    txtSKC4SG2.Text = _partie.SpielerSKC4.Satz2.GetValueOrDefault().ToString();
                    txtGast4SG2.Text = _partie.SpielerGast4.Satz2.GetValueOrDefault().ToString();
                    txtSKC4SG3.Text = _partie.SpielerSKC4.Satz3.GetValueOrDefault().ToString();
                    txtGast4SG3.Text = _partie.SpielerGast4.Satz3.GetValueOrDefault().ToString();
                    txtSKC4SG4.Text = _partie.SpielerSKC4.Satz4.GetValueOrDefault().ToString();
                    txtGast4SG4.Text = _partie.SpielerGast4.Satz4.GetValueOrDefault().ToString();

                    txtSKC4SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC4.Sp1);
                    txtGast4SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast4.Sp1);
                    txtSKC4SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC4.Sp2);
                    txtGast4SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast4.Sp2);
                    txtSKC4SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC4.Sp3);
                    txtGast4SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast4.Sp3);
                    txtSKC4SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC4.Sp4);
                    txtGast4SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast4.Sp4);

                    txtSKC4G.Text = _partie.SpielerSKC4.Gesamt.ToString();
                    txtGast4G.Text = _partie.SpielerGast4.Gesamt.ToString();

                    txtSKC4MP.Text = _partie.SpielerSKC4.MannschaftsPunkt.ToString();
                    txtGast4MP.Text = _partie.SpielerGast4.MannschaftsPunkt.ToString();
                }
                if (berechnungsStufe == 3 || berechnungsStufe == 0)
                {
                    //Duell 5
                    _partie.Duell5.VergebeSatzpunktAufgrundDerEingabe();

                    txtSKC5VG.Text = _partie.SpielerSKC5.Volle.ToString();
                    txtGast5VG.Text = _partie.SpielerGast5.Volle.ToString();
                    txtSKC5AbrG.Text = _partie.SpielerSKC5.Abraeumen.ToString();
                    txtGast5AbrG.Text = _partie.SpielerGast5.Abraeumen.ToString();
                    txtSKC5FWG.Text = _partie.SpielerSKC5.Fehl.ToString();
                    txtGast5FWG.Text = _partie.SpielerGast5.Fehl.ToString();

                    txtSKC5SG1.Text = _partie.SpielerSKC5.Satz1.GetValueOrDefault().ToString();
                    txtGast5SG1.Text = _partie.SpielerGast5.Satz1.GetValueOrDefault().ToString();
                    txtSKC5SG2.Text = _partie.SpielerSKC5.Satz2.GetValueOrDefault().ToString();
                    txtGast5SG2.Text = _partie.SpielerGast5.Satz2.GetValueOrDefault().ToString();
                    txtSKC5SG3.Text = _partie.SpielerSKC5.Satz3.GetValueOrDefault().ToString();
                    txtGast5SG3.Text = _partie.SpielerGast5.Satz3.GetValueOrDefault().ToString();
                    txtSKC5SG4.Text = _partie.SpielerSKC5.Satz4.GetValueOrDefault().ToString();
                    txtGast5SG4.Text = _partie.SpielerGast5.Satz4.GetValueOrDefault().ToString();

                    txtSKC5SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC5.Sp1);
                    txtGast5SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast5.Sp1);
                    txtSKC5SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC5.Sp2);
                    txtGast5SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast5.Sp2);
                    txtSKC5SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC5.Sp3);
                    txtGast5SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast5.Sp3);
                    txtSKC5SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC5.Sp4);
                    txtGast5SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast5.Sp4);

                    txtSKC5G.Text = _partie.SpielerSKC5.Gesamt.ToString();
                    txtGast5G.Text = _partie.SpielerGast5.Gesamt.ToString();

                    txtSKC5MP.Text = _partie.SpielerSKC5.MannschaftsPunkt.ToString();
                    txtGast5MP.Text = _partie.SpielerGast5.MannschaftsPunkt.ToString();

                    //Duell 6
                    _partie.Duell6.VergebeSatzpunktAufgrundDerEingabe();

                    txtSKC6VG.Text = _partie.SpielerSKC6.Volle.ToString();
                    txtGast6VG.Text = _partie.SpielerGast6.Volle.ToString();
                    txtSKC6AbrG.Text = _partie.SpielerSKC6.Abraeumen.ToString();
                    txtGast6AbrG.Text = _partie.SpielerGast6.Abraeumen.ToString();
                    txtSKC6FWG.Text = _partie.SpielerSKC6.Fehl.ToString();
                    txtGast6FWG.Text = _partie.SpielerGast6.Fehl.ToString();

                    txtSKC6SG1.Text = _partie.SpielerSKC6.Satz1.GetValueOrDefault().ToString();
                    txtGast6SG1.Text = _partie.SpielerGast6.Satz1.GetValueOrDefault().ToString();
                    txtSKC6SG2.Text = _partie.SpielerSKC6.Satz2.GetValueOrDefault().ToString();
                    txtGast6SG2.Text = _partie.SpielerGast6.Satz2.GetValueOrDefault().ToString();
                    txtSKC6SG3.Text = _partie.SpielerSKC6.Satz3.GetValueOrDefault().ToString();
                    txtGast6SG3.Text = _partie.SpielerGast6.Satz3.GetValueOrDefault().ToString();
                    txtSKC6SG4.Text = _partie.SpielerSKC6.Satz4.GetValueOrDefault().ToString();
                    txtGast6SG4.Text = _partie.SpielerGast6.Satz4.GetValueOrDefault().ToString();

                    txtSKC6SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC6.Sp1);
                    txtGast6SP1.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast6.Sp1);
                    txtSKC6SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC6.Sp2);
                    txtGast6SP2.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast6.Sp2);
                    txtSKC6SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC6.Sp3);
                    txtGast6SP3.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast6.Sp3);
                    txtSKC6SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerSKC6.Sp4);
                    txtGast6SP4.Text = Uebertragen.FormatiereKommazahl(_partie.SpielerGast6.Sp4);

                    txtSKC6G.Text = _partie.SpielerSKC6.Gesamt.ToString();
                    txtGast6G.Text = _partie.SpielerGast6.Gesamt.ToString();

                    txtSKC6MP.Text = _partie.SpielerSKC6.MannschaftsPunkt.ToString();
                    txtGast6MP.Text = _partie.SpielerGast6.MannschaftsPunkt.ToString();
                }

                AktualisiereDruckControls();
                AktualisiereAnzeige();
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError($"Fehler bei Aktualisierung der Eingaben aufgetreten. {e1.Message}");               
                Logger.LogToFile($"Fehler bei Aktualisierung der Eingaben aufgetreten: {e1.Message} {e1.StackTrace}");
            }            
        }

        private void AktualisiereAnzeige()
        {
            _anzeige.SendeSpieldatenAnAnzeige(_partie);
        }

        private void AktualisiereDruckControls()
        {     
            _partie.AktualisiereSpiel();
            SetzeTeamDifferenz();

            txtDrckSKC.Text = _partie.SKCMarkelsheimName;
            txtDrckGastName.Text = _partie.GastmannschaftName;

            txtDrckSKC1Ges.Text = _partie.SpielerSKC1.Gesamt.ToString();
            txtDrckSKC2Ges.Text = _partie.SpielerSKC2.Gesamt.ToString();
            txtDrckSKC3Ges.Text = _partie.SpielerSKC3.Gesamt.ToString();
            txtDrckSKC4Ges.Text = _partie.SpielerSKC4.Gesamt.ToString();
            txtDrckSKC5Ges.Text = _partie.SpielerSKC5.Gesamt.ToString();
            txtDrckSKC6Ges.Text = _partie.SpielerSKC6.Gesamt.ToString();
            txtDrckGast1Ges.Text = _partie.SpielerGast1.Gesamt.ToString();
            txtDrckGast2Ges.Text = _partie.SpielerGast2.Gesamt.ToString();
            txtDrckGast3Ges.Text = _partie.SpielerGast3.Gesamt.ToString();
            txtDrckGast4Ges.Text = _partie.SpielerGast4.Gesamt.ToString();
            txtDrckGast5Ges.Text = _partie.SpielerGast5.Gesamt.ToString();
            txtDrckGast6Ges.Text = _partie.SpielerGast6.Gesamt.ToString();

            txtDrckSKC1MP.Text = _partie.SpielerSKC1.MannschaftsPunkt.ToString();
            txtDrckSKC2MP.Text = _partie.SpielerSKC2.MannschaftsPunkt.ToString();
            txtDrckSKC3MP.Text = _partie.SpielerSKC3.MannschaftsPunkt.ToString();
            txtDrckSKC4MP.Text = _partie.SpielerSKC4.MannschaftsPunkt.ToString();
            txtDrckSKC5MP.Text = _partie.SpielerSKC5.MannschaftsPunkt.ToString();
            txtDrckSKC6MP.Text = _partie.SpielerSKC6.MannschaftsPunkt.ToString();
            txtDrckGast1MP.Text = _partie.SpielerGast1.MannschaftsPunkt.ToString();
            txtDrckGast2MP.Text = _partie.SpielerGast2.MannschaftsPunkt.ToString();
            txtDrckGast3MP.Text = _partie.SpielerGast3.MannschaftsPunkt.ToString();
            txtDrckGast4MP.Text = _partie.SpielerGast4.MannschaftsPunkt.ToString();
            txtDrckGast5MP.Text = _partie.SpielerGast5.MannschaftsPunkt.ToString();
            txtDrckGast6MP.Text = _partie.SpielerGast6.MannschaftsPunkt.ToString();

            txtDrckSKC1SP.Text = _partie.SpielerSKC1.SatzPunkte.ToString();
            txtDrckSKC2SP.Text = _partie.SpielerSKC2.SatzPunkte.ToString();
            txtDrckSKC3SP.Text = _partie.SpielerSKC3.SatzPunkte.ToString();
            txtDrckSKC4SP.Text = _partie.SpielerSKC4.SatzPunkte.ToString();
            txtDrckSKC5SP.Text = _partie.SpielerSKC5.SatzPunkte.ToString();
            txtDrckSKC6SP.Text = _partie.SpielerSKC6.SatzPunkte.ToString();
            txtDrckGast1SP.Text = _partie.SpielerGast1.SatzPunkte.ToString();
            txtDrckGast2SP.Text = _partie.SpielerGast2.SatzPunkte.ToString();
            txtDrckGast3SP.Text = _partie.SpielerGast3.SatzPunkte.ToString();
            txtDrckGast4SP.Text = _partie.SpielerGast4.SatzPunkte.ToString();
            txtDrckGast5SP.Text = _partie.SpielerGast5.SatzPunkte.ToString();
            txtDrckGast6SP.Text = _partie.SpielerGast6.SatzPunkte.ToString();

            txtDrckGastMPGes.Text = Uebertragen.FormatiereKommazahl(_partie.MannschaftspunkteGast);
            txtDrckSKCMPGes.Text = Uebertragen.FormatiereKommazahl(_partie.MannschaftspunkteHeim);
            txtDrckHeimGesamt.Text = _partie.MannschaftsErgebnisHeim.ToString();
            txtDrckGastGesamt.Text = _partie.MannschaftsErgebnisGast.ToString();
            txtDrckHeimSPGesamt.Text = Uebertragen.FormatiereKommazahl(_partie.SatzpunkteHeim);
            txtDrckGastSPGesamt.Text = Uebertragen.FormatiereKommazahl(_partie.SatzpunkteGast);
        }

        private void TxtBemerkungen_TextChanged(object sender, EventArgs e)
        {
            if (txtBemerkungen.Text.Trim().Length > 55)
            {
                SKCMessages.ShowInfo("Bemerkungen über 55 Zeichen werden unter Umständen im Spielbericht abgeschnitten!");
            }

            _partie.Bemerkungen = txtBemerkungen.Text.Trim();
        }

        private void ResetEingaben()
        {
            txtSKC1V1.Text = string.Empty;
            txtSKC1V2.Text = string.Empty;
            txtSKC1V3.Text = string.Empty;
            txtSKC1V4.Text = string.Empty;
            txtSKC1Abr1.Text = string.Empty;
            txtSKC1Abr2.Text = string.Empty;
            txtSKC1Abr3.Text = string.Empty;
            txtSKC1Abr4.Text = string.Empty;
            txtSKC1FW1.Text = string.Empty;
            txtSKC1FW2.Text = string.Empty;
            txtSKC1FW3.Text = string.Empty;
            txtSKC1FW4.Text = string.Empty;

            txtSKC2V1.Text = string.Empty;
            txtSKC2V2.Text = string.Empty;
            txtSKC2V3.Text = string.Empty;
            txtSKC2V4.Text = string.Empty;
            txtSKC2Abr1.Text = string.Empty;
            txtSKC2Abr2.Text = string.Empty;
            txtSKC2Abr3.Text = string.Empty;
            txtSKC2Abr4.Text = string.Empty;
            txtSKC2FW1.Text = string.Empty;
            txtSKC2FW2.Text = string.Empty;
            txtSKC2FW3.Text = string.Empty;
            txtSKC2FW4.Text = string.Empty;

            txtSKC3V1.Text = string.Empty;
            txtSKC3V2.Text = string.Empty;
            txtSKC3V3.Text = string.Empty;
            txtSKC3V4.Text = string.Empty;
            txtSKC3Abr1.Text = string.Empty;
            txtSKC3Abr2.Text = string.Empty;
            txtSKC3Abr3.Text = string.Empty;
            txtSKC3Abr4.Text = string.Empty;
            txtSKC3FW1.Text = string.Empty;
            txtSKC3FW2.Text = string.Empty;
            txtSKC3FW3.Text = string.Empty;
            txtSKC3FW4.Text = string.Empty;

            txtSKC4V1.Text = string.Empty;
            txtSKC4V2.Text = string.Empty;
            txtSKC4V3.Text = string.Empty;
            txtSKC4V4.Text = string.Empty;
            txtSKC4Abr1.Text = string.Empty;
            txtSKC4Abr2.Text = string.Empty;
            txtSKC4Abr3.Text = string.Empty;
            txtSKC4Abr4.Text = string.Empty;
            txtSKC4FW1.Text = string.Empty;
            txtSKC4FW2.Text = string.Empty;
            txtSKC4FW3.Text = string.Empty;
            txtSKC4FW4.Text = string.Empty;

            txtSKC5V1.Text = string.Empty;
            txtSKC5V2.Text = string.Empty;
            txtSKC5V3.Text = string.Empty;
            txtSKC5V4.Text = string.Empty;
            txtSKC5Abr1.Text = string.Empty;
            txtSKC5Abr2.Text = string.Empty;
            txtSKC5Abr3.Text = string.Empty;
            txtSKC5Abr4.Text = string.Empty;
            txtSKC5FW1.Text = string.Empty;
            txtSKC5FW2.Text = string.Empty;
            txtSKC5FW3.Text = string.Empty;
            txtSKC5FW4.Text = string.Empty;

            txtSKC6V1.Text = string.Empty;
            txtSKC6V2.Text = string.Empty;
            txtSKC6V3.Text = string.Empty;
            txtSKC6V4.Text = string.Empty;
            txtSKC6Abr1.Text = string.Empty;
            txtSKC6Abr2.Text = string.Empty;
            txtSKC6Abr3.Text = string.Empty;
            txtSKC6Abr4.Text = string.Empty;
            txtSKC6FW1.Text = string.Empty;
            txtSKC6FW2.Text = string.Empty;
            txtSKC6FW3.Text = string.Empty;
            txtSKC6FW4.Text = string.Empty;

            txtGast1V1.Text = string.Empty;
            txtGast1V2.Text = string.Empty;
            txtGast1V3.Text = string.Empty;
            txtGast1V4.Text = string.Empty;
            txtGast1Abr1.Text = string.Empty;
            txtGast1Abr2.Text = string.Empty;
            txtGast1Abr3.Text = string.Empty;
            txtGast1Abr4.Text = string.Empty;
            txtGast1FW1.Text = string.Empty;
            txtGast1FW2.Text = string.Empty;
            txtGast1FW3.Text = string.Empty;
            txtGast1FW4.Text = string.Empty;

            txtGast2V1.Text = string.Empty;
            txtGast2V2.Text = string.Empty;
            txtGast2V3.Text = string.Empty;
            txtGast2V4.Text = string.Empty;
            txtGast2Abr1.Text = string.Empty;
            txtGast2Abr2.Text = string.Empty;
            txtGast2Abr3.Text = string.Empty;
            txtGast2Abr4.Text = string.Empty;
            txtGast2FW1.Text = string.Empty;
            txtGast2FW2.Text = string.Empty;
            txtGast2FW3.Text = string.Empty;
            txtGast2FW4.Text = string.Empty;

            txtGast3V1.Text = string.Empty;
            txtGast3V2.Text = string.Empty;
            txtGast3V3.Text = string.Empty;
            txtGast3V4.Text = string.Empty;
            txtGast3Abr1.Text = string.Empty;
            txtGast3Abr2.Text = string.Empty;
            txtGast3Abr3.Text = string.Empty;
            txtGast3Abr4.Text = string.Empty;
            txtGast3FW1.Text = string.Empty;
            txtGast3FW2.Text = string.Empty;
            txtGast3FW3.Text = string.Empty;
            txtGast3FW4.Text = string.Empty;

            txtGast4V1.Text = string.Empty;
            txtGast4V2.Text = string.Empty;
            txtGast4V3.Text = string.Empty;
            txtGast4V4.Text = string.Empty;
            txtGast4Abr1.Text = string.Empty;
            txtGast4Abr2.Text = string.Empty;
            txtGast4Abr3.Text = string.Empty;
            txtGast4Abr4.Text = string.Empty;
            txtGast4FW1.Text = string.Empty;
            txtGast4FW2.Text = string.Empty;
            txtGast4FW3.Text = string.Empty;
            txtGast4FW4.Text = string.Empty;

            txtGast5V1.Text = string.Empty;
            txtGast5V2.Text = string.Empty;
            txtGast5V3.Text = string.Empty;
            txtGast5V4.Text = string.Empty;
            txtGast5Abr1.Text = string.Empty;
            txtGast5Abr2.Text = string.Empty;
            txtGast5Abr3.Text = string.Empty;
            txtGast5Abr4.Text = string.Empty;
            txtGast5FW1.Text = string.Empty;
            txtGast5FW2.Text = string.Empty;
            txtGast5FW3.Text = string.Empty;
            txtGast5FW4.Text = string.Empty;

            txtGast6V1.Text = string.Empty;
            txtGast6V2.Text = string.Empty;
            txtGast6V3.Text = string.Empty;
            txtGast6V4.Text = string.Empty;
            txtGast6Abr1.Text = string.Empty;
            txtGast6Abr2.Text = string.Empty;
            txtGast6Abr3.Text = string.Empty;
            txtGast6Abr4.Text = string.Empty;
            txtGast6FW1.Text = string.Empty;
            txtGast6FW2.Text = string.Empty;
            txtGast6FW3.Text = string.Empty;
            txtGast6FW4.Text = string.Empty;

            txtEingabeGast1.Text = string.Empty;
            txtEingabeGast2.Text = string.Empty;
            txtEingabeGast3.Text = string.Empty;
            txtEingabeGast4.Text = string.Empty;
            txtEingabeGast5.Text = string.Empty;
            txtEingabeGast6.Text = string.Empty;
            txtGastName.Text = "Gastmannschaft";
            cboMannschaftsbezeichnung.SelectedIndex = -1;

            cboSKCSpieler1.SelectedIndex = -1;
            cboSKCSpieler2.SelectedIndex = -1;
            cboSKCSpieler3.SelectedIndex = -1;
            cboSKCSpieler4.SelectedIndex = -1;
            cboSKCSpieler5.SelectedIndex = -1;
            cboSKCSpieler6.SelectedIndex = -1;

            txtSKC1Spieler.Text = string.Empty;
            txtSKC2Spieler.Text = string.Empty;
            txtSKC3Spieler.Text = string.Empty;
            txtSKC4Spieler.Text = string.Empty;
            txtSKC5Spieler.Text = string.Empty;
            txtSKC6Spieler.Text = string.Empty;

            txtGast1Spieler.Text = string.Empty;
            txtGast2Spieler.Text = string.Empty;
            txtGast3Spieler.Text = string.Empty;
            txtGast4Spieler.Text = string.Empty;
            txtGast5Spieler.Text = string.Empty;
            txtGast6Spieler.Text = string.Empty;

            txtDrckSKC1Name.Text = string.Empty;
            txtDrckSKC2Name.Text = string.Empty;
            txtDrckSKC3Name.Text = string.Empty;
            txtDrckSKC4Name.Text = string.Empty;
            txtDrckSKC5Name.Text = string.Empty;
            txtDrckSKC6Name.Text = string.Empty;

            txtDrckGast1Name.Text = string.Empty;
            txtDrckGast2Name.Text = string.Empty;
            txtDrckGast3Name.Text = string.Empty;
            txtDrckGast4Name.Text = string.Empty;
            txtDrckGast5Name.Text = string.Empty;
            txtDrckGast6Name.Text = string.Empty;

            Logger.LogToFile("Controls geleert");
        }

        private void TabWkbvAktiv_Enter(object sender, EventArgs e)
        {
            try
            {
                tabControlEingabe.SelectedTab = tabAnfang;
                System.Diagnostics.Process.Start("www.wkbv-aktiv.de/saison/liga");
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, $"Fehler beim Öffnen vom WKBV-Aktiv aufgetreten.");
            }
        }

        private void ToolStripMenuItemLogAdmin_Click(object sender, EventArgs e)
        {
            var adminPW = "AdminPW";
            frmInput pw = new frmInput("Passwort eingeben", "Passwort");
            pw.Passwort = true;
            pw.ShowDialog();
            if (pw.DialogResult == DialogResult.Yes && pw.GetInput().Equals(adminPW))
            {
                System.Diagnostics.Process.Start(Logger.LogPath);
            }
            else if (pw.DialogResult == DialogResult.Yes && !pw.GetInput().Equals(adminPW))
            {
                SKCMessages.ShowError("Das Passwort ist nicht korrekt", "Falsches Passwort");
            }
        }

        private void BtnNamenSpeichern_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button btn)
                {
                    Spielerliste.SpeichereNeueSpielernamen(this);
                    LadeAutoCompletionSpielernamen();
                }
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, "Es ist ein Fehler beim Speichern der Spieler aufgetreten.");
            }
        }
    }
}
