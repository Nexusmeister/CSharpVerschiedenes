namespace Ergebnisanzeige.OwnForms
{
    partial class frmShowInDataGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowInDataGrid));
            this.gridSpielberichte = new System.Windows.Forms.DataGridView();
            this.lblHeuteErstellt = new System.Windows.Forms.Label();
            this.lblKleinerEinJahrAlt = new System.Windows.Forms.Label();
            this.lblAelterAlsEinJahr = new System.Windows.Forms.Label();
            this.lblAelterAls2Jahre = new System.Windows.Forms.Label();
            this.lblFarblegende = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kopierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiInExcelÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiInSpeicherortÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSchliessen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridSpielberichte)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridSpielberichte
            // 
            this.gridSpielberichte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSpielberichte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSpielberichte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSpielberichte.Location = new System.Drawing.Point(12, 12);
            this.gridSpielberichte.Name = "gridSpielberichte";
            this.gridSpielberichte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridSpielberichte.Size = new System.Drawing.Size(768, 415);
            this.gridSpielberichte.TabIndex = 0;
            this.gridSpielberichte.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridSpielberichte_CellContentDoubleClick);
            this.gridSpielberichte.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridSpielberichte_CellFormatting);
            this.gridSpielberichte.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridSpielberichte_CellMouseDown);
            // 
            // lblHeuteErstellt
            // 
            this.lblHeuteErstellt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHeuteErstellt.AutoSize = true;
            this.lblHeuteErstellt.BackColor = System.Drawing.Color.Aqua;
            this.lblHeuteErstellt.Location = new System.Drawing.Point(13, 461);
            this.lblHeuteErstellt.Name = "lblHeuteErstellt";
            this.lblHeuteErstellt.Size = new System.Drawing.Size(69, 13);
            this.lblHeuteErstellt.TabIndex = 1;
            this.lblHeuteErstellt.Text = "Heute erstellt";
            // 
            // lblKleinerEinJahrAlt
            // 
            this.lblKleinerEinJahrAlt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKleinerEinJahrAlt.AutoSize = true;
            this.lblKleinerEinJahrAlt.BackColor = System.Drawing.Color.Lime;
            this.lblKleinerEinJahrAlt.Location = new System.Drawing.Point(88, 461);
            this.lblKleinerEinJahrAlt.Name = "lblKleinerEinJahrAlt";
            this.lblKleinerEinJahrAlt.Size = new System.Drawing.Size(59, 13);
            this.lblKleinerEinJahrAlt.TabIndex = 2;
            this.lblKleinerEinJahrAlt.Text = "< 1 Jahr alt";
            // 
            // lblAelterAlsEinJahr
            // 
            this.lblAelterAlsEinJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAelterAlsEinJahr.AutoSize = true;
            this.lblAelterAlsEinJahr.BackColor = System.Drawing.Color.Yellow;
            this.lblAelterAlsEinJahr.Location = new System.Drawing.Point(153, 461);
            this.lblAelterAlsEinJahr.Name = "lblAelterAlsEinJahr";
            this.lblAelterAlsEinJahr.Size = new System.Drawing.Size(59, 13);
            this.lblAelterAlsEinJahr.TabIndex = 3;
            this.lblAelterAlsEinJahr.Text = "> 1 Jahr alt";
            // 
            // lblAelterAls2Jahre
            // 
            this.lblAelterAls2Jahre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAelterAls2Jahre.AutoSize = true;
            this.lblAelterAls2Jahre.BackColor = System.Drawing.Color.Red;
            this.lblAelterAls2Jahre.Location = new System.Drawing.Point(218, 461);
            this.lblAelterAls2Jahre.Name = "lblAelterAls2Jahre";
            this.lblAelterAls2Jahre.Size = new System.Drawing.Size(59, 13);
            this.lblAelterAls2Jahre.TabIndex = 4;
            this.lblAelterAls2Jahre.Text = "> 2 Jahr alt";
            // 
            // lblFarblegende
            // 
            this.lblFarblegende.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFarblegende.AutoSize = true;
            this.lblFarblegende.Location = new System.Drawing.Point(12, 439);
            this.lblFarblegende.Name = "lblFarblegende";
            this.lblFarblegende.Size = new System.Drawing.Size(66, 13);
            this.lblFarblegende.TabIndex = 5;
            this.lblFarblegende.Text = "Farblegende";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kopierenToolStripMenuItem,
            this.dateiInExcelÖffnenToolStripMenuItem,
            this.dateiInSpeicherortÖffnenToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(216, 70);
            // 
            // kopierenToolStripMenuItem
            // 
            this.kopierenToolStripMenuItem.Image = global::Ergebnisanzeige.Properties.Resources.icon_kopieren;
            this.kopierenToolStripMenuItem.Name = "kopierenToolStripMenuItem";
            this.kopierenToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.kopierenToolStripMenuItem.Text = "Kopieren";
            this.kopierenToolStripMenuItem.Click += new System.EventHandler(this.KopierenToolStripMenuItem_Click);
            // 
            // dateiInExcelÖffnenToolStripMenuItem
            // 
            this.dateiInExcelÖffnenToolStripMenuItem.Image = global::Ergebnisanzeige.Properties.Resources.ExcelLogoSmall_scale_80_zugeschnitten;
            this.dateiInExcelÖffnenToolStripMenuItem.Name = "dateiInExcelÖffnenToolStripMenuItem";
            this.dateiInExcelÖffnenToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.dateiInExcelÖffnenToolStripMenuItem.Text = "Datei in Excel öffnen";
            this.dateiInExcelÖffnenToolStripMenuItem.Click += new System.EventHandler(this.DateiInExcelOeffnenToolStripMenuItem_Click);
            // 
            // dateiInSpeicherortÖffnenToolStripMenuItem
            // 
            this.dateiInSpeicherortÖffnenToolStripMenuItem.Image = global::Ergebnisanzeige.Properties.Resources.Windows_Explorer_Logo;
            this.dateiInSpeicherortÖffnenToolStripMenuItem.Name = "dateiInSpeicherortÖffnenToolStripMenuItem";
            this.dateiInSpeicherortÖffnenToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.dateiInSpeicherortÖffnenToolStripMenuItem.Text = "Datei in Speicherort öffnen";
            this.dateiInSpeicherortÖffnenToolStripMenuItem.Click += new System.EventHandler(this.DateiInSpeicherortOeffnenToolStripMenuItem_Click);
            // 
            // btnSchliessen
            // 
            this.btnSchliessen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchliessen.Image = global::Ergebnisanzeige.Properties.Resources.close_resized;
            this.btnSchliessen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSchliessen.Location = new System.Drawing.Point(656, 439);
            this.btnSchliessen.Name = "btnSchliessen";
            this.btnSchliessen.Size = new System.Drawing.Size(124, 35);
            this.btnSchliessen.TabIndex = 6;
            this.btnSchliessen.Text = "Schließen";
            this.btnSchliessen.UseVisualStyleBackColor = true;
            this.btnSchliessen.Click += new System.EventHandler(this.BtnSchliessen_Click);
            // 
            // frmShowInDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(792, 486);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.btnSchliessen);
            this.Controls.Add(this.lblFarblegende);
            this.Controls.Add(this.lblAelterAls2Jahre);
            this.Controls.Add(this.lblAelterAlsEinJahr);
            this.Controls.Add(this.lblKleinerEinJahrAlt);
            this.Controls.Add(this.lblHeuteErstellt);
            this.Controls.Add(this.gridSpielberichte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShowInDataGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmShowInDataGrid";
            ((System.ComponentModel.ISupportInitialize)(this.gridSpielberichte)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSpielberichte;
        private System.Windows.Forms.Label lblHeuteErstellt;
        private System.Windows.Forms.Label lblKleinerEinJahrAlt;
        private System.Windows.Forms.Label lblAelterAlsEinJahr;
        private System.Windows.Forms.Label lblAelterAls2Jahre;
        private System.Windows.Forms.Label lblFarblegende;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem kopierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiInExcelÖffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiInSpeicherortÖffnenToolStripMenuItem;
        private System.Windows.Forms.Button btnSchliessen;
    }
}