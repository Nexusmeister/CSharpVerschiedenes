using System.Windows.Forms;

namespace Ergebnisanzeige.Tools
{
    public class Validierung
    {
        public Validierung()
        {
            Berechnung berechnung = new Berechnung();
        }

        /// <summary>
        /// Prüfung der Vollen-Eingabe, um falsche Eingaben zu verhindern
        /// </summary>
        /// <param name="textVolle"></param>
        public void PruefeEingabenVolle(TextBox textVolle)
        {
            if (!PruefeEingabeAufZahl(textVolle))
            {
                textVolle.Text = "";
            }
            if (int.TryParse(textVolle.Text, out int parsedValue))
            {
                if (parsedValue > 135)
                {
                    SKCMessages.ShowInfo("Volle kann nicht größer 135 sein!", "Volle zu groß!");
                    textVolle.Text = "";
                }
            }
        }

        /// <summary>
        /// Prüfung der Abräumen-Eingabe, um falsche Eingaben zu verhindern
        /// </summary>
        /// <param name="textAbr"></param>
        public void PruefeEingabenAbraeumen(TextBox textAbr)
        {
            if (!PruefeEingabeAufZahl(textAbr))
            {
                textAbr.Text = "";
            }
            if (int.TryParse(textAbr.Text, out int parsedValue))
            {
                if (parsedValue > 135)
                {
                    SKCMessages.ShowInfo("Abräumen kann nicht größer 135 sein!", "Abräumen zu groß!");
                    textAbr.Text = "";
                }
            }
        }

        /// <summary>
        /// Prüfung der Fehl-Eingaben, um falsche Eingaben zu verhindern
        /// </summary>
        /// <param name="textFehl"></param>
        public void PruefeEingabenFehl(TextBox textFehl)
        {
            if(!PruefeEingabeAufZahl(textFehl))
            {
                textFehl.Text = "";
            }
            if (int.TryParse(textFehl.Text, out int parsedValue))
            {
                if(parsedValue >= 15 && parsedValue <= 30)
                {
                    SKCMessages.ShowInfo($"Überprüfe deine Eingabe: {parsedValue} Fehlwurf", "Sind Sie sich sicher?");
                }

                if (parsedValue > 30)
                {
                    SKCMessages.ShowInfo("Fehlwurf kann nicht größer 30 sein!", "Fehlwurf zu groß!");
                    textFehl.Text = "";
                }
            }
        }

        /// <summary>
        /// Prüfung aller Eingaben einer Kategorie und Addition aller Eingaben
        /// </summary>
        /// <param name="eingabe1"></param>
        /// <param name="eingabe2"></param>
        /// <param name="eingabe3"></param>
        /// <param name="eingabe4"></param>
        /// <param name="gesamt"></param>
        public void PruefeEingabenGesamt(TextBox eingabe1, TextBox eingabe2, TextBox eingabe3, TextBox eingabe4, TextBox gesamt)
        {
            if (!string.IsNullOrWhiteSpace(eingabe1.Text.Trim()) && !string.IsNullOrWhiteSpace(eingabe2.Text.Trim()) && !string.IsNullOrWhiteSpace(eingabe3.Text.Trim())
                && !string.IsNullOrWhiteSpace(eingabe4.Text.Trim()))
            {
                Berechnung.SummeBerechnenSpalteGesamt(eingabe1, eingabe2, eingabe3, eingabe4, gesamt);
            }
            else
            {
                gesamt.Text = "";
            }
        }

        /// <summary>
        /// Prüfe die Eingabe, ob es sich überhaupt um eine Zahl handelt
        /// </summary>
        /// <param name="textBox">zu prüfende Textbox</param>
        /// <returns>Handelt es sich um eine Zahl? true/false</returns>
        public bool PruefeEingabeAufZahl(TextBox textBox)
        {
            if (!int.TryParse(textBox.Text, out int parsedValue))
            { 
                return false;
            }

            return true;
        }
    }
}
