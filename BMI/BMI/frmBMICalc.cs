using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace BMI
{
    public partial class frmBMICalc : Form
    {
        public frmBMICalc()
        {
            InitializeComponent();
        }

        private void btnBerechnen_Click(object sender, EventArgs e)
        {
            int gewicht;
            int groesse;
            double bmi;

            if (string.IsNullOrWhiteSpace(txtGewicht.Text) || string.IsNullOrWhiteSpace(txtGroesse.Text))
            {
                MessageBox.Show("Gib was Gescheites ein!", "Fehler bei Eingabe", MessageBoxButtons.OK);

                return;
            }

            int.TryParse(txtGewicht.Text, out gewicht);
            int.TryParse(txtGroesse.Text, out groesse);

            bmi = gewicht / ((groesse / 100.0) * (groesse / 100.0));
            bmi = Math.Round(bmi, 2);
            lblRes.Text = bmi.ToString(CultureInfo.InvariantCulture);

            if (bmi < 18.5)
            {
                lblResultanzeige.Text = "Sie sind leicht untergewichtig";
                lblRes.BackColor = Color.OrangeRed;

            }else if (bmi > 25.0)
            {
                lblResultanzeige.Text = "Sie sind leicht übergewichtig";
                lblRes.BackColor = Color.Red;
            }
            else
            {
                lblResultanzeige.Text = "Sie sind normalgewichtig";
                lblRes.BackColor = Color.Green;
            }
        }
    }
}
