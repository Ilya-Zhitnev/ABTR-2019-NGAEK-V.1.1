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
using Aboturient_NGAEK.FormForUpdate;
using Aboturient_NGAEK.FormsForUpdate;


namespace Aboturient_NGAEK
{
    public partial class AllUsers : MetroForm
    {
        public AllUsers()
        {
            InitializeComponent();
        }

        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);
        ManipulationDB manipulationDB = new ManipulationDB();
        ControlForm cf = new ControlForm();



        private void getUsers()
        {
            try
            {
                string queryUsers = "SELECT ROW_NUMBER() over (ORDER BY [Пользователь].[ИД] ASC) [Порядковый номер], Имя, Пароль, Администрирование FROM Пользователь WHERE ИД<>1";
                SqlDataAdapter adapter = new SqlDataAdapter(queryUsers, connect);
                connect.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dGVUsers.DataSource = dt;
                connect.Close();

                for (int i = 0; i < dGVUsers.RowCount; i++)
                {
                    dGVUsers[2, i].Value = shifr_PBKDF2.Decrypt(Convert.ToString(dGVUsers[2, i].Value), "204503");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            getUsers();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlForm cf = new ControlForm();
            cf.Show();
            this.Hide();
        }

        private void AllUsers_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void toolStripButton28_Click_1(object sender, EventArgs e)
        {

        }

        private void resetSpec_Click(object sender, EventArgs e)
        {
            getUsers();
        }

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            cf.Find(dGVUsers,toolStripTextBox8);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            bool admin = Convert.ToBoolean(dGVUsers.CurrentRow.Cells[3].Value) == true ? true : false;

            //string pass = shifr_PBKDF2.Encrypt(Convert.ToString(dGVUsers.CurrentRow.Cells[2].Value), "204503");

            string ID_USER = manipulationDB.generationID("SELECT ИД FROM Пользователь WHERE Имя='" + Convert.ToString(dGVUsers.CurrentRow.Cells[1].Value) + "' " +
                //"AND Пароль='" + pass + "' " +
                "AND Администрирование='" + admin + "'");

            cf.ZapisIndex(ID_USER);

            manipulationDB.Delete(dGVUsers, manipulationDB.queryUserstDel, ID_USER);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            cf.BackUp(dGVUsers);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            cf.Back(dGVUsers);
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            cf.Next(dGVUsers);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            cf.NextUp(dGVUsers);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dGVUsers.SelectedCells.Count != 0)
            {
                bool admin = Convert.ToBoolean(dGVUsers.CurrentRow.Cells[3].Value) == true ? true : false;

                //string queryNameUser = "SELECT Пароль FROM Пользователь WHERE Имя="; // поиск ид из личной инф
                //connect.Open();
                //SqlCommand comm = new SqlCommand(queryNameUser, connect);
                //comm.Parameters.AddWithValue("@nameUser", Convert.ToString(dGVUsers.CurrentRow.Cells[2].Value));
                //string password = comm.ExecuteScalar().ToString();
                //password = shifr_PBKDF2.Decrypt(Convert.ToString(password), "204503");
                //connect.Close();

                //if (password== Convert.ToString(dGVUsers.CurrentRow.Cells[2].Value))
                //{
                    string ID_USER = manipulationDB.generationID("SELECT ИД FROM Пользователь WHERE Имя='" + Convert.ToString(dGVUsers.CurrentRow.Cells[1].Value) + "' " +
                        //"AND Пароль='" + password + "' " +
                        "AND Администрирование='" + admin + "'");
                    cf.ZapisIndex(ID_USER);
                //}
                //else
                //{
                //    MessageBox.Show("Выбранных данных не найдено в базе данных!");
                //}

                

                UpdateFormRegistration upReg = new UpdateFormRegistration();
                upReg.Show();

                upReg.tbUser.Text = Convert.ToString(dGVUsers.CurrentRow.Cells[1].Value);
                upReg.tbPassword.Text = Convert.ToString(dGVUsers.CurrentRow.Cells[2].Value);
                upReg.chbAdmin.Checked = Convert.ToBoolean(dGVUsers.CurrentRow.Cells[3].Value) == true ? true : false;
            }
            else
            {
                MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
            }
        }
    }
}
