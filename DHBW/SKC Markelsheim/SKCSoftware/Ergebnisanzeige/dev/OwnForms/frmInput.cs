using System;
using System.Windows.Forms;

namespace Ergebnisanzeige.OwnForms
{
    public partial class frmInput : Form
    {
        private bool _pw = false;
        public bool Passwort {
            get
            {
                return _pw;
            }

            set
            {
                _pw = value;

                txtInput.UseSystemPasswordChar = _pw;       
            }
        }
        public frmInput()
        {
            InitializeComponent();
            ControlBox = false;
        }

        /// <summary>
        /// Konstruktor mit Angabe eines Titels
        /// </summary>
        /// <param name="titelText"></param>
        public frmInput(string caption) : this()
        {
            Text = caption;
        }

        public frmInput(string caption, string labelName) : this(caption)
        {
            lblBeschreibung.Text = labelName;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void BtnAbbrechen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        /// <summary>
        /// Holt String bereits getrimmed aus der Textbox
        /// </summary>
        /// <returns></returns>
        public string GetInput()
        {
            return txtInput.Text.Trim();
        }      

        private void TxtEmpfaenger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }

        private void FrmInput_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }
    }
}
