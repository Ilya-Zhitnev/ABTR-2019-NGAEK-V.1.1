namespace Aboturient_NGAEK.FormForUpdate
{
    partial class UpdateFormOtdel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFormOtdel));
            this.btUpdCloseOtdel = new MetroFramework.Controls.MetroButton();
            this.lbNam = new MetroFramework.Controls.MetroLabel();
            this.tbName = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // btUpdCloseOtdel
            // 
            this.btUpdCloseOtdel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btUpdCloseOtdel.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btUpdCloseOtdel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btUpdCloseOtdel.Location = new System.Drawing.Point(23, 154);
            this.btUpdCloseOtdel.Name = "btUpdCloseOtdel";
            this.btUpdCloseOtdel.Size = new System.Drawing.Size(540, 40);
            this.btUpdCloseOtdel.TabIndex = 7;
            this.btUpdCloseOtdel.Text = "Изменить и закрыть";
            this.btUpdCloseOtdel.UseCustomBackColor = true;
            this.btUpdCloseOtdel.UseCustomForeColor = true;
            this.btUpdCloseOtdel.UseSelectable = true;
            this.btUpdCloseOtdel.Click += new System.EventHandler(this.btUpdCloseOtdel_Click);
            // 
            // lbNam
            // 
            this.lbNam.AutoSize = true;
            this.lbNam.Location = new System.Drawing.Point(60, 92);
            this.lbNam.Name = "lbNam";
            this.lbNam.Size = new System.Drawing.Size(102, 19);
            this.lbNam.TabIndex = 5;
            this.lbNam.Text = "Наименование";
            // 
            // tbName
            // 
            // 
            // 
            // 
            this.tbName.CustomButton.Image = null;
            this.tbName.CustomButton.Location = new System.Drawing.Point(333, 1);
            this.tbName.CustomButton.Name = "";
            this.tbName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbName.CustomButton.TabIndex = 1;
            this.tbName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbName.CustomButton.UseSelectable = true;
            this.tbName.CustomButton.Visible = false;
            this.tbName.Lines = new string[0];
            this.tbName.Location = new System.Drawing.Point(175, 92);
            this.tbName.MaxLength = 32767;
            this.tbName.Name = "tbName";
            this.tbName.PasswordChar = '\0';
            this.tbName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbName.SelectedText = "";
            this.tbName.SelectionLength = 0;
            this.tbName.SelectionStart = 0;
            this.tbName.ShortcutsEnabled = true;
            this.tbName.Size = new System.Drawing.Size(355, 23);
            this.tbName.TabIndex = 4;
            this.tbName.UseSelectable = true;
            this.tbName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UpdateFormOtdel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 217);
            this.Controls.Add(this.btUpdCloseOtdel);
            this.Controls.Add(this.lbNam);
            this.Controls.Add(this.tbName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateFormOtdel";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Изменение(Отдел)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateFormOtdel_FormClosed);
            this.Load += new System.EventHandler(this.UpdateFormOtdel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btUpdCloseOtdel;
        private MetroFramework.Controls.MetroLabel lbNam;
        public MetroFramework.Controls.MetroTextBox tbName;
    }
}