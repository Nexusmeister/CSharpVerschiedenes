using System.Windows.Forms;

namespace SKCDLL.Tools
{
    public class Uebertragen
    {
        /// <summary>
        /// Spieler Übertragung von einer Kombobox in eine Textbox
        /// </summary>
        /// <param name="cboEingabe"></param>
        /// <param name="txtAusgabe"></param>
        public static void UebertrageText(ComboBox cboEingabe, TextBox txtAusgabe)
        {
            if (!string.IsNullOrWhiteSpace(cboEingabe.Text.Trim()))
            {
                txtAusgabe.Text = cboEingabe.Text;
                txtAusgabe.ReadOnly = true;
            }
        }

        public static void UebertrageText(string str, TextBox txtZiel)
        {
            UebertrageText(str, txtZiel, null);
        }

        public static void UebertrageText(string str, TextBox txtZiel1, TextBox txtZiel2)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                txtZiel1.Text = str;
                if (txtZiel2 != null)
                {
                    txtZiel2.Text = str;
                }

            }
        }

        /// <summary>
        /// Übertrage ein Ergebnis, von einer TextBox in eine andere TextBox
        /// </summary>
        /// <param name="txtInput"></param>
        /// <param name="txtOutput"></param>
        public static void UebertrageText(TextBox txtInput, TextBox txtOutput)
        {
            if (!string.IsNullOrWhiteSpace(txtInput.Text.Trim()))
            {
                txtOutput.Text = txtInput.Text.Trim();
            }
        }

        /// <summary>
        /// Übertragt ein Text aus einer Combobox in ein Label
        /// </summary>
        /// <param name="cboEingabe"></param>
        /// <param name="label"></param>
        public static void UebertrageText(ComboBox cboEingabe, Label label)
        {
            if (!string.IsNullOrWhiteSpace(cboEingabe.Text.Trim()))
            {
                label.Text = cboEingabe.Text;
            }
        }

        public static void UebertrageZahl(int zahl, TextBox txtOutput)
        {
            txtOutput.Text = zahl.ToString();
        }

        public static string FormatiereKommazahl(double zahl)
        {
            return string.Format("{0:0.0}", zahl);
        }
    }
}
