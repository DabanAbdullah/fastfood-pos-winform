namespace fastfoodnew
{
    partial class frmActivation
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
            this.crystalTheme1 = new Telerik.WinControls.Themes.CrystalTheme();
            this.licActCtrl = new QLicense.Windows.Controls.LicenseActivateControl();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // licActCtrl
            // 
            this.licActCtrl.AppName = null;
            this.licActCtrl.LicenseObjectType = null;
            this.licActCtrl.Location = new System.Drawing.Point(-3, 0);
            this.licActCtrl.Name = "licActCtrl";
            this.licActCtrl.ShowMessageAfterValidation = true;
            this.licActCtrl.Size = new System.Drawing.Size(469, 371);
            this.licActCtrl.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(365, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "چالاک کردن";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmActivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 414);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.licActCtrl);
            this.Font = new System.Drawing.Font("Unikurd Jino", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmActivation";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "کارا کردن";
            this.ThemeName = "Crystal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmActivation_FormClosing);
            this.Load += new System.EventHandler(this.frmActivation_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.CrystalTheme crystalTheme1;
        private QLicense.Windows.Controls.LicenseActivateControl licActCtrl;
        private System.Windows.Forms.Button button1;
    }
}