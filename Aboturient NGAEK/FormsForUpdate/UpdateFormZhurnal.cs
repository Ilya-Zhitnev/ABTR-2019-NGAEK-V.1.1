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
    public partial class UpdateFormZhurnal : MetroForm
    {
        public UpdateFormZhurnal()
        {
            InitializeComponent();
        }

        string ID_LI = "";
        string ID_Otm = Convert.ToString(DBNull.Value);

        private void UpdateFormZhurnal_Load(object sender, EventArgs e)
        {

        }

        ManipulationDB manipulationDB = new ManipulationDB();
        ControlForm cf = new ControlForm();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void btUpdCloseZhurn_Click(object sender, EventArgs e)
        {
            try
            {
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
                
                if(ID_Otm == "" && ID_LI != "")
                {
                    string queryUpdLI = "UPDATE [Личная информация] " +
                        "SET Гражданство = '" + tbGrazdh.Text + "' , Адрес = '" + tbAddress.Text + "', Льготы = '" + lgoti + "' WHERE ИД=" + ID_LI + "'";
                    cf.UpdateNoID(cf.dGVLichInf, queryUpdLI);
                    string insOtmZach = "INSERT INTO [Отметка о зачислении] VALUES ('" + DateDogovor.Text + "', '" + NumDogovor.Text + "')";
                    manipulationDB.Insert(insOtmZach); // добавление самой отметки о зачислении
                    string queryIdOtm = "SELECT ИД FROM [Отметка о зачислении] " +
                         "WHERE [Номер приказа] = @numPrik AND Дата = @date";
                    connect.Open();
                    SqlCommand commOtm = new SqlCommand(queryIdOtm, connect);
                    commOtm.Parameters.AddWithValue("@numPrik", NumDogovor.Text);
                    commOtm.Parameters.AddWithValue("@date", DateDogovor.Text);
                    if (commOtm.ExecuteScalar() == null)
                    {
                        ID_Otm = "";
                    }
                    else
                    {
                        ID_Otm = commOtm.ExecuteScalar().ToString();
                    }
                    connect.Close();
                }
                else if (ID_LI == "" && ID_Otm != "")
                {
                    string queryOtmZach = "UPDATE [Отметка о зачислении] " +
                        "SET Дата = '" + DateDogovor.Text + "' , [Номер приказа] = '" + NumDogovor.Text + "' WHERE ИД='" + ID_Otm + "'";
                    cf.UpdateNoID(cf.dGVOtmZach, queryOtmZach);
                    string insLI = "INSERT INTO [Личная информация] VALUES ('" + cbFIO.Text + "', '" + tbGrazdh.Text + "'," + tbAddress.Text + "')";
                    manipulationDB.Insert(insLI); // добавление личной инфы
                    string queryIdLI = "SELECT ИД FROM [Личная информация] " +
                         "WHERE [ФИО] = @fio AND Гражданство = @grazhd AND Адрес = @adress AND Льготы=@lgoti";
                    connect.Open();
                    SqlCommand commLI = new SqlCommand(queryIdLI, connect);
                    commLI.Parameters.AddWithValue("@fio", cbFIO.Text);
                    commLI.Parameters.AddWithValue("@grazhd", tbGrazdh.Text);
                    commLI.Parameters.AddWithValue("@adress", tbAddress.Text);
                    commLI.Parameters.AddWithValue("@lgoti", lgoti);
                    if (commLI.ExecuteScalar() == null)
                    {
                        ID_LI = "";
                    }
                    else
                    {
                        ID_LI = commLI.ExecuteScalar().ToString();
                    }
                    connect.Close();
                }
                else if(ID_LI == "" && ID_Otm == "")
                {
                    string insLI = "INSERT INTO [Личная информация] (ФИО, Гражданство, Адрес, Льготы) " +
                        "VALUES ('" + cbFIO.Text + "', '" + tbGrazdh.Text + "','" + tbAddress.Text + "','" + lgoti + "')";
                    manipulationDB.Insert(insLI); // добавление личной инфы
                    string queryLI = "SELECT ИД FROM [Личная информация] " +
                         "WHERE [ФИО] = @fio AND Гражданство = @grazhd AND Адрес = @adress AND Льготы=@lgoti";
                    connect.Open();
                    SqlCommand commLI = new SqlCommand(queryLI, connect);
                    commLI.Parameters.AddWithValue("@fio", cbFIO.Text);
                    commLI.Parameters.AddWithValue("@grazhd", tbGrazdh.Text);
                    commLI.Parameters.AddWithValue("@adress", tbAddress.Text);
                    commLI.Parameters.AddWithValue("@lgoti", lgoti);
                    if (commLI.ExecuteScalar() == null)
                    {
                        ID_LI = "";
                    }
                    else
                    {
                        ID_LI = commLI.ExecuteScalar().ToString();
                    }
                    connect.Close();

                    string insOtmZach = "INSERT INTO [Отметка о зачислении] VALUES ('" + DateDogovor.Text + "', '" + NumDogovor.Text + "')";
                    manipulationDB.Insert(insOtmZach); // добавление самой отметки о зачислении
                    string queryIdOtm = "SELECT ИД FROM [Отметка о зачислении] " +
                         "WHERE [Номер приказа] = @numPrik AND Дата = @date";
                    connect.Open();
                    SqlCommand commOtm = new SqlCommand(queryIdOtm, connect);
                    commOtm.Parameters.AddWithValue("@numPrik", NumDogovor.Text);
                    commOtm.Parameters.AddWithValue("@date", DateDogovor.Text);
                    if (commOtm.ExecuteScalar() == null)
                    {
                        ID_Otm = "";
                    }
                    else
                    {
                        ID_Otm = commOtm.ExecuteScalar().ToString();
                    }
                    connect.Close();
                }
                else
                {
                    string queryUpdLI = "UPDATE [Личная информация] " +
                        "SET ФИО = '" + cbFIO.Text + "', Гражданство = '" + tbGrazdh.Text + "' , Адрес = '" + tbAddress.Text + "', Льготы = '" + lgoti + "' WHERE ИД='" + ID_LI + "'";
                    cf.UpdateNoID(cf.dGVLichInf, queryUpdLI);

                    string queryOtmZach = "UPDATE [Отметка о зачислении] " +
                        "SET Дата = '" + DateDogovor.Text + "' , [Номер приказа] = '" + NumDogovor.Text + "' WHERE ИД='" + ID_Otm + "'";
                    cf.UpdateNoID(cf.dGVOtmZach, queryOtmZach);
                }

                
                string updZhurnal = "UPDATE [Журнал]" +
                    " SET [Дата приема]='" + tbDate.Text + "', [Личная информация] ='" + ID_LI + "', Документы = '"+ tbDoc.Text + "'," +
                    " [Нужда в общежитии]='" + obsh + "', Договор = '"+dogovorso+"', [Отметка о зачислении]='" + otmzach + "', [Отметка]='"+ID_Otm+"', " +
                    "[Отметка об отказе в зачислении]='"+ otmobotkaze + "', [Отметка о возврате]='"+otmovozvr+"' WHERE ИД=";
                cf.Update(cf.dGVFormObuch, updZhurnal);
                Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            finally
            {
                File.Delete("index.txt");
            }
        }

        private void UpdateFormZhurnal_Shown(object sender, EventArgs e)
        {
            int lgoti = 0;
            lgoti = lgot.Checked == true ? 1 : 0;
            string queryIdLI = "SELECT ИД FROM [Личная информация] " +
                "WHERE ФИО=@fio AND Гражданство=@grazhdanstv AND Адрес=@address AND Льготы=@lgoti";
            connect.Open();
            SqlCommand comm0 = new SqlCommand(queryIdLI, connect);
            comm0.Parameters.AddWithValue("@fio", cbFIO.Text);
            comm0.Parameters.AddWithValue("@grazhdanstv", tbGrazdh.Text);
            comm0.Parameters.AddWithValue("@address", tbAddress.Text);
            comm0.Parameters.AddWithValue("@lgoti", lgoti);
            if (comm0.ExecuteScalar() == null)
            {
                ID_LI = "";
            }
            else
            {
                ID_LI = comm0.ExecuteScalar().ToString();
            }
            connect.Close();

            string queryIdOtm = "SELECT ИД FROM [Отметка о зачислении] " +
                "WHERE [Номер приказа] = @numPrik AND Дата = @date";
            connect.Open();
            SqlCommand comm1 = new SqlCommand(queryIdOtm, connect);
            comm1.Parameters.AddWithValue("@numPrik", NumDogovor.Text);
            comm1.Parameters.AddWithValue("@date", DateDogovor.Text);
            if (comm1.ExecuteScalar() == null)
            {
                ID_Otm = "";
            }
            else
            {
                ID_Otm = comm1.ExecuteScalar().ToString();
            }
            connect.Close();
        }

        private void UpdateFormZhurnal_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }
    }
}
