namespace TestingGUIProject
{
    partial class Rechner
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rechnerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.arithmetikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.umrechnungToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rechnerToolStripMenuItem1,
            this.umrechnungToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(887, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rechnerToolStripMenuItem1
            // 
            this.rechnerToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arithmetikToolStripMenuItem});
            this.rechnerToolStripMenuItem1.Name = "rechnerToolStripMenuItem1";
            this.rechnerToolStripMenuItem1.Size = new System.Drawing.Size(62, 20);
            this.rechnerToolStripMenuItem1.Text = "Rechner";
            // 
            // arithmetikToolStripMenuItem
            // 
            this.arithmetikToolStripMenuItem.Name = "arithmetikToolStripMenuItem";
            this.arithmetikToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.arithmetikToolStripMenuItem.Text = "Arithmetik";
            this.arithmetikToolStripMenuItem.Click += new System.EventHandler(this.arithmetikToolStripMenuItem_Click);
            // 
            // umrechnungToolStripMenuItem1
            // 
            this.umrechnungToolStripMenuItem1.Name = "umrechnungToolStripMenuItem1";
            this.umrechnungToolStripMenuItem1.Size = new System.Drawing.Size(89, 20);
            this.umrechnungToolStripMenuItem1.Text = "Umrechnung";
            // 
            // Rechner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 483);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Rechner";
            this.Text = "Rechner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rechnerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem arithmetikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem umrechnungToolStripMenuItem1;
    }
}

