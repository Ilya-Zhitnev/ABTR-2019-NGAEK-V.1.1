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
using System.IO;
using System.Data.SqlClient;

namespace Aboturient_NGAEK.FormForUpdate
{
    public partial class UpdateFormLichnInfo : MetroForm
    {
        public UpdateFormLichnInfo()
        {
            InitializeComponent();
        }

        string ID = "";

        private void UpdateFormLichnInfo_Load(object sender, EventArgs e)
        {
            //manipulationDB.SelectComboBox("SELECT * FROM Специальность", cbSpec, "Название", "ИД");
            //manipulationDB.SelectComboBox("SELECT * FROM Отделение", cbOtdel, "Наименование", "ИД");
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        ControlForm cf = new ControlForm();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void btInsertCloseLI_Click(object sender, EventArgs e)
        {
            try
            {
                int lgot = 0;
                if (lgoti.Checked == true)
                {
                    lgot = 1;
                }
                else
                {
                    lgot = 0;
                }

                string[] allText = File.ReadAllLines("index.txt"); //чтение всех строк файла в массив строк

                if (ID == null || ID=="")
                {
                    string queryInsPas = "INSERT INTO [Паспорт] VALUES('" + tbSeria.Text + "', '" + tbNum.Text + "', '" + shifr_PBKDF2.Encrypt(tbId.Text, "822822") + "')";
                    manipulationDB.Insert(queryInsPas);
                    

                    connect.Open();
                    string queryIdPass2 = "SELECT ИД FROM [Паспорт] " +
                        "WHERE Серия = '" + tbSeria.Text + "' AND Номер = '" + tbNum.Text + "'";
                    SqlCommand comm2 = new SqlCommand(queryIdPass2, connect);
                    string ID2 = comm2.ExecuteScalar().ToString();
                    connect.Close(); 

                    string queryUpdLI = "UPDATE [Личная информация] " +
                        "SET Специальность = @spec, Отделение = @otdel , ФИО = @fio , Гражданство = @grazhd , Адрес = @address , Паспорт = @id, Льготы = @lgot, Школа = @school, [Средний балл]=@srednball, Класс=@class WHERE ИД=";
                    foreach (string s in allText)
                    {   //вывод всех строк на консоль
                        connect.Open();
                        queryUpdLI = queryUpdLI + s;
                        SqlCommand SQLcmd = new SqlCommand(queryUpdLI, connect);
                        SQLcmd.Parameters.AddWithValue("@spec", cbSpec.SelectedValue);
                        SQLcmd.Parameters.AddWithValue("@otdel", cbOtdel.SelectedValue);
                        SQLcmd.Parameters.AddWithValue("@fio", tbFIO.Text);
                        SQLcmd.Parameters.AddWithValue("@grazhd", tbGrazhd.Text);
                        SQLcmd.Parameters.AddWithValue("@address", tbAdress.Text);
                        SQLcmd.Parameters.AddWithValue("@id", ID2);
                        SQLcmd.Parameters.AddWithValue("@lgot", lgot);
                        SQLcmd.Parameters.AddWithValue("@school", tbSchool.Text);
                        SQLcmd.Parameters.AddWithValue("@srednball", Convert.ToDouble(tbSrednBall.Text));
                        SQLcmd.Parameters.AddWithValue("@class", Convert.ToInt32(mCbClass.Text));
                        SQLcmd.ExecuteScalar();
                        connect.Close();
                    }
                }
                else
                {
                    string queryUpdPas = "UPDATE [Паспорт] " +
                        "SET Серия = '" + tbSeria.Text + "',Номер = '" + tbNum.Text + "', Идентификатор = '" + shifr_PBKDF2.Encrypt(tbId.Text, "822822") + "' WHERE ИД=" + ID;
                    cf.UpdateNoID(cf.dGVPass, queryUpdPas);

                    string queryUpdLI = "UPDATE [Личная информация] " +
                        "SET Специальность = @spec, Отделение = @otdel , ФИО = @fio , Гражданство = @grazhd , Адрес = @address , Паспорт = @id, Льготы = @lgot, Школа = @school, [Средний балл]=@srednball, Класс=@class WHERE ИД=";
                    foreach (string s in allText)
                    {
                        connect.Open();
                        queryUpdLI = queryUpdLI + s;
                        SqlCommand SQLcmdTwo = new SqlCommand(queryUpdLI, connect);
                        SQLcmdTwo.Parameters.AddWithValue("@spec", cbSpec.SelectedValue);
                        SQLcmdTwo.Parameters.AddWithValue("@otdel", cbOtdel.SelectedValue);
                        SQLcmdTwo.Parameters.AddWithValue("@fio", tbFIO.Text);
                        SQLcmdTwo.Parameters.AddWithValue("@grazhd", tbGrazhd.Text);
                        SQLcmdTwo.Parameters.AddWithValue("@address", tbAdress.Text);
                        SQLcmdTwo.Parameters.AddWithValue("@id", ID);
                        SQLcmdTwo.Parameters.AddWithValue("@lgot", lgot);
                        SQLcmdTwo.Parameters.AddWithValue("@school", tbSchool.Text);
                        SQLcmdTwo.Parameters.AddWithValue("@srednball", Convert.ToDouble(tbSrednBall.Text));
                        SQLcmdTwo.Parameters.AddWithValue("@class", Convert.ToInt32(mCbClass.Text));
                        SQLcmdTwo.ExecuteScalar();
                        connect.Close();
                    }
                }
                Close();
            }
            catch (SqlException exsql)
            {
                MessageBox.Show(exsql.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            finally
            {
                connect.Close();
                File.Delete("index.txt");
                manipulationDB.Select(manipulationDB.queryLI, cf.dGVLichInf);
            }
        }

        private void btUpdLI_Click(object sender, EventArgs e)
        {

        }

        private void UpdateFormLichnInfo_Deactivate(object sender, EventArgs e)
        {
            //File.Delete("index.txt");
            //cf.BringToFront();
        }

        private void UpdateFormLichnInfo_Shown(object sender, EventArgs e)
        {
            string queryIdPass = "SELECT ИД FROM [Паспорт] " +
                "WHERE Серия = @seria AND Номер = @num AND Идентификатор = @id";
            connect.Open();
            SqlCommand comm = new SqlCommand(queryIdPass, connect);
            comm.Parameters.AddWithValue("@seria", tbSeria.Text);
            comm.Parameters.AddWithValue("@num", tbNum.Text);
            comm.Parameters.AddWithValue("@id", tbId.Text);
            if (comm.ExecuteScalar() == null)
            {
                ID = "";
            }
            else
            {
                ID = comm.ExecuteScalar().ToString();
            }
            connect.Close();
        }

        private void UpdateFormLichnInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }
    }
}
