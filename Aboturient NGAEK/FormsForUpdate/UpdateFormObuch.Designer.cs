namespace Aboturient_NGAEK.FormForUpdate
{
    partial class UpdateFormObuch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFormObuch));
            this.btUpdCloseFO = new MetroFramework.Controls.MetroButton();
            this.lbNamFO = new MetroFramework.Controls.MetroLabel();
            this.tbNamFO = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // btUpdCloseFO
            // 
            this.btUpdCloseFO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btUpdCloseFO.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btUpdCloseFO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btUpdCloseFO.Location = new System.Drawing.Point(23, 166);
            this.btUpdCloseFO.Name = "btUpdCloseFO";
            this.btUpdCloseFO.Size = new System.Drawing.Size(530, 42);
            this.btUpdCloseFO.TabIndex = 11;
            this.btUpdCloseFO.Text = "Изменить и закрыть";
            this.btUpdCloseFO.UseCustomBackColor = true;
            this.btUpdCloseFO.UseCustomForeColor = true;
            this.btUpdCloseFO.UseSelectable = true;
            this.btUpdCloseFO.Click += new System.EventHandler(this.btUpdCloseFO_Click);
            // 
            // lbNamFO
            // 
            this.lbNamFO.AutoSize = true;
            this.lbNamFO.Location = new System.Drawing.Point(64, 92);
            this.lbNamFO.Name = "lbNamFO";
            this.lbNamFO.Size = new System.Drawing.Size(102, 19);
            this.lbNamFO.TabIndex = 9;
            this.lbNamFO.Text = "Наименование";
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
            this.tbNamFO.Location = new System.Drawing.Point(177, 93);
            this.tbNamFO.MaxLength = 32767;
            this.tbNamFO.Name = "tbNamFO";
            this.tbNamFO.PasswordChar = '\0';
            this.tbNamFO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbNamFO.SelectedText = "";
            this.tbNamFO.SelectionLength = 0;
            this.tbNamFO.SelectionStart = 0;
            this.tbNamFO.ShortcutsEnabled = true;
            this.tbNamFO.Size = new System.Drawing.Size(337, 23);
            this.tbNamFO.TabIndex = 8;
            this.tbNamFO.UseSelectable = true;
            this.tbNamFO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbNamFO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UpdateFormObuch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 231);
            this.Controls.Add(this.btUpdCloseFO);
            this.Controls.Add(this.lbNamFO);
            this.Controls.Add(this.tbNamFO);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateFormObuch";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Изменение(Форма обучения)";
            this.Deactivate += new System.EventHandler(this.UpdateFormObuch_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateFormObuch_FormClosed);
            this.Load += new System.EventHandler(this.UpdateFormObuch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btUpdCloseFO;
        private MetroFramework.Controls.MetroLabel lbNamFO;
        public MetroFramework.Controls.MetroTextBox tbNamFO;
    }
}