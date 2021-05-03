using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using System.Data.SqlClient;

namespace Aboturient_NGAEK
{
    public partial class InsertLichnInfo : MetroForm
    {
        public InsertLichnInfo()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void InsertLichnInfo_Load(object sender, EventArgs e)
        {
            manipulationDB.SelectComboBox("SELECT * FROM Специальность", cbSpec, "Название", "ИД");
            manipulationDB.SelectComboBox("SELECT * FROM Отделение", cbOtdel, "Наименование", "ИД");
        }

        private void btInsertLI_Click(object sender, EventArgs e)
        {
            try
            {
                string queryPass = "INSERT INTO Паспорт " +
                    "VALUES('" + tbSeria.Text + "', '" + tbNum.Text + "', '" + shifr_PBKDF2.Encrypt(tbId.Text, "822822") + "')";
                manipulationDB.Insert(queryPass);
                string queryIdPass = "SELECT ИД FROM Паспорт " +
                    "WHERE Серия = '" + tbSeria.Text + "' AND Номер = '" + tbNum.Text + "'";
                connect.Open();
                SqlCommand comm = new SqlCommand(queryIdPass, connect);
                string ID = comm.ExecuteScalar().ToString();
                connect.Close();
                int lgot = 0;
                if (lgoti.Checked == true)
                {
                    lgot = 1;
                }
                else
                {
                    lgot = 0;
                }
                connect.Open();
                string query = "INSERT INTO [Личная информация]" +
                    " VALUES (@spec, @otdel, @fio, @grazhd, @address,@id, @lgot,@school, @srednball, @class)";
                SqlCommand commIns = new SqlCommand(query, connect);
                commIns.Parameters.AddWithValue("@spec", cbSpec.SelectedValue);
                commIns.Parameters.AddWithValue("@otdel", cbOtdel.SelectedValue);
                commIns.Parameters.AddWithValue("@fio", tbFIO.Text);
                commIns.Parameters.AddWithValue("@grazhd", tbGrazhd.Text);
                commIns.Parameters.AddWithValue("@address", tbAdress.Text);
                commIns.Parameters.AddWithValue("@id", ID);
                commIns.Parameters.AddWithValue("@lgot", lgot);
                commIns.Parameters.AddWithValue("@school", tbSchool.Text);
                commIns.Parameters.AddWithValue("@srednball", Convert.ToDouble(tbSrednBall.Text));
                commIns.Parameters.AddWithValue("@class", mCbClass.Text);
                commIns.ExecuteScalar();
                connect.Close();
                tbFIO.Text = "";
                tbGrazhd.Text = "";
                tbAdress.Text = "";
                tbSeria.Text = "";
                tbNum.Text = "";
                tbId.Text = "";
                tbSchool.Text = "";
                tbSrednBall.Text = "";
            }
            catch(SqlException exsql)
            {
                MessageBox.Show(exsql.Message, "Ошибка работы с БД");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void btInsertCloseLI_Click(object sender, EventArgs e)
        {
            try
            {
                string queryPass = "INSERT INTO [Паспорт] " +
                    "VALUES('" + tbSeria.Text + "', '" + tbNum.Text + "', '" + shifr_PBKDF2.Encrypt(tbId.Text, "822822") + "')";
                manipulationDB.Insert(queryPass);
                string queryIdPass = "SELECT ИД FROM [Паспорт] " +
                    "WHERE Серия = '" + tbSeria.Text + "' AND Номер = '" + tbNum.Text + "'";
                connect.Open();
                SqlCommand comm = new SqlCommand(queryIdPass, connect);
                string ID = comm.ExecuteScalar().ToString();
                connect.Close();
                int lgot = 0;
                if (lgoti.Checked == true)
                {
                    lgot = 1;
                }
                else
                {
                    lgot = 0;
                }
                connect.Open();
                string query = "INSERT INTO [Личная информация]" +
                    " VALUES (@spec, @otdel, @fio, @grazhd, @address,@id, @lgot,@school, @srednball, @class)";
                SqlCommand commIns = new SqlCommand(query, connect);
                commIns.Parameters.AddWithValue("@spec", cbSpec.SelectedValue);
                commIns.Parameters.AddWithValue("@otdel", cbOtdel.SelectedValue);
                commIns.Parameters.AddWithValue("@fio", tbFIO.Text);
                commIns.Parameters.AddWithValue("@grazhd", tbGrazhd.Text);
                commIns.Parameters.AddWithValue("@address", tbAdress.Text);
                commIns.Parameters.AddWithValue("@id", ID);
                commIns.Parameters.AddWithValue("@lgot", lgot);
                commIns.Parameters.AddWithValue("@school", tbSchool.Text);
                commIns.Parameters.AddWithValue("@srednball", Convert.ToDouble(tbSrednBall.Text));
                commIns.Parameters.AddWithValue("@class", mCbClass.Text);
                commIns.ExecuteScalar();
                connect.Close();
                tbFIO.Text = "";
                tbGrazhd.Text = "";
                tbAdress.Text = "";
                tbSeria.Text = "";
                tbNum.Text = "";
                tbId.Text = "";
            }
            catch (SqlException exsql)
            {
                MessageBox.Show(exsql.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            Close();
        }

        private void tbSeria_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void infoPass_Click(object sender, EventArgs e)
        {

        }
    }
}
