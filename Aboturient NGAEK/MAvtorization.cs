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
using System.Data.SqlClient;

namespace Aboturient_NGAEK
{
    public partial class MAvtorization : MetroForm
    {
        public MAvtorization()
        {
            InitializeComponent();
        }

        private void MAvtorization_Load(object sender, EventArgs e)
        {
            manipulationDB.SelectComboBox("SELECT * FROM Пользователь", comboBoxUsers, "Имя", "ИД");
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string queryNameUser = "SELECT Имя FROM Пользователь WHERE Имя=@nameUser"; // поиск ид из личной инф
                connect.Open();
                SqlCommand comm = new SqlCommand(queryNameUser, connect);
                comm.Parameters.AddWithValue("@nameUser", comboBoxUsers.Text);
                string nameUser = comm.ExecuteScalar().ToString();
                connect.Close();

                string queryPassUser = "SELECT Пароль FROM Пользователь WHERE Имя=@nameUser"; // поиск ид из личной инф
                connect.Open();
                SqlCommand comm1 = new SqlCommand(queryPassUser, connect);
                comm1.Parameters.AddWithValue("@nameUser", comboBoxUsers.Text);
                string passUser = comm1.ExecuteScalar().ToString();
                passUser = shifr_PBKDF2.Decrypt(Convert.ToString(passUser), "204503");
                connect.Close();

                string queryAdminUser = "SELECT Администрирование FROM Пользователь WHERE Имя=@nameUser"; // поиск ид из личной инф
                connect.Open();
                SqlCommand comm2 = new SqlCommand(queryAdminUser, connect);
                comm2.Parameters.AddWithValue("@nameUser", comboBoxUsers.Text);
                bool admin = Convert.ToBoolean(comm2.ExecuteScalar());
                connect.Close();

                if (comboBoxUsers.Text == "Администратор" && admin == true)
                {
                    UsersTF.user = 1;
                }
                else if (admin == true && comboBoxUsers.Text != "Администратор")
                {
                    UsersTF.user = 2;
                }
                else
                {
                    UsersTF.user = 3;
                }

                if (comboBoxUsers.Text == nameUser)
                {
                    if (password.Text == passUser)
                    {
                        ControlForm cf = new ControlForm();
                        cf.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Проверьте правильность введенного пароля.", "Ошибка авторизации");
                    }
                }
                else
                {
                    label1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при авторизации.");
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            MConnectDB cDB = new MConnectDB();
            cDB.Show();
            this.Hide();
        }

        private void btBack_Enter(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btBack, "Назад");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void password_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
