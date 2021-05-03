namespace Aboturient_NGAEK.FormsForUpdate
{
    partial class UpdateFormRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFormRegistration));
            this.btRegisterUser = new MetroFramework.Controls.MetroButton();
            this.lbAdmin = new MetroFramework.Controls.MetroLabel();
            this.lbPassword = new MetroFramework.Controls.MetroLabel();
            this.lbUser = new MetroFramework.Controls.MetroLabel();
            this.chbAdmin = new MetroFramework.Controls.MetroCheckBox();
            this.tbPassword = new MetroFramework.Controls.MetroTextBox();
            this.tbUser = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // btRegisterUser
            // 
            this.btRegisterUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btRegisterUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btRegisterUser.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btRegisterUser.ForeColor = System.Drawing.Color.Blue;
            this.btRegisterUser.Location = new System.Drawing.Point(20, 267);
            this.btRegisterUser.Name = "btRegisterUser";
            this.btRegisterUser.Size = new System.Drawing.Size(498, 39);
            this.btRegisterUser.TabIndex = 19;
            this.btRegisterUser.Tag = "Регистрация нового пользователя в системе";
            this.btRegisterUser.Text = "Изменить и закрыть";
            this.btRegisterUser.UseCustomBackColor = true;
            this.btRegisterUser.UseCustomForeColor = true;
            this.btRegisterUser.UseSelectable = true;
            this.btRegisterUser.Click += new System.EventHandler(this.btRegisterUser_Click);
            // 
            // lbAdmin
            // 
            this.lbAdmin.AutoSize = true;
            this.lbAdmin.Location = new System.Drawing.Point(81, 173);
            this.lbAdmin.Name = "lbAdmin";
            this.lbAdmin.Size = new System.Drawing.Size(105, 19);
            this.lbAdmin.TabIndex = 16;
            this.lbAdmin.Text = "Администратор";
            this.lbAdmin.Click += new System.EventHandler(this.lbAdmin_Click);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(81, 136);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(54, 19);
            this.lbPassword.TabIndex = 15;
            this.lbPassword.Text = "Пароль";
            this.lbPassword.Click += new System.EventHandler(this.lbPassword_Click);
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(81, 101);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(122, 19);
            this.lbUser.TabIndex = 14;
            this.lbUser.Text = "Имя пользователя";
            this.lbUser.Click += new System.EventHandler(this.lbUser_Click);
            // 
            // chbAdmin
            // 
            this.chbAdmin.AutoSize = true;
            this.chbAdmin.Location = new System.Drawing.Point(219, 177);
            this.chbAdmin.Name = "chbAdmin";
            this.chbAdmin.Size = new System.Drawing.Size(198, 15);
            this.chbAdmin.TabIndex = 13;
            this.chbAdmin.Text = "Является ли администратором?";
            this.chbAdmin.UseSelectable = true;
            this.chbAdmin.CheckedChanged += new System.EventHandler(this.chbAdmin_CheckedChanged);
            // 
            // tbPassword
            // 
            // 
            // 
            // 
            this.tbPassword.CustomButton.Image = null;
            this.tbPassword.CustomButton.Location = new System.Drawing.Point(201, 1);
            this.tbPassword.CustomButton.Name = "";
            this.tbPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbPassword.CustomButton.TabIndex = 1;
            this.tbPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbPassword.CustomButton.UseSelectable = true;
            this.tbPassword.CustomButton.Visible = false;
            this.tbPassword.Lines = new string[0];
            this.tbPassword.Location = new System.Drawing.Point(219, 136);
            this.tbPassword.MaxLength = 32767;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '\0';
            this.tbPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbPassword.SelectedText = "";
            this.tbPassword.SelectionLength = 0;
            this.tbPassword.SelectionStart = 0;
            this.tbPassword.ShortcutsEnabled = true;
            this.tbPassword.Size = new System.Drawing.Size(223, 23);
            this.tbPassword.TabIndex = 12;
            this.tbPassword.UseSelectable = true;
            this.tbPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbPassword.Click += new System.EventHandler(this.tbPassword_Click);
            // 
            // tbUser
            // 
            // 
            // 
            // 
            this.tbUser.CustomButton.Image = null;
            this.tbUser.CustomButton.Location = new System.Drawing.Point(201, 1);
            this.tbUser.CustomButton.Name = "";
            this.tbUser.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbUser.CustomButton.TabIndex = 1;
            this.tbUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbUser.CustomButton.UseSelectable = true;
            this.tbUser.CustomButton.Visible = false;
            this.tbUser.Lines = new string[0];
            this.tbUser.Location = new System.Drawing.Point(219, 104);
            this.tbUser.MaxLength = 32767;
            this.tbUser.Name = "tbUser";
            this.tbUser.PasswordChar = '\0';
            this.tbUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbUser.SelectedText = "";
            this.tbUser.SelectionLength = 0;
            this.tbUser.SelectionStart = 0;
            this.tbUser.ShortcutsEnabled = true;
            this.tbUser.Size = new System.Drawing.Size(223, 23);
            this.tbUser.TabIndex = 11;
            this.tbUser.UseSelectable = true;
            this.tbUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbUser.Click += new System.EventHandler(this.tbUser_Click);
            // 
            // UpdateFormRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 326);
            this.Controls.Add(this.btRegisterUser);
            this.Controls.Add(this.lbAdmin);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.chbAdmin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateFormRegistration";
            this.Text = "Изменение(Пользователи)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateFormRegistration_FormClosed);
            this.Load += new System.EventHandler(this.UpdateFormRegistration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btRegisterUser;
        private MetroFramework.Controls.MetroLabel lbAdmin;
        private MetroFramework.Controls.MetroLabel lbPassword;
        private MetroFramework.Controls.MetroLabel lbUser;
        public MetroFramework.Controls.MetroCheckBox chbAdmin;
        public MetroFramework.Controls.MetroTextBox tbPassword;
        public MetroFramework.Controls.MetroTextBox tbUser;
    }
}