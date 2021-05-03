using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;

namespace Aboturient_NGAEK.FormsForUpdate
{
    public partial class UpdateFormRegistration : MetroForm
    {
        public UpdateFormRegistration()
        {
            InitializeComponent();
        }

        AllUsers user = new AllUsers();

        private void btRegisterUser_Click(object sender, EventArgs e)
        {
            try
            {
                ControlForm cf = new ControlForm();
                int adm = 0;
                if (chbAdmin.Checked == true)
                {
                    adm = 1;
                }
                else
                {
                    adm = 0;
                }
                
                string query = "UPDATE Пользователь SET " +
                    "Имя = '" + tbUser.Text+ "', Пароль = '" + shifr_PBKDF2.Encrypt(Convert.ToString(tbPassword.Text), "204503") + "', Администрирование = '" + adm + "'" +
                    " WHERE ИД =";
                cf.Update(user.dGVUsers, query);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void UpdateFormRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }

        private void UpdateFormRegistration_Load(object sender, EventArgs e)
        {

        }

        private void lbAdmin_Click(object sender, EventArgs e)
        {

        }

        private void lbPassword_Click(object sender, EventArgs e)
        {

        }

        private void lbUser_Click(object sender, EventArgs e)
        {

        }

        private void chbAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbPassword_Click(object sender, EventArgs e)
        {

        }

        private void tbUser_Click(object sender, EventArgs e)
        {

        }
    }
}
