namespace BMI
{
    partial class frmBMICalc
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
            this.txtGewicht = new System.Windows.Forms.TextBox();
            this.txtGroesse = new System.Windows.Forms.TextBox();
            this.btnBerechnen = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblGroesse = new System.Windows.Forms.Label();
            this.lblGewicht = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRes = new System.Windows.Forms.Label();
            this.lblResultanzeige = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtGewicht
            // 
            this.txtGewicht.Location = new System.Drawing.Point(179, 55);
            this.txtGewicht.Name = "txtGewicht";
            this.txtGewicht.Size = new System.Drawing.Size(233, 22);
            this.txtGewicht.TabIndex = 0;
            // 
            // txtGroesse
            // 
            this.txtGroesse.Location = new System.Drawing.Point(179, 83);
            this.txtGroesse.Name = "txtGroesse";
            this.txtGroesse.Size = new System.Drawing.Size(233, 22);
            this.txtGroesse.TabIndex = 1;
            // 
            // btnBerechnen
            // 
            this.btnBerechnen.Location = new System.Drawing.Point(120, 126);
            this.btnBerechnen.Name = "btnBerechnen";
            this.btnBerechnen.Size = new System.Drawing.Size(177, 23);
            this.btnBerechnen.TabIndex = 2;
            this.btnBerechnen.Text = "Berechnen";
            this.btnBerechnen.UseVisualStyleBackColor = true;
            this.btnBerechnen.Click += new System.EventHandler(this.btnBerechnen_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(131, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 17);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Berechnung des BMi";
            // 
            // lblGroesse
            // 
            this.lblGroesse.AutoSize = true;
            this.lblGroesse.Location = new System.Drawing.Point(12, 83);
            this.lblGroesse.Name = "lblGroesse";
            this.lblGroesse.Size = new System.Drawing.Size(114, 17);
            this.lblGroesse.TabIndex = 4;
            this.lblGroesse.Text = "Ihre Größe in cm";
            // 
            // lblGewicht
            // 
            this.lblGewicht.AutoSize = true;
            this.lblGewicht.Location = new System.Drawing.Point(15, 55);
            this.lblGewicht.Name = "lblGewicht";
            this.lblGewicht.Size = new System.Drawing.Size(112, 17);
            this.lblGewicht.TabIndex = 5;
            this.lblGewicht.Text = "Ihr Gewicht in kg";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ihr BMI";
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Location = new System.Drawing.Point(198, 185);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(16, 17);
            this.lblRes.TabIndex = 7;
            this.lblRes.Text = "0";
            // 
            // lblResultanzeige
            // 
            this.lblResultanzeige.AutoSize = true;
            this.lblResultanzeige.Location = new System.Drawing.Point(176, 222);
            this.lblResultanzeige.Name = "lblResultanzeige";
            this.lblResultanzeige.Size = new System.Drawing.Size(57, 17);
            this.lblResultanzeige.TabIndex = 8;
            this.lblResultanzeige.Text = "Nothing";
            // 
            // frmBMICalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 394);
            this.Controls.Add(this.lblResultanzeige);
            this.Controls.Add(this.lblRes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGewicht);
            this.Controls.Add(this.lblGroesse);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBerechnen);
            this.Controls.Add(this.txtGroesse);
            this.Controls.Add(this.txtGewicht);
            this.Name = "frmBMICalc";
            this.Text = "BMI Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGewicht;
        private System.Windows.Forms.TextBox txtGroesse;
        private System.Windows.Forms.Button btnBerechnen;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGroesse;
        private System.Windows.Forms.Label lblGewicht;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.Label lblResultanzeige;
    }
}

