using System.Windows.Forms;

namespace SKCDLL.Tools
{
    public class Validierung
    {
        /// <summary>
        /// Prüfung der Vollen-Eingabe, um falsche Eingaben zu verhindern
        /// </summary>
        /// <param name="textVolle"></param>
        public static void PruefeEingabenVolle(TextBox textVolle)
        {
            if (!PruefeEingabeAufZahl(textVolle))
            {
                textVolle.Text = "";
                return;
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
        public static void PruefeEingabenAbraeumen(TextBox textAbr)
        {
            if (!PruefeEingabeAufZahl(textAbr))
            {
                textAbr.Text = "";
                return;
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
        public static void PruefeEingabenFehl(TextBox textFehl)
        {
            if (!PruefeEingabeAufZahl(textFehl))
            {
                textFehl.Text = "";
                return;
            }
            if (int.TryParse(textFehl.Text, out int parsedValue))
            {
                if (parsedValue >= 15 && parsedValue <= 30)
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
        /// Prüfe die Eingabe, ob es sich überhaupt um eine Zahl handelt
        /// </summary>
        /// <param name="textBox">zu prüfende Textbox</param>
        /// <returns>Handelt es sich um eine Zahl? true/false</returns>
        public static bool PruefeEingabeAufZahl(TextBox textBox)
        {
            if (!int.TryParse(textBox.Text, out int _))
            {
                return false;
            }

            return true;
        }
    }
}
