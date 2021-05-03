namespace Aboturient_NGAEK
{
    partial class InsertOtdel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertOtdel));
            this.tbName = new MetroFramework.Controls.MetroTextBox();
            this.lbNam = new MetroFramework.Controls.MetroLabel();
            this.btInsOtdel = new MetroFramework.Controls.MetroButton();
            this.btInsCloseOtdel = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
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
            this.tbName.Location = new System.Drawing.Point(152, 78);
            this.tbName.MaxLength = 32767;
            this.tbName.Name = "tbName";
            this.tbName.PasswordChar = '\0';
            this.tbName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbName.SelectedText = "";
            this.tbName.SelectionLength = 0;
            this.tbName.SelectionStart = 0;
            this.tbName.ShortcutsEnabled = true;
            this.tbName.Size = new System.Drawing.Size(355, 23);
            this.tbName.TabIndex = 0;
            this.tbName.UseSelectable = true;
            this.tbName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbNam
            // 
            this.lbNam.AutoSize = true;
            this.lbNam.Location = new System.Drawing.Point(37, 78);
            this.lbNam.Name = "lbNam";
            this.lbNam.Size = new System.Drawing.Size(102, 19);
            this.lbNam.TabIndex = 1;
            this.lbNam.Text = "Наименование";
            // 
            // btInsOtdel
            // 
            this.btInsOtdel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btInsOtdel.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btInsOtdel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btInsOtdel.Location = new System.Drawing.Point(23, 128);
            this.btInsOtdel.Name = "btInsOtdel";
            this.btInsOtdel.Size = new System.Drawing.Size(147, 40);
            this.btInsOtdel.TabIndex = 2;
            this.btInsOtdel.Text = "Добавить";
            this.btInsOtdel.UseCustomBackColor = true;
            this.btInsOtdel.UseCustomForeColor = true;
            this.btInsOtdel.UseSelectable = true;
            this.btInsOtdel.Click += new System.EventHandler(this.btInsOtdel_Click);
            // 
            // btInsCloseOtdel
            // 
            this.btInsCloseOtdel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btInsCloseOtdel.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btInsCloseOtdel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btInsCloseOtdel.Location = new System.Drawing.Point(315, 128);
            this.btInsCloseOtdel.Name = "btInsCloseOtdel";
            this.btInsCloseOtdel.Size = new System.Drawing.Size(210, 40);
            this.btInsCloseOtdel.TabIndex = 3;
            this.btInsCloseOtdel.Text = "Добавить и закрыть";
            this.btInsCloseOtdel.UseCustomBackColor = true;
            this.btInsCloseOtdel.UseCustomForeColor = true;
            this.btInsCloseOtdel.UseSelectable = true;
            this.btInsCloseOtdel.Click += new System.EventHandler(this.btInsCloseOtdel_Click_1);
            // 
            // InsertOtdel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 191);
            this.Controls.Add(this.btInsCloseOtdel);
            this.Controls.Add(this.btInsOtdel);
            this.Controls.Add(this.lbNam);
            this.Controls.Add(this.tbName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InsertOtdel";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Добавить(Отделение)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InsertOtdel_FormClosed);
            this.Load += new System.EventHandler(this.InsertOtdel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tbName;
        private MetroFramework.Controls.MetroLabel lbNam;
        private MetroFramework.Controls.MetroButton btInsOtdel;
        private MetroFramework.Controls.MetroButton btInsCloseOtdel;
    }
}