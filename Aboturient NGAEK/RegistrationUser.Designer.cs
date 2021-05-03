namespace Aboturient_NGAEK
{
    partial class RegistrationUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationUser));
            this.tbUser = new MetroFramework.Controls.MetroTextBox();
            this.tbPassword = new MetroFramework.Controls.MetroTextBox();
            this.chbAdmin = new MetroFramework.Controls.MetroCheckBox();
            this.lbUser = new MetroFramework.Controls.MetroLabel();
            this.lbPassword = new MetroFramework.Controls.MetroLabel();
            this.lbAdmin = new MetroFramework.Controls.MetroLabel();
            this.lbPasswordRepeat = new MetroFramework.Controls.MetroLabel();
            this.tbPasswordRepeat = new MetroFramework.Controls.MetroTextBox();
            this.btRegisterUser = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
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
            this.tbUser.Location = new System.Drawing.Point(198, 99);
            this.tbUser.MaxLength = 32767;
            this.tbUser.Name = "tbUser";
            this.tbUser.PasswordChar = '\0';
            this.tbUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbUser.SelectedText = "";
            this.tbUser.SelectionLength = 0;
            this.tbUser.SelectionStart = 0;
            this.tbUser.ShortcutsEnabled = true;
            this.tbUser.Size = new System.Drawing.Size(223, 23);
            this.tbUser.TabIndex = 1;
            this.tbUser.UseSelectable = true;
            this.tbUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            this.tbPassword.Location = new System.Drawing.Point(198, 131);
            this.tbPassword.MaxLength = 32767;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '\0';
            this.tbPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbPassword.SelectedText = "";
            this.tbPassword.SelectionLength = 0;
            this.tbPassword.SelectionStart = 0;
            this.tbPassword.ShortcutsEnabled = true;
            this.tbPassword.Size = new System.Drawing.Size(223, 23);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.UseSelectable = true;
            this.tbPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chbAdmin
            // 
            this.chbAdmin.AutoSize = true;
            this.chbAdmin.Location = new System.Drawing.Point(198, 204);
            this.chbAdmin.Name = "chbAdmin";
            this.chbAdmin.Size = new System.Drawing.Size(198, 15);
            this.chbAdmin.TabIndex = 3;
            this.chbAdmin.Text = "Является ли администратором?";
            this.chbAdmin.UseSelectable = true;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(60, 96);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(122, 19);
            this.lbUser.TabIndex = 4;
            this.lbUser.Text = "Имя пользователя";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(60, 131);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(54, 19);
            this.lbPassword.TabIndex = 5;
            this.lbPassword.Text = "Пароль";
            // 
            // lbAdmin
            // 
            this.lbAdmin.AutoSize = true;
            this.lbAdmin.Location = new System.Drawing.Point(60, 200);
            this.lbAdmin.Name = "lbAdmin";
            this.lbAdmin.Size = new System.Drawing.Size(105, 19);
            this.lbAdmin.TabIndex = 6;
            this.lbAdmin.Text = "Администратор";
            // 
            // lbPasswordRepeat
            // 
            this.lbPasswordRepeat.AutoSize = true;
            this.lbPasswordRepeat.Location = new System.Drawing.Point(60, 165);
            this.lbPasswordRepeat.Name = "lbPasswordRepeat";
            this.lbPasswordRepeat.Size = new System.Drawing.Size(122, 19);
            this.lbPasswordRepeat.TabIndex = 8;
            this.lbPasswordRepeat.Text = "Повторите пароль";
            // 
            // tbPasswordRepeat
            // 
            // 
            // 
            // 
            this.tbPasswordRepeat.CustomButton.Image = null;
            this.tbPasswordRepeat.CustomButton.Location = new System.Drawing.Point(201, 1);
            this.tbPasswordRepeat.CustomButton.Name = "";
            this.tbPasswordRepeat.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbPasswordRepeat.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbPasswordRepeat.CustomButton.TabIndex = 1;
            this.tbPasswordRepeat.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbPasswordRepeat.CustomButton.UseSelectable = true;
            this.tbPasswordRepeat.CustomButton.Visible = false;
            this.tbPasswordRepeat.Lines = new string[0];
            this.tbPasswordRepeat.Location = new System.Drawing.Point(198, 165);
            this.tbPasswordRepeat.MaxLength = 32767;
            this.tbPasswordRepeat.Name = "tbPasswordRepeat";
            this.tbPasswordRepeat.PasswordChar = '\0';
            this.tbPasswordRepeat.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbPasswordRepeat.SelectedText = "";
            this.tbPasswordRepeat.SelectionLength = 0;
            this.tbPasswordRepeat.SelectionStart = 0;
            this.tbPasswordRepeat.ShortcutsEnabled = true;
            this.tbPasswordRepeat.Size = new System.Drawing.Size(223, 23);
            this.tbPasswordRepeat.TabIndex = 9;
            this.tbPasswordRepeat.UseSelectable = true;
            this.tbPasswordRepeat.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbPasswordRepeat.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btRegisterUser
            // 
            this.btRegisterUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btRegisterUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btRegisterUser.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btRegisterUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btRegisterUser.Location = new System.Drawing.Point(20, 283);
            this.btRegisterUser.Name = "btRegisterUser";
            this.btRegisterUser.Size = new System.Drawing.Size(458, 39);
            this.btRegisterUser.TabIndex = 10;
            this.btRegisterUser.Tag = "Регистрация нового пользователя в системе";
            this.btRegisterUser.Text = "Регистрация";
            this.btRegisterUser.UseCustomBackColor = true;
            this.btRegisterUser.UseCustomForeColor = true;
            this.btRegisterUser.UseSelectable = true;
            this.btRegisterUser.Click += new System.EventHandler(this.btRegistr_Click);
            // 
            // RegistrationUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 342);
            this.Controls.Add(this.btRegisterUser);
            this.Controls.Add(this.tbPasswordRepeat);
            this.Controls.Add(this.lbPasswordRepeat);
            this.Controls.Add(this.lbAdmin);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.chbAdmin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUser);
            this.ForeColor = System.Drawing.Color.Blue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegistrationUser";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Регистрация нового пользователя";
            this.TransparencyKey = System.Drawing.Color.Ivory;
            this.Load += new System.EventHandler(this.RegistrationUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox tbUser;
        private MetroFramework.Controls.MetroTextBox tbPassword;
        private MetroFramework.Controls.MetroCheckBox chbAdmin;
        private MetroFramework.Controls.MetroLabel lbUser;
        private MetroFramework.Controls.MetroLabel lbPassword;
        private MetroFramework.Controls.MetroLabel lbAdmin;
        private MetroFramework.Controls.MetroLabel lbPasswordRepeat;
        private MetroFramework.Controls.MetroTextBox tbPasswordRepeat;
        private MetroFramework.Controls.MetroButton btRegisterUser;
    }
}