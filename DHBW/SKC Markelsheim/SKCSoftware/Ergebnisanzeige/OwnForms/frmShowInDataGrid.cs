using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using SKCDLL.Tools;

namespace Ergebnisanzeige.OwnForms
{
    public partial class frmShowInDataGrid : Form
    {
        private readonly string _spielberichtePfad = @"C:\SKC";
        public List<string> ColumnNames { get; set; }

        public frmShowInDataGrid()
        {
            InitializeComponent();
            Logger.LogToFile("DataGrid-Anzeige initalisiert.");
        }

        public frmShowInDataGrid(List<string> columns) : this()
        {
            ColumnNames = columns;
            HoleAlleDateien();
            SetzeEinstellungen();
        }

        public frmShowInDataGrid(List<string> columns, string titel) : this(columns)
        {
            Text = titel;
        }

        private void SetzeEinstellungen()
        {
            gridSpielberichte.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridSpielberichte.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridSpielberichte.AllowUserToAddRows = false;
            gridSpielberichte.AllowUserToDeleteRows = false;
            gridSpielberichte.Sort(gridSpielberichte.Columns.GetFirstColumn(DataGridViewElementStates.Visible), ListSortDirection.Descending);
        }

        private void HoleAlleDateien()
        {
            try
            {
                bool datumVorhanden = false;
                DataTable dtSpielberichte = new DataTable();
                foreach (var column in ColumnNames)
                {
                    dtSpielberichte.Columns.Add(column);
                    if (column.Equals("Datum", StringComparison.OrdinalIgnoreCase))
                    {
                        datumVorhanden = true;
                        dtSpielberichte.Columns["Datum"].DataType = typeof(DateTime);
                    }
                }
                
                var listeSpielberichte = Directory.GetFiles(_spielberichtePfad).AsEnumerable().ToList();
                foreach (var spielbericht in listeSpielberichte)
                {
                    FileInfo fileInfo = new FileInfo(spielbericht);
                    dtSpielberichte.Rows.Add(fileInfo.CreationTime, fileInfo.Name, fileInfo.FullName);
                    Logger.LogToFile($"Spielbericht gefunden! {fileInfo.FullName} ({fileInfo.CreationTime})");
                }
                gridSpielberichte.DataSource = dtSpielberichte;
                gridSpielberichte.AutoResizeColumns();

                //Wenn eine Datumsspalte vorhanden ist, dann formatiere diese noch und sortiere anhand dieser Spalte
                if (datumVorhanden)
                {
                    gridSpielberichte.Columns["Datum"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    gridSpielberichte.Sort(gridSpielberichte.Columns["Datum"], ListSortDirection.Descending);
                }
                else
                {
                    //Sonst wird anhand der ersten Spalte sortiert
                    gridSpielberichte.Sort(gridSpielberichte.Columns[0], ListSortDirection.Descending);
                }
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, "Beim Holen der Dateien ist ein Fehler aufgetreten.");
            }
        }

        private void GridSpielberichte_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (sender is DataGridView view && ColumnNames.Contains("Dateipfad"))
                {
                    var row = view.CurrentRow;
                    if (row.Cells["Dateipfad"] != null)
                    {
                        OeffneExcel(row);
                    }
                }
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, "Fehler beim Auswählen eines Datensatzes.");
            }      
        }

        private void GridSpielberichte_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (sender is DataGridView grid && ColumnNames.Contains("Datum"))
                {
                    var row = grid.Rows[e.RowIndex];
                    var datZelle = row.Cells["Datum"];

                    var datum = Convert.ToDateTime(datZelle.Value);
                    var diff = DateTime.Now - datum;
                    if (diff.TotalDays < 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.Aqua;
                    }
                    else if (diff.TotalDays < 365)
                    {
                        row.DefaultCellStyle.BackColor = Color.LimeGreen;
                    }
                    else if (diff.TotalDays < 730)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if (diff.TotalDays > 730)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }

                if (sender is DataGridView view)
                {
                    var zelle = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    zelle.ToolTipText = zelle.Value.ToString();
                }
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, "Beim Formatieren der Zellen kam es zu einem Fehler");
            }
        }

        private void GridSpielberichte_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gridSpielberichte.CurrentCell = gridSpielberichte.Rows[e.RowIndex].Cells[e.ColumnIndex];
                gridSpielberichte.Rows[e.RowIndex].Selected = true;
                gridSpielberichte.Focus();
            }
        }

        private void DateiInExcelOeffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var row = gridSpielberichte.CurrentRow;
                if (row.Cells["Dateipfad"] != null)
                {
                    OeffneExcel(row);
                }   
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, "Beim Öffnen einer Exceldatei ist ein Fehler aufgetreten.");
            }
        }

        private void DateiInSpeicherortOeffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var row = gridSpielberichte.CurrentRow;
                if (row.Cells["Dateipfad"] != null)
                {
                    OeffneSpeicherort(row);
                }
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, "Beim Öffnen des Speicherortes einer Datei kam es zu einem Fehler.");
            }
        }

        private void KopierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var cell = gridSpielberichte.CurrentCell;
                Clipboard.SetText(cell.ToolTipText);
            }
            catch (Exception e1)
            {
                SKCMessages.ShowError(e1, "Beim Kopieren einer Datei kam es zu einem Fehler.");
            }
        }

        private void OeffneExcel(DataGridViewRow row)
        {
            if (row.Cells["Dateipfad"] != null)
            {
                var kompletterPfad = row.Cells["Dateipfad"].Value.ToString();
                System.Diagnostics.Process.Start(kompletterPfad);
                Logger.LogToFile("Excelfile wird geöffnet: " + kompletterPfad);
            }
        }

        private void OeffneSpeicherort(DataGridViewRow row)
        {
            if (row.Cells["Dateipfad"] != null)
            {
                var kompletterPfad = row.Cells["Dateipfad"].Value.ToString();
                string argument = "/select,\"" + kompletterPfad + "\"";
                System.Diagnostics.Process.Start("explorer.exe", argument);
                Logger.LogToFile("Pfad wird geöffnet: " + kompletterPfad);
            }
        }

        /// <summary>
        /// Schließt den Berichtsmanager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSchliessen_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Hier disablen wir den Close-Button in der oberen Fensterschaltfläche
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle |= CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        // Für Testzwecke, um alte Dateien zu simulieren!
        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    FileInfo f = new FileInfo(@"C:\SKC\Ergebnis_Spiel_SKCvsTeam 2.xlsx");
        //    f.CreationTime = new DateTime(2015, 5, 5);
        //}
    }
}
