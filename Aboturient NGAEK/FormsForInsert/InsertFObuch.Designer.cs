namespace Aboturient_NGAEK
{
    partial class InsertFObuch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertFObuch));
            this.tbNamFO = new MetroFramework.Controls.MetroTextBox();
            this.lbNamFO = new MetroFramework.Controls.MetroLabel();
            this.btInsFO = new MetroFramework.Controls.MetroButton();
            this.btInsCloseFO = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // tbNamFO
            // 
            // 
            // 
            // 
            this.tbNamFO.CustomButton.Image = null;
            this.tbNamFO.CustomButton.Location = new System.Drawing.Point(315, 1);
            this.tbNamFO.CustomButton.Name = "";
            this.tbNamFO.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbNamFO.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbNamFO.CustomButton.TabIndex = 1;
            this.tbNamFO.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbNamFO.CustomButton.UseSelectable = true;
            this.tbNamFO.CustomButton.Visible = false;
            this.tbNamFO.Lines = new string[0];
            this.tbNamFO.Location = new System.Drawing.Point(131, 100);
            this.tbNamFO.MaxLength = 32767;
            this.tbNamFO.Name = "tbNamFO";
            this.tbNamFO.PasswordChar = '\0';
            this.tbNamFO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbNamFO.SelectedText = "";
            this.tbNamFO.SelectionLength = 0;
            this.tbNamFO.SelectionStart = 0;
            this.tbNamFO.ShortcutsEnabled = true;
            this.tbNamFO.Size = new System.Drawing.Size(337, 23);
            this.tbNamFO.TabIndex = 4;
            this.tbNamFO.UseSelectable = true;
            this.tbNamFO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbNamFO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbNamFO
            // 
            this.lbNamFO.AutoSize = true;
            this.lbNamFO.Location = new System.Drawing.Point(23, 100);
            this.lbNamFO.Name = "lbNamFO";
            this.lbNamFO.Size = new System.Drawing.Size(102, 19);
            this.lbNamFO.TabIndex = 5;
            this.lbNamFO.Text = "Наименование";
            // 
            // btInsFO
            // 
            this.btInsFO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btInsFO.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btInsFO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btInsFO.Location = new System.Drawing.Point(23, 156);
            this.btInsFO.Name = "btInsFO";
            this.btInsFO.Size = new System.Drawing.Size(237, 37);
            this.btInsFO.TabIndex = 6;
            this.btInsFO.Text = "Добавить";
            this.btInsFO.UseCustomBackColor = true;
            this.btInsFO.UseCustomForeColor = true;
            this.btInsFO.UseSelectable = true;
            this.btInsFO.Click += new System.EventHandler(this.btInsFO_Click_1);
            // 
            // btInsCloseFO
            // 
            this.btInsCloseFO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btInsCloseFO.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btInsCloseFO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btInsCloseFO.Location = new System.Drawing.Point(280, 156);
            this.btInsCloseFO.Name = "btInsCloseFO";
            this.btInsCloseFO.Size = new System.Drawing.Size(238, 37);
            this.btInsCloseFO.TabIndex = 7;
            this.btInsCloseFO.Text = "Добавить и закрыть";
            this.btInsCloseFO.UseCustomBackColor = true;
            this.btInsCloseFO.UseCustomForeColor = true;
            this.btInsCloseFO.UseSelectable = true;
            this.btInsCloseFO.Click += new System.EventHandler(this.btInsCloseFO_Click_1);
            // 
            // InsertFObuch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 247);
            this.Controls.Add(this.btInsCloseFO);
            this.Controls.Add(this.btInsFO);
            this.Controls.Add(this.lbNamFO);
            this.Controls.Add(this.tbNamFO);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InsertFObuch";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Добавить(Форма обучения)";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.InsertFObuch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tbNamFO;
        private MetroFramework.Controls.MetroLabel lbNamFO;
        private MetroFramework.Controls.MetroButton btInsFO;
        private MetroFramework.Controls.MetroButton btInsCloseFO;
    }
}