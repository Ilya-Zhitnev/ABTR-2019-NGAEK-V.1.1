using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace Aboturient_NGAEK
{
    public partial class InsertZnurnal : MetroForm
    {
        public InsertZnurnal()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void InsertZhurnal_Load(object sender, EventArgs e)
        {
            manipulationDB.SelectComboBox("SELECT * FROM [Личная информация]",cbFIO,"ФИО","ИД");
            //connect.Open();
            //SqlCommand cmd = new SqlCommand(manipulationDB.queryLI, connect);
            //SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adp.Fill(dt);
            //cbFIO.DataSource = dt;
            //cbFIO.DisplayMember = "ФИО";
            //cbFIO.ValueMember = "ИД";
            //connect.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateNow = DateTime.Now;

                int lgoti = 0;
                int obsh = 0;
                int dogovorso = 0;
                int otmzach = 0;
                int otmobotkaze = 0;
                int otmovozvr = 0;

                lgoti = lgot.Checked == true ? 1 : 0;
                obsh = obshezh.Checked == true ? 1 : 0;
                dogovorso = dogovorsorg.Checked == true ? 1 : 0;
                otmzach = otmozachisl.Checked == true ? 1 : 0;
                otmobotkaze = otmotkaz.Checked == true ? 1 : 0;
                otmovozvr = otmetkaovozrate.Checked == true ? 1 : 0;

                string idLichInf = "SELECT ИД FROM [Личная информация] WHERE ФИО='"+cbFIO.Text+"'"; // поиск ид из личной инф
                connect.Open();
                SqlCommand comm = new SqlCommand(idLichInf, connect);
                string idLI = comm.ExecuteScalar().ToString();
                connect.Close();

                string idOtm = Convert.ToString(DBNull.Value);

                if (DateDogovor.Text == "" && NumDogovor.Text=="")
                {
                    DateDogovor.Text = "";
                    NumDogovor.Text = "";

                    connect.Open(); //добавление записи в Журнал
                    string queryInsZhurnal = "INSERT INTO Журнал VALUES" +
                        " (@date, @LI, @docs, @obshezh, @dogovor, @otmzachisl, @otmid, @otmotkazzach, @otmovozvrat)";
                    SqlCommand commIns = new SqlCommand(queryInsZhurnal, connect);
                    commIns.Parameters.AddWithValue("@date", dateNow);
                    commIns.Parameters.AddWithValue("@LI", idLI);
                    commIns.Parameters.AddWithValue("@docs", tbDocs.Text);
                    commIns.Parameters.AddWithValue("@obshezh", obsh);
                    commIns.Parameters.AddWithValue("@dogovor", dogovorso);
                    commIns.Parameters.AddWithValue("@otmzachisl", otmzach);
                    commIns.Parameters.AddWithValue("@otmid", DBNull.Value);
                    commIns.Parameters.AddWithValue("@otmotkazzach", otmobotkaze);
                    commIns.Parameters.AddWithValue("@otmovozvrat", otmovozvr);
                    commIns.ExecuteScalar();
                    connect.Close();
                }
                else
                {
                    string insOtmZach = "INSERT INTO [Отметка о зачислении] VALUES ('" + DateDogovor.Text + "', '" + NumDogovor.Text + "')";
                    manipulationDB.Insert(insOtmZach); // добавление самой отметки
                    string idOtmZach = "SELECT ИД FROM [Отметка о зачислении] WHERE Дата='" + DateDogovor.Text + "' AND [Номер приказа]='" + NumDogovor.Text + "'";
                    connect.Open();
                    SqlCommand comm1 = new SqlCommand(idOtmZach, connect);
                    idOtm = comm1.ExecuteScalar().ToString();
                    connect.Close();

                    connect.Open(); //добавление записи в Журнал
                    string queryInsZhurnal = "INSERT INTO Журнал VALUES" +
                        " (@date, @LI, @docs, @obshezh, @dogovor, @otmzachisl, @otmid, @otmotkazzach, @otmovozvrat)";
                    SqlCommand commIns = new SqlCommand(queryInsZhurnal, connect);
                    commIns.Parameters.AddWithValue("@date", dateNow);
                    commIns.Parameters.AddWithValue("@LI", idLI);
                    commIns.Parameters.AddWithValue("@docs", tbDocs.Text);
                    commIns.Parameters.AddWithValue("@obshezh", obsh);
                    commIns.Parameters.AddWithValue("@dogovor", dogovorso);
                    commIns.Parameters.AddWithValue("@otmzachisl", otmzach);
                    commIns.Parameters.AddWithValue("@otmid", idOtm);
                    commIns.Parameters.AddWithValue("@otmotkazzach", otmobotkaze);
                    commIns.Parameters.AddWithValue("@otmovozvrat", otmovozvr);
                    commIns.ExecuteScalar();
                    connect.Close();
                    // поиск ид отметки
                }



                tbDate.Text = "";
                tbGrazhd.Text = "";
                tbAddress.Text = "";
                tbDocs.Text = "";
                DateDogovor.Text = "";
                NumDogovor.Text = "";
            }
            catch (SqlException exSql)
            {
                MessageBox.Show(exSql.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            finally
            {
                Close();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateNow = DateTime.Now;

                int lgoti = 0;
                int obsh = 0;
                int dogovorso = 0;
                int otmzach = 0;
                int otmobotkaze = 0;
                int otmovozvr = 0;

                lgoti = lgot.Checked == true ? 1 : 0;
                obsh = obshezh.Checked == true ? 1 : 0;
                dogovorso = dogovorsorg.Checked == true ? 1 : 0;
                otmzach = otmozachisl.Checked == true ? 1 : 0;
                otmobotkaze = otmotkaz.Checked == true ? 1 : 0;
                otmovozvr = otmetkaovozrate.Checked == true ? 1 : 0;

                string idLichInf = "SELECT ИД FROM [Личная информация] WHERE ФИО='" + cbFIO.Text + "'"; // поиск ид из личной инф
                connect.Open();
                SqlCommand comm = new SqlCommand(idLichInf, connect);
                comm.Parameters.AddWithValue("@fioLI", cbFIO.Text);
                string idLI = comm.ExecuteScalar().ToString();
                connect.Close();

                string idOtm = null;

                if (DateDogovor.Text == "" && NumDogovor.Text == "")
                {
                    DateDogovor.Text = null;
                    NumDogovor.Text = null;

                    connect.Open(); //добавление записи в Журнал
                    string queryInsZhurnal = "INSERT INTO Журнал VALUES" +
                        " (@date, @LI, @docs, @obshezh, @dogovor,@otmzachisl, @otmid, @otmotkazzach, @otmovozvrat)";
                    SqlCommand commIns = new SqlCommand(queryInsZhurnal, connect);
                    commIns.Parameters.AddWithValue("@date", dateNow);
                    commIns.Parameters.AddWithValue("@LI", idLI);
                    commIns.Parameters.AddWithValue("@docs", tbDocs.Text);
                    commIns.Parameters.AddWithValue("@obshezh", obsh);
                    commIns.Parameters.AddWithValue("@dogovor", dogovorso);
                    commIns.Parameters.AddWithValue("@otmzachisl", otmzach);
                    commIns.Parameters.AddWithValue("@otmid", DBNull.Value);
                    commIns.Parameters.AddWithValue("@otmotkazzach", otmobotkaze);
                    commIns.Parameters.AddWithValue("@otmovozvrat", otmovozvr);
                    commIns.ExecuteScalar();
                    connect.Close();

                }
                else
                {
                    string insOtmZach = "INSERT INTO [Отметка о зачислении] VALUES ('" + DateDogovor.Text + "', '" + NumDogovor.Text + "')";
                    manipulationDB.Insert(insOtmZach); // добавление самой отметки
                    string idOtmZach = "SELECT ИД FROM [Отметка о зачислении] WHERE Дата='" + DateDogovor.Text + "' AND [Номер приказа]='" + NumDogovor.Text + "'"; // поиск ид отметки

                    connect.Open();
                    SqlCommand comm1 = new SqlCommand(idOtmZach, connect);
                    idOtm = comm1.ExecuteScalar().ToString();
                    connect.Close();

                    connect.Open(); //добавление записи в Журнал
                    string queryInsZhurnal = "INSERT INTO Журнал VALUES" +
                        " (@date, @LI, @docs, @obshezh, @dogovor,@otmzachisl, @otmid, @otmotkazzach, @otmovozvrat)";
                    SqlCommand commIns = new SqlCommand(queryInsZhurnal, connect);
                    commIns.Parameters.AddWithValue("@date", dateNow);
                    commIns.Parameters.AddWithValue("@LI", idLI);
                    commIns.Parameters.AddWithValue("@docs", tbDocs.Text);
                    commIns.Parameters.AddWithValue("@obshezh", obsh);
                    commIns.Parameters.AddWithValue("@dogovor", dogovorso);
                    commIns.Parameters.AddWithValue("@otmzachisl", otmzach);
                    commIns.Parameters.AddWithValue("@otmid", idOtm);
                    commIns.Parameters.AddWithValue("@otmotkazzach", otmobotkaze);
                    commIns.Parameters.AddWithValue("@otmovozvrat", otmovozvr);
                    commIns.ExecuteScalar();
                    connect.Close();
                }

                tbDate.Text = "";
                tbGrazhd.Text = "";
                tbAddress.Text = "";
                tbDocs.Text = "";
                DateDogovor.Text = "";
                NumDogovor.Text = "";
                lgot.Checked = false;
                dogovorsorg.Checked = false;
                obshezh.Checked = false;
                otmetkaovozrate.Checked = false;
                otmozachisl.Checked = false;
                otmotkaz.Visible = false;
            }
            catch(SqlException exSql)
            {
                MessageBox.Show(exSql.Message, "Ошибка работы с БД");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void cbFIO_TextUpdate(object sender, EventArgs e)
        {

        }

        private void cbFIO_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cbFIO.ValueMember != "1")
            //{
            //    string rezultZaprosLI = "SELECT ИД FROM [Личная информация] WHERE ФИО=@FIO";
            //    connect.Open();
            //    SqlCommand comm = new SqlCommand(rezultZaprosLI, connect);
            //    comm.Parameters.AddWithValue("@FIO", cbFIO.Text);
            //    string ID = comm.ExecuteScalar().ToString();
            //    connect.Close();
            //    string zaprosGrazhd = "SELECT Гражданство FROM [Личная информация] WHERE ИД=" + ID;
            //    string zaprosFIO = "SELECT Адрес FROM [Личная информация] WHERE ИД=" + ID;
            //    connect.Open();
            //    SqlCommand comm1 = new SqlCommand(zaprosGrazhd, connect);
            //    string grazhd = comm1.ExecuteScalar().ToString();
            //    connect.Close();
            //    connect.Open();
            //    SqlCommand comm2 = new SqlCommand(zaprosFIO, connect);
            //    string address = comm2.ExecuteScalar().ToString();
            //    connect.Close();
            //    tbGrazhd.Text = grazhd;
            //    tbAddress.Text = address;
            //}
        }

        private void cbFIO_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void NumDogovor_Click(object sender, EventArgs e)
        {

        }

        private void otmozachisl_Click(object sender, EventArgs e)
        {
            if (otmozachisl.Checked == true)
            {
                lbNumDog.Visible = true;
                lbDatDogovor.Visible = true;
                NumDogovor.Visible = true;
                DateDogovor.Visible = true;
                NumDogovor.Text = null;
                DateDogovor.Text = null;
            }
            else
            {
                lbNumDog.Visible = false;
                lbDatDogovor.Visible = false;
                NumDogovor.Visible = false;
                DateDogovor.Visible = false;
                NumDogovor.Text = null;
                DateDogovor.Text = null;
            }
        }

        //private void otmozachisl_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (otmozachisl.Checked == true)
        //    {
        //        NumDogovor.Visible = true;
        //        DateDogovor.Visible = true;
        //        lbNumDog.Visible = true;
        //        lbDatDogovor.Visible = true;
        //    }
        //    else if(otmozachisl.Checked == false)
        //    {
        //        NumDogovor.Visible = false;
        //        DateDogovor.Visible = false;
        //        lbNumDog.Visible = false;
        //        lbDatDogovor.Visible = false;
        //    }
        //}
    }
}
