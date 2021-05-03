using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;
using MetroFramework.Forms;
using Aboturient_NGAEK.FormsForUpdate;
using System.Collections.Generic;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using Application = System.Windows.Forms.Application;
using Aboturient_NGAEK.FormForUpdate;
using System.Reflection;
using System.Security.Cryptography;

namespace Aboturient_NGAEK
{
    public partial class ControlForm : MetroForm
    {
        //public List<int> Numid = new List<int>();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        public ControlForm()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();

        public void ControlForm_Load(object sender, EventArgs e)
        {
            try
            {
                manipulationDB.Select(manipulationDB.queryPlan, dGVPlan);
                manipulationDB.Select(manipulationDB.queryLI, dGVLichInf);

                manipulationDB.Select(manipulationDB.queryOtmZach, dGVOtmZach);
                manipulationDB.Select(manipulationDB.queryZhurnal, dGVZhurnalReg);
                manipulationDB.Select(manipulationDB.querySpec, dGVSpecial);
                manipulationDB.Select(manipulationDB.queryOtdel, dGVOtdel);
                manipulationDB.Select(manipulationDB.queryFormObuch, dGVFormObuch);
                manipulationDB.Select(manipulationDB.queryPassport, dGVPass);

                for (int i = 0; i < dGVPass.RowCount; i++)
                {
                    dGVPass[3, i].Value = shifr_PBKDF2.Decrypt(Convert.ToString(dGVPass[3, i].Value), "822822");
                }

                for (int i = 0; i < dGVLichInf.RowCount; i++)
                {
                    dGVLichInf[8, i].Value = shifr_PBKDF2.Decrypt(Convert.ToString(dGVLichInf[8, i].Value), "822822");
                }

                manipulationDB.SelectComboBox("SELECT * FROM Специальность", cbSpecialnost, "Название", "ИД");
                manipulationDB.SelectComboBox("SELECT * FROM Отделение", cbOtdel, "Наименование", "ИД");
                cbClass.SelectedIndex = cbClass.FindString("9");

                if (UsersTF.user == 1)
                {
                    gPMenuControl.Visible = true;

                    if (tabMenu.SelectedTab == tabPageSvodnVedom)
                    {
                        gPDopMenu.Visible = true;
                        gPMenuControl.Visible = false;
                    }
                    else
                    {
                        gPDopMenu.Visible = false;
                        gPMenuControl.Visible = true;
                    }
                }
                else if (UsersTF.user == 2)
                {
                    controlMenuAdministrirov.Visible = false;
                    gPMenuControl.Visible = true;

                    if (tabMenu.SelectedTab == tabPageSvodnVedom)
                    {
                        gPDopMenu.Visible = true;
                        gPMenuControl.Visible = false;
                    }
                    else
                    {
                        gPDopMenu.Visible = false;
                        gPMenuControl.Visible = true;
                    }
                }
                else if (UsersTF.user == 3)
                {
                    controlMenuAdministrirov.Visible = false;
                    gPMenuControl.Visible = false;
                    gPDopMenu.Visible = false;
                    binNavPass.Visible = false;
                    binNavPlan.Visible = false;
                    binNavSpecialty.Visible = false;
                    binNavSvodnVemod.Visible = false;
                    binNavZhurnal.Visible = false;
                    binNavOtdel.Visible = false;
                    binNavFormObuch.Visible = false;
                    binNavLInf.Visible = false;
                    binNavOtmetkaZachisl.Visible = false;
                    gPMenuControl.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        internal void ControlForm_Load()
        {
            throw new NotImplementedException();
        }

        public void UpdateNoID(DataGridView dG, string queryUpd)
        {
            try
            {
                connect.Open();
                SqlCommand SQLcmd = new SqlCommand(queryUpd, connect);
                SQLcmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка программы");
            }
            finally
            {
                connect.Close();
            }
        }

        public void Update(DataGridView dG, string queryUpd)
        {
            try
            {
                connect.Open();
                try
                {      //чтение файла
                    string[] allText = File.ReadAllLines("index.txt"); //чтение всех строк файла в массив строк
                    foreach (string s in allText)
                    {   //вывод всех строк на консоль
                        queryUpd = queryUpd + s;
                        SqlCommand SQLcmd = new SqlCommand(queryUpd, connect);
                        SQLcmd.ExecuteScalar();
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка программы");
            }
            finally
            {
                connect.Close();
                File.Delete("index.txt");
            }
        }

        void SelectComboBox(string query, ComboBox cb, string name, string id)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cb.DataSource = dt;
                cb.DisplayMember = name;
                cb.ValueMember = id;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка программы:");
            }
            finally
            {
                connect.Close();
            }
        }

        public void ZapisIndex(string ID)
        {
            //if (dGV.RowCount != 0)
            //{
            //    if (dGV.SelectedCells.Count != 0)
            //    {
            string fileName = "index.txt";                //пишем полный путь к файлу
            if (File.Exists(fileName) != true)
            {  //проверяем есть ли такой файл, если его нет, то создаем
                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write)))
                {
                    sw.WriteLine(ID); //пишем строчку, или пишем что хотим
                }
            }
            else
            {                              //если файл есть, то откываем его и пишем в него 
                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Open, FileAccess.Write)))
                {
                    (sw.BaseStream).Seek(0, SeekOrigin.End);         //идем в конец файла и пишем строку или пишем то, что хотим
                    sw.WriteLine(ID);
                }
            }
            //    }
            //}
        }

        public void Find(DataGridView numDat, ToolStripTextBox tltbNum)
        {
            try
            {
                if (tltbNum.Text != "")
                {
                    for (int i = 0; i < numDat.RowCount; i++)
                    {
                        numDat.Rows[i].Selected = false;
                        for (int j = 0; j < numDat.ColumnCount; j++)
                        {
                            if (numDat.Rows[i].Cells[j].Value != null)
                            {
                                if (numDat.Rows[i].Cells[j].Value.ToString().Contains(tltbNum.Text))
                                {
                                    numDat.Rows[i].Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите значение в строку поиска!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Попробуйте снова. Код ошибки:");
            }
        }

        public void Next(DataGridView dG)
        {
            if (dG.RowCount != 0)
            {
                if (dG.CurrentCell.RowIndex != dG.Rows.Count - 1)
                    dG.CurrentCell = dG[0, (dG.CurrentCell.RowIndex + 1)];
            }
        }

        public void Back(DataGridView dG)
        {
            if (dG.RowCount != 0)
            {
                if (dG.CurrentCell.RowIndex != 0)
                    dG.CurrentCell = dG[0, (dG.CurrentCell.RowIndex - 1)];
            }
        }

        public void NextUp(DataGridView dG)
        {
            if (dG.RowCount != 0)
            {
                dG.CurrentCell = dG[0, (dG.Rows.Count - 1)];
            }
        }

        public void BackUp(DataGridView dG)
        {
            if (dG.RowCount != 0)
            {
                dG.CurrentCell = dG[0, 0];
            }
        }

        void saveToWord(DataGridView dataGrid, string nameFile, string zagolovok)
        {
            try
            {
                if (dataGrid.Rows.Count != 0)
                {
                    int RowCount = dataGrid.Rows.Count;
                    int ColumnCount = dataGrid.Columns.Count;
                    Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                    int r = 0;
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        for (r = 0; r <= RowCount - 1; r++)
                        {
                            DataArray[r, c] = dataGrid.Rows[r].Cells[c].Value;
                        }
                    }

                    Word.Document oDoc = new Word.Document();
                    oDoc.Application.Visible = true;

                    oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                    dynamic oRange = oDoc.Content.Application.Selection.Range;
                    string oTemp = "";
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        for (int c = 0; c <= ColumnCount - 1; c++)
                        {
                            oTemp = oTemp + DataArray[r, c] + "\t";

                        }
                    }

                    oRange.Text = oTemp;
                    object oMissing = Missing.Value;
                    object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                    object ApplyBorders = true;
                    object AutoFit = true;
                    object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                    oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                          Type.Missing, Type.Missing, ref ApplyBorders,
                                          Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                    oRange.Select();

                    oDoc.Application.Selection.Tables[1].Select();
                    oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                    oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                    oDoc.Application.Selection.Tables[1].Rows[1].Select();
                    oDoc.Application.Selection.InsertRowsAbove(1);
                    oDoc.Application.Selection.Tables[1].Rows[1].Select();

                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 0;
                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Times New Roman";
                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dataGrid.Columns[c].HeaderText;
                    }

                    oDoc.Application.Selection.Tables[1].Rows[1].Select();
                    oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                    {
                        Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                        headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                        headerRange.Text = zagolovok;
                        headerRange.Font.Size = 16;
                        headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    oDoc.SaveAs(nameFile, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении в WORD");
            }
        }

        public void toolStripButton36_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryOtdel, dGVOtdel);
        }

        private void toolStripButton30_Click(object sender, EventArgs e)
        {
            //string queryVibor = "SELECT * FROM План WHERE [Форма обучения]=";
            //manipulationDB.DeleteWithVibor(dGVOtdel, queryVibor, manipulationDB.queryOtdelDel);
        }

        private void toolStripButton37_Click(object sender, EventArgs e)
        {
            //string queryVibor = "SELECT * FROM План WHERE Отделение=";
            //manipulationDB.DeleteWithVibor(dGVFormObuch, queryVibor, manipulationDB.queryOtdelDel);
        }

        private void toolStripButton43_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryFormObuch, dGVFormObuch);
        }

        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.querySpec, dGVSpecial);
        }

        private void resetPlan_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryPlan, dGVPlan);
        }

        private void resetLI_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryLI, dGVLichInf);
        }

        private void resetZachisl_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryOtmZach, dGVOtmZach);
        }

        private void resetZhurnal_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryZhurnal, dGVZhurnalReg);
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            //string queryVibor = "SELECT * FROM План WHERE Специальность=";
            //manipulationDB.DeleteWithVibor(dGVFormObuch, queryVibor, manipulationDB.querySpecDel);
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
        //    manipulationDB.Delete(dGVZhurnalReg, manipulationDB.queryZhurnalDel);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //manipulationDB.Delete(dGVPlan, manipulationDB.queryPlanDel);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //string queryVibor = "SELECT * FROM [Журнал] WHERE [Личная информация]=";
            //manipulationDB.DeleteWithVibor(dGVLichInf, queryVibor, manipulationDB.queryFODel);
        }

        private void butAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tabMenu.SelectedTab.Text == "План приёма")
                {
                    InsertPlan insPlan = new InsertPlan();
                    insPlan.Show();
                }
                else if (tabMenu.SelectedTab.Text == "Личная информация")
                {
                    InsertLichnInfo insLi = new InsertLichnInfo();
                    insLi.Show();
                }
                else if (tabMenu.SelectedTab.Text == "Отметка о зачислении")
                {
                    InsertOtmZachisl insOtmZach = new InsertOtmZachisl();
                    insOtmZach.Show();
                }
                else if (tabMenu.SelectedTab.Text == "Журнал регистрации документов")
                {
                    InsertZnurnal insZhurnal = new InsertZnurnal();
                    insZhurnal.Show();
                }
                else if (tabMenu.SelectedTab.Text == "Специальность")
                {
                    InsertSpec insSpec = new InsertSpec();
                    insSpec.Show();
                }
                else if (tabMenu.SelectedTab.Text == "Отделение")
                {
                    InsertOtdel insOtdel = new InsertOtdel();
                    insOtdel.Show();
                }
                else if (tabMenu.SelectedTab.Text == "Форма обучения")
                {
                    InsertFObuch insFO = new InsertFObuch();
                    insFO.Show();
                }
                else if (tabMenu.SelectedTab.Text == "Паспортные данные")
                {
                    InsertPassport insPass = new InsertPassport();
                    insPass.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void butUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tabMenu.SelectedTab.Text == "План приёма")
                {
                    if (dGVPlan.SelectedCells.Count != 0)
                    {
                        string ID_spec = manipulationDB.generationID("SELECT ИД FROM Специальность WHERE Название='" + dGVPlan.CurrentRow.Cells[1].Value + "'");

                        string ID_otdel = manipulationDB.generationID("SELECT ИД FROM [Отделение] WHERE Наименование='" + dGVPlan.CurrentRow.Cells[2].Value + "'");

                        string ID_FO = manipulationDB.generationID("SELECT ИД FROM [Форма обучения] WHERE Наименование='" + dGVPlan.CurrentRow.Cells[3].Value + "'");

                        string ID_plan = manipulationDB.generationID("SELECT ИД FROM [План] WHERE Специальность='" + ID_spec + "' AND " +
                            "Отделение='" + ID_otdel + "' AND [Форма обучения]='" + ID_FO + "' AND " +
                            "Количество = '" + Convert.ToString(dGVPlan.CurrentRow.Cells[4].Value) + "' AND " +
                            "Класс='" + Convert.ToString(dGVPlan.CurrentRow.Cells[5].Value) + "'");

                        ZapisIndex(ID_plan);

                        UpdateFormPlan updPlan = new UpdateFormPlan();
                        updPlan.Show();
                        manipulationDB.SelectComboBox("SELECT * FROM Специальность", updPlan.cbSpec, "Название", "ИД");
                        manipulationDB.SelectComboBox("SELECT * FROM Отделение", updPlan.cbOtdel, "Наименование", "ИД");
                        manipulationDB.SelectComboBox("SELECT * FROM [Форма обучения]", updPlan.cbFormObuch, "Наименование", "ИД");
                        updPlan.cbSpec.Text = Convert.ToString(dGVPlan.CurrentRow.Cells[1].Value);
                        updPlan.cbOtdel.Text = Convert.ToString(dGVPlan.CurrentRow.Cells[2].Value);
                        updPlan.cbFormObuch.Text = Convert.ToString(dGVPlan.CurrentRow.Cells[3].Value);
                        updPlan.tbKolvo.Text = Convert.ToString(dGVPlan.CurrentRow.Cells[4].Value);
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                else if (tabMenu.SelectedTab.Text == "Личная информация")
                {
                    if (dGVLichInf.SelectedCells.Count != 0)
                    {
                        string ID_spec = manipulationDB.generationID("SELECT ИД FROM Специальность WHERE Название='" + dGVLichInf.CurrentRow.Cells[1].Value + "'");

                        string ID_otdel = manipulationDB.generationID("SELECT ИД FROM [Отделение] WHERE Наименование='" + dGVLichInf.CurrentRow.Cells[2].Value + "'");

                        //string ID_pass = manipulationDB.generationID("SELECT ИД FROM Паспорт WHERE Серия='" + dGVLichInf.CurrentRow.Cells[6].Value + "' AND " +
                        //    "Номер='"+ dGVLichInf.CurrentRow.Cells[7].Value + "' AND " +
                        //    "Идентификатор='"+ dGVLichInf.CurrentRow.Cells[8].Value + "'");

                        bool lgot = Convert.ToBoolean(dGVLichInf.CurrentRow.Cells[9].Value) == true ? true : false;
                        string ID_LI = manipulationDB.generationID("SELECT ИД FROM [Личная информация] WHERE Специальность='" + ID_spec + "' AND " +
                            "Отделение='" + ID_otdel + "' AND ФИО='" + Convert.ToString(dGVLichInf.CurrentRow.Cells[3].Value) + "' " +
                            "AND Гражданство='" + Convert.ToString(dGVLichInf.CurrentRow.Cells[4].Value) + "' " +
                            "AND Адрес='" + Convert.ToString(dGVLichInf.CurrentRow.Cells[5].Value) + "' " +
                            //"AND Паспорт='" + ID_pass + "' " +
                            "AND Льготы='" + lgot + "' " +
                            "AND Школа='" + Convert.ToString(dGVLichInf.CurrentRow.Cells[10].Value) + "' " +
                            "AND Класс='" + Convert.ToString(dGVLichInf.CurrentRow.Cells[12].Value) + "'");

                        ZapisIndex(ID_LI);

                        UpdateFormLichnInfo updLi = new UpdateFormLichnInfo();
                        updLi.Show();
                        manipulationDB.SelectComboBox("SELECT * FROM Специальность", updLi.cbSpec, "Название", "ИД");
                        manipulationDB.SelectComboBox("SELECT * FROM Отделение", updLi.cbOtdel, "Наименование", "ИД");
                        updLi.cbSpec.Text = Convert.ToString(dGVLichInf.CurrentRow.Cells[1].Value);
                        updLi.cbOtdel.Text = Convert.ToString(dGVLichInf.CurrentRow.Cells[2].Value);
                        updLi.tbFIO.Text = Convert.ToString(dGVLichInf.CurrentRow.Cells[3].Value);
                        updLi.tbGrazhd.Text = Convert.ToString(dGVLichInf.CurrentRow.Cells[4].Value);
                        updLi.tbAdress.Text = Convert.ToString(dGVLichInf.CurrentRow.Cells[5].Value);
                        updLi.tbSeria.Text = Convert.ToString(dGVLichInf.CurrentRow.Cells[6].Value);
                        updLi.tbNum.Text = Convert.ToString(dGVLichInf.CurrentRow.Cells[7].Value);
                        updLi.tbId.Text = Convert.ToString(dGVLichInf.CurrentRow.Cells[8].Value);
                        updLi.lgoti.Checked = Convert.ToBoolean(dGVLichInf.CurrentRow.Cells[9].Value) == true ? true : false;
                        updLi.tbSchool.Text = Convert.ToString(dGVLichInf.CurrentRow.Cells[10].Value);
                        updLi.tbSrednBall.Text = Convert.ToString(dGVLichInf.CurrentRow.Cells[11].Value);
                        updLi.mCbClass.Text = Convert.ToString(dGVLichInf.CurrentRow.Cells[12].Value);
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                else if (tabMenu.SelectedTab.Text == "Отметка о зачислении")
                {
                    if (dGVOtmZach.SelectedCells.Count != 0)
                    {
                        string ID_Otm = manipulationDB.generationID("SELECT ИД FROM [Отметка о зачислении] WHERE Дата ='" + Convert.ToString(dGVOtmZach.CurrentRow.Cells[1].Value) + "' " +
                            "AND [Номер приказа]='" + Convert.ToString(dGVOtmZach.CurrentRow.Cells[2].Value) + "'");

                        ZapisIndex(ID_Otm);

                        UpdateFormOtmZachisl updOtmZach = new UpdateFormOtmZachisl();
                        updOtmZach.Show();
                        updOtmZach.tbDate.Text = Convert.ToString(dGVOtmZach.CurrentRow.Cells[1].Value);
                        updOtmZach.tbNumPrikaz.Text = Convert.ToString(dGVOtmZach.CurrentRow.Cells[2].Value);
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                //
                else if (tabMenu.SelectedTab.Text == "Журнал регистрации документов")
                {
                    if (dGVZhurnalReg.SelectedCells.Count != 0)
                    {
                        string ID_LI = manipulationDB.generationID("SELECT ИД FROM [Личная информация] WHERE ФИО='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[2].Value) + "' " +
                            "AND Гражданство='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[3].Value) + "'" +
                            " AND Адрес='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[4].Value) + "'");

                        if (Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[10].Value) == "" && Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[11].Value)=="")
                        {

                            bool obsh = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[7].Value) == true ? true : false;
                            bool dogovorSOrgan = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[8].Value) == true ? true : false;
                            bool otmzach = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[9].Value) == true ? true : false;
                            bool otmOtkaz = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[12].Value) == true ? true : false;
                            bool omtOVozvrat = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[13].Value) == true ? true : false;

                            string ID_Zhurnal = manipulationDB.generationID("SELECT ИД FROM Журнал WHERE" +
                                //" [Дата приема]='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[1].Value) + "' " +
                                " [Личная информация]='" + ID_LI + "'" +
                                " AND Документы='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[5].Value) + "' " +
                                "AND [Нужда в общежитии]='" + obsh + "' " +
                                "AND Договор='" + dogovorSOrgan + "' " +
                                "AND [Отметка о зачислении]='" + otmzach + "' " +
                                //"AND Отметка='" + DBNull.Value + "' " +
                                "AND [Отметка об отказе в зачислении]='" + otmOtkaz + "'" +
                                " AND [Отметка о возврате]='" + omtOVozvrat + "'");
                            ZapisIndex(ID_Zhurnal);
                        }
                        else
                        {
                            string ID_Otm = manipulationDB.generationID("SELECT ИД FROM [Отметка о зачислении] WHERE Дата ='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[10].Value) + "' " +
                               "AND [Номер приказа]='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[11].Value) + "'");

                            bool obsh = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[7].Value) == true ? true : false;
                            bool dogovorSOrgan = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[8].Value) == true ? true : false;
                            bool otmzach = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[9].Value) == true ? true : false;
                            bool otmOtkaz = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[12].Value) == true ? true : false;
                            bool omtOVozvrat = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[13].Value) == true ? true : false;

                            string ID_Zhurnal = manipulationDB.generationID("SELECT ИД FROM Журнал WHERE" +
                                //" [Дата приема]='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[1].Value) + "' " +
                                " [Личная информация]='" + ID_LI + "'" +
                                " AND Документы='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[5].Value) + "' " +
                                "AND [Нужда в общежитии]='" + obsh + "' " +
                                "AND Договор='" + dogovorSOrgan + "' " +
                                "AND [Отметка о зачислении]='" + otmzach + "' " +
                                //"AND Отметка='" + ID_Otm + "' " +
                                "AND [Отметка об отказе в зачислении]='" + otmOtkaz + "'" +
                                " AND [Отметка о возврате]='" + omtOVozvrat + "'");
                            ZapisIndex(ID_Zhurnal);
                        }

                        UpdateFormZhurnal updZhurnal = new UpdateFormZhurnal();
                        updZhurnal.Show();
                        updZhurnal.tbDate.Text = Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[1].Value);
                        manipulationDB.SelectComboBox("SELECT * FROM [Личная информация]", updZhurnal.cbFIO, "ФИО", "ИД");
                        updZhurnal.cbFIO.Text = Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[2].Value);
                        updZhurnal.tbGrazdh.Text = Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[3].Value);
                        updZhurnal.tbAddress.Text = Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[4].Value);
                        updZhurnal.tbDoc.Text = Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[5].Value);
                        updZhurnal.lgot.Checked = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[6].Value) == true ? true : false;
                        updZhurnal.obshezh.Checked = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[7].Value) == true ? true : false;
                        updZhurnal.dogovorsorg.Checked = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[8].Value) == true ? true : false;
                        updZhurnal.otmozachisl.Checked = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[9].Value) == true ? true : false;
                        updZhurnal.NumDogovor.Text = Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[11].Value);
                        updZhurnal.DateDogovor.Text = Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[10].Value);
                        updZhurnal.otmotkaz.Checked = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[12].Value) == true ? true : false;
                        updZhurnal.otmetkaovozrate.Checked = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[13].Value) == true ? true : false;
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                else if (tabMenu.SelectedTab.Text == "Специальность")
                {
                    if (dGVSpecial.SelectedCells.Count != 0)
                    {
                        string ID_spec = manipulationDB.generationID("SELECT ИД FROM Специальность WHERE Название='" + Convert.ToString(dGVSpecial.CurrentRow.Cells[1].Value) + "' " +
                            "AND Код='" + Convert.ToString(dGVSpecial.CurrentRow.Cells[2].Value) + "'");

                        ZapisIndex(ID_spec);

                        UpdateFormSpec updSpec = new UpdateFormSpec();
                        updSpec.Show();
                        updSpec.tbNam.Text = Convert.ToString(dGVSpecial.CurrentRow.Cells[1].Value);
                        updSpec.tbKod.Text = Convert.ToString(dGVSpecial.CurrentRow.Cells[2].Value);
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                else if (tabMenu.SelectedTab.Text == "Отделение")
                {
                    if (dGVOtdel.SelectedCells.Count != 0)
                    {
                        string ID_otdel = manipulationDB.generationID("SELECT ИД FROM [Отделение] WHERE Наименование='" + Convert.ToString(dGVOtdel.CurrentRow.Cells[1].Value) + "'");

                        ZapisIndex(ID_otdel);

                        UpdateFormOtdel updOtdel = new UpdateFormOtdel();
                        updOtdel.Show();
                        updOtdel.tbName.Text = Convert.ToString(dGVOtdel.CurrentRow.Cells[1].Value);
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                else if (tabMenu.SelectedTab.Text == "Форма обучения")
                {
                    if (dGVFormObuch.SelectedCells.Count != 0)
                    {
                        string id_FO = manipulationDB.generationID("SELECT ИД FROM [Форма обучения]" +
                            " WHERE Наименование='" + Convert.ToString(dGVFormObuch.CurrentRow.Cells[1].Value) + "'");

                        ZapisIndex(id_FO);

                        UpdateFormObuch updFO = new UpdateFormObuch();
                        updFO.Show();
                        updFO.tbNamFO.Text = Convert.ToString(dGVFormObuch.CurrentRow.Cells[1].Value);

                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                else if (tabMenu.SelectedTab.Text == "Паспортные данные")
                {
                    if (dGVPass.SelectedCells.Count != 0)
                    {
                        string ID_pass = manipulationDB.generationID("SELECT ИД FROM Паспорт WHERE Серия='" + Convert.ToString(dGVPass.CurrentRow.Cells[1].Value) + "'AND " +
                            "Номер='" + Convert.ToString(dGVPass.CurrentRow.Cells[2].Value) + "'");

                        ZapisIndex(ID_pass);
                        UpdateFormPassport updPass = new UpdateFormPassport();
                        updPass.Show();
                        updPass.tbSeria.Text = Convert.ToString(dGVPass.CurrentRow.Cells[1].Value);
                        updPass.tbNum.Text = Convert.ToString(dGVPass.CurrentRow.Cells[2].Value);
                        updPass.tbId.Text = Convert.ToString(dGVPass.CurrentRow.Cells[3].Value);
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            finally
            {
                connect.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton43_Click_1(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryFormObuch, dGVFormObuch);
        }

        private void resetPlan_Click_1(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryPlan, dGVPlan);
        }

        private void ControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void ControlForm_VisibleChanged(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void ReplaceStub(string stubToReplace, string text, Word.Document worldDocument)
        {
            var range = worldDocument.Content;
            range.Find.ClearFormatting();
            object wdReplaceAll = Word.WdReplace.wdReplaceAll;
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text, Replace: wdReplaceAll);
            range.EndOf();
        }

        Word.Application oWord = new Word.Application();
        //public void GetDoc(string path)
        //{
        //    _Document oDoc = oWord.Documents.Add("d:\\C#_project\\шаблон Word\\шаблон Word\\Templates\\referat.dot");
        //    SetTemplate(oDoc);

        //}

        private void SetTemplate(Document oDoc)
        {

            //for (int i = 0; i < dGVPlan.Rows.Count; i++)
            //{
            //    ReplaceStub("{num}", Convert.ToString(dGVPlan.Rows[i].Cells[0].Value), wordDoc);
            //    ReplaceStub("{spec}", Convert.ToString(dGVPlan.Rows[i].Cells[1].Value), wordDoc);
            //    ReplaceStub("{otdel}", Convert.ToString(dGVPlan.Rows[i].Cells[2].Value), wordDoc);
            //    ReplaceStub("{form}", Convert.ToString(dGVPlan.Rows[i].Cells[3].Value), wordDoc);
            //    ReplaceStub("{kolvo}", Convert.ToString(dGVPlan.Rows[i].Cells[4].Value), wordDoc);

            //    //    oDoc.Bookmarks["{num}"].Range.Text = Convert.ToString(dGVPlan.Rows[i].Cells[0].Value);
            //    //    oDoc.Bookmarks["{spec}"].Range.Text = Convert.ToString(dGVPlan.Rows[i].Cells[1].Value);
            //    //    oDoc.Bookmarks["{otdel}"].Range.Text = Convert.ToString(dGVPlan.Rows[i].Cells[2].Value);
            //    //    oDoc.Bookmarks["{form}"].Range.Text = Convert.ToString(dGVPlan.Rows[i].Cells[3].Value);
            //    //    oDoc.Bookmarks["{kolvo}"].Range.Text = Convert.ToString(dGVPlan.Rows[i].Cells[4].Value);
            //}

        }

        private void resetLI_Click_1(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryLI, dGVLichInf);
        }

        private void findPlan_Click(object sender, EventArgs e)
        {
            Find(dGVPlan, tbFind);
        }

        private void resetSvodnVedom_Click(object sender, EventArgs e)
        {
        }

        private void resetPass_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryPassport, dGVPass);
        }

        private void resetZachisl_Click_1(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryOtmZach, dGVOtmZach);
        }

        private void resetZhurnal_Click_1(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryZhurnal, dGVZhurnalReg);
        }

        private void resetSpec_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.querySpec, dGVSpecial);
        }

        private void resetOtdel_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryOtdel, dGVOtdel);
        }

        private void findZhurnal_Click(object sender, EventArgs e)
        {
            Find(dGVZhurnalReg, toolStripTextBox6);
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            Find(dGVPass, toolStripTextBox14);
        }

        private void toolStripButton49_Click(object sender, EventArgs e)
        {
            Find(dGVSvodnVedom, toolStripTextBox16);
        }

        private void toolStripButton42_Click(object sender, EventArgs e)
        {
            Find(dGVFormObuch, toolStripTextBox12);
        }

        private void findLI_Click(object sender, EventArgs e)
        {
            Find(dGVLichInf, toolStripTextBox2);
        }

        private void toolStripButton35_Click(object sender, EventArgs e)
        {
            Find(dGVOtdel, toolStripTextBox10);
        }

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            Find(dGVSpecial, toolStripTextBox8);
        }

        private void findZach_Click(object sender, EventArgs e)
        {
            Find(dGVOtmZach, toolStripTextBox2);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            //string queryViborOtm = "SELECT * FROM Журнал WHERE Отметка = ";
            //manipulationDB.DeleteWithVibor(dGVOtmZach, queryViborOtm, manipulationDB.queryOtmZachDel);
        }

        private void toolStripButton23_Click_1(object sender, EventArgs e)
        {
            //string queryViborSpec = "SELECT * FROM [Личная информация] WHERE Специальность = ";
            //manipulationDB.DeleteWithVibor(dGVSpecial, queryViborSpec, manipulationDB.querySpecDel);
        }

        private void toolStripButton30_Click_1(object sender, EventArgs e)
        {
            //manipulationDB.Delete(dGVOtdel, manipulationDB.queryOtdelDel);
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            //string queryViborZhurnal = "SELECT * FROM Журнал WHERE [Личная информация] = ";
            //manipulationDB.DeleteWithVibor(dGVLichInf, queryViborZhurnal, manipulationDB.queryLIDel); // true личная информация
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            //manipulationDB.Delete(dGVPlan, manipulationDB.queryPlanDel); //true план
        }

        private void toolStripButton37_Click_1(object sender, EventArgs e)
        {
            //string queryViborPlan = "SELECT * FROM План WHERE [Форма обучения] = ";
            //manipulationDB.DeleteWithVibor(dGVFormObuch, queryViborPlan, manipulationDB.queryFormObuchDel);
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            //string queryViborLI = "SELECT * FROM [Личная информция] WHERE [Паспорт] = ";
            //manipulationDB.DeleteWithVibor(dGVPass, queryViborLI, manipulationDB.queryPassportDel);
        }

        private void toolStripButton16_Click_1(object sender, EventArgs e)
        {
/*            manipulationDB.Delete(dGVZhurnalReg, manipulationDB.queryZhurnalDel);*/ //true журнал регистрации
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string KolVo = "";
            string queryIdOtm = "SELECT SUM(Количество) FROM План " +
                "WHERE Специальность = @spec AND Отделение = @otdel AND Класс = @class";
            connect.Open();
            SqlCommand comm = new SqlCommand(queryIdOtm, connect);
            comm.Parameters.AddWithValue("@spec", cbSpecialnost.SelectedValue);
            comm.Parameters.AddWithValue("@otdel", cbOtdel.SelectedValue);
            comm.Parameters.AddWithValue("@class", cbClass.Text);
            if (comm.ExecuteScalar() == null || comm.ExecuteScalar().ToString() == "")
            {
                KolVo = "0";
                MessageBox.Show("Плана по нельготникам по заданным параметрам не существует!!! ", "Плана не существует!");
            }
            else
            {
                KolVo = comm.ExecuteScalar().ToString();
            }
            connect.Close();

            string shifr = "";

            if (cbSpecialnost.Text == "ПОИТ" && cbClass.Text == "9")
            {
                shifr = "ПО";
            }
            else if (cbSpecialnost.Text == "ПОИТ" && cbClass.Text == "11")
            {
                shifr = "CПО";
            }
            else if (cbSpecialnost.Text == "БУАИК" && cbClass.Text == "9")
            {
                shifr = "Б";
            }
            else if (cbSpecialnost.Text == "БУАИК" && cbClass.Text == "11")
            {
                shifr = "СБ";
            }
            else if (cbSpecialnost.Text == "ДОУ" && cbClass.Text == "9")
            {
                shifr = "ДО";
            }

            string querySpisokStudentod = "SELECT TOP(" + KolVo + ") ROW_NUMBER() over (ORDER BY [Личная информация].[Средний балл] DESC) ИД, " +
                "CAST([Личная информация].ИД AS nvarchar) + '" + shifr + "' AS Шифр, " +
                "[Личная информация].ФИО, [Личная информация].[Средний балл], [Личная информация].Адрес, [Личная информация].Школа, [Личная информация].Льготы, " +
                "CAST('' AS nvarchar) +'Зачислить' AS [Решение приёмной комиссии]" +
                "FROM [Личная информация] LEFT JOIN Журнал ON [Личная информация].ИД=Журнал.[Личная информация] " +
                "WHERE [Личная информация].Специальность='" + cbSpecialnost.SelectedValue + "' AND [Личная информация].Отделение='" + cbOtdel.SelectedValue + "' AND [Личная информация].Льготы='0'" +
                " AND [Личная информация].Класс='" + cbClass.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(querySpisokStudentod, connect);
            connect.Open();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dGVSvodnVedom.DataSource = dt;
            connect.Close();

            string querySpisokStudentodlgoti = "SELECT ROW_NUMBER() over (ORDER BY [Личная информация].[Средний балл] DESC) ИД, " +
                "CAST([Личная информация].ИД AS nvarchar) + '" + shifr + "' AS Шифр, " +
                "[Личная информация].ФИО, [Личная информация].[Средний балл], [Личная информация].Адрес, [Личная информация].Школа, [Личная информация].Льготы, " +
                "CAST('' AS nvarchar) +'Зачислить' AS [Решение приёмной комиссии]" +
                "FROM [Личная информация] LEFT JOIN Журнал ON [Личная информация].ИД=Журнал.[Личная информация] " +
                "WHERE [Личная информация].Специальность='" + cbSpecialnost.SelectedValue + "' AND [Личная информация].Отделение='" + cbOtdel.SelectedValue + "' AND [Личная информация].Льготы='1' " +
                "AND [Личная информация].Класс='" + cbClass.Text + "'";
            SqlDataAdapter adapter1 = new SqlDataAdapter(querySpisokStudentodlgoti, connect);
            connect.Open();
            //DataTable dt1 = new DataTable();
            adapter1.Fill(dt);
            dGVSvodnVedom.DataSource = dt;
            connect.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BackUp(dGVPass);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Back(dGVPass);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Next(dGVPass);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            NextUp(dGVPass);
        }

        private void resetZhurnal_Click_2(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryZhurnal, dGVZhurnalReg);
        }

        private void findZhurnal_Click_1(object sender, EventArgs e)
        {
            Find(dGVZhurnalReg, toolStripTextBox6);
        }

        private void resetSpec_Click_1(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.querySpec, dGVSpecial);
        }

        private void toolStripButton23_Click_2(object sender, EventArgs e)
        {
            string ID_spec = manipulationDB.generationID("SELECT ИД FROM Специальность WHERE Название='" + Convert.ToString(dGVSpecial.CurrentRow.Cells[1].Value) + "' " +
                            "AND Код='" + Convert.ToString(dGVSpecial.CurrentRow.Cells[2].Value) + "'");

            string queryVibor = "SELECT * FROM План WHERE Специальность=";
            manipulationDB.DeleteWithVibor(dGVSpecial, queryVibor, manipulationDB.querySpecDel, ID_spec);
        }

        private void toolStripButton16_Click_2(object sender, EventArgs e)
        {
            string ID_LI = manipulationDB.generationID("SELECT ИД FROM [Личная информация] WHERE ФИО='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[2].Value) + "' " +
                           "AND Гражданство='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[3].Value) + "'" +
                           " AND Адрес='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[4].Value) + "'");

            string ID_Otm = manipulationDB.generationID("SELECT ИД FROM [Отметка о зачислении] WHERE Дата ='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[10].Value) + "' " +
               "AND [Номер приказа]='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[11].Value) + "'");

            bool obsh = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[7].Value) == true ? true : false;
            bool dogovorSOrgan = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[8].Value) == true ? true : false;
            bool otmzach = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[9].Value) == true ? true : false;
            bool otmOtkaz = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[12].Value) == true ? true : false;
            bool omtOVozvrat = Convert.ToBoolean(dGVZhurnalReg.CurrentRow.Cells[13].Value) == true ? true : false;

            string ID_Zhurnal = manipulationDB.generationID("SELECT ИД FROM Журнал WHERE " +
                "[Дата приема]='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[1].Value) + "' " +
                "AND [Личная информация]='" + ID_LI + "'" +
                " AND Документы='" + Convert.ToString(dGVZhurnalReg.CurrentRow.Cells[5].Value) + "' " +
                "AND [Нужда в общежитии]='" + obsh + "' " +
                "AND Договор='" + dogovorSOrgan + "' " +
                "AND [Отметка о зачислении]='" + otmzach + "' " +
                "AND Отметка='" + ID_Otm + "' " +
                "AND [Отметка об отказе в зачислении]='" + otmOtkaz + "'" +
                " AND [Отметка о возврате]='" + omtOVozvrat + "'");

            manipulationDB.Delete(dGVZhurnalReg, manipulationDB.queryZhurnalDel, ID_Zhurnal);
             
        }

        private void toolStripButton2_Click_2(object sender, EventArgs e)
        {
            string ID_spec = manipulationDB.generationID("SELECT ИД FROM Специальность WHERE Название='" + dGVLichInf.CurrentRow.Cells[1].Value + "'");

            string ID_otdel = manipulationDB.generationID("SELECT ИД FROM [Отделение] WHERE Наименование='" + dGVLichInf.CurrentRow.Cells[2].Value + "'");

            //string ID_pass = manipulationDB.generationID("SELECT ИД FROM Паспорт WHERE Серия='" + dGVLichInf.CurrentRow.Cells[6].Value + "' AND " +
            //    "Номер='"+ dGVLichInf.CurrentRow.Cells[7].Value + "' AND " +
            //    "Идентификатор='"+ dGVLichInf.CurrentRow.Cells[8].Value + "'");

            bool lgot = Convert.ToBoolean(dGVLichInf.CurrentRow.Cells[9].Value) == true ? true : false;
            string ID_LI = manipulationDB.generationID("SELECT ИД FROM [Личная информация] WHERE Специальность='" + ID_spec + "' AND " +
                "Отделение='" + ID_otdel + "' AND ФИО='" + Convert.ToString(dGVLichInf.CurrentRow.Cells[3].Value) + "' " +
                "AND Гражданство='" + Convert.ToString(dGVLichInf.CurrentRow.Cells[4].Value) + "' " +
                "AND Адрес='" + Convert.ToString(dGVLichInf.CurrentRow.Cells[5].Value) + "' " +
                //"AND Паспорт='" + ID_pass + "' " +
                "AND Льготы='" + lgot + "' " +
                "AND Школа='" + Convert.ToString(dGVLichInf.CurrentRow.Cells[10].Value) + "' " +
                "AND Класс='" + Convert.ToString(dGVLichInf.CurrentRow.Cells[12].Value) + "'");

            string queryVibor = "SELECT * FROM [Журнал] WHERE [Личная информация]=";
            manipulationDB.DeleteWithVibor(dGVLichInf, queryVibor, manipulationDB.queryLIDel, ID_LI);
        }

        private void resetFO_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryFormObuch, dGVFormObuch);
        }

        private void resetPass_Click_1(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryPassport, dGVPass);

            for (int i = 0; i < dGVPass.RowCount; i++)
            {
                dGVPass[3, i].Value = shifr_PBKDF2.Decrypt(Convert.ToString(dGVPass[3, i].Value), "822822");
            }
        }

        private void resetLI_Click_2(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryLI, dGVLichInf);

            for (int i = 0; i < dGVLichInf.RowCount; i++)
            {
                dGVLichInf[8, i].Value = shifr_PBKDF2.Decrypt(Convert.ToString(dGVLichInf[8, i].Value), "822822");
            }
        }

        private void resetPlan_Click_2(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryPlan, dGVPlan);
        }

        private void resetOtdel_Click_1(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryOtdel, dGVOtdel);
        }

        private void resetZachisl_Click_2(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryOtmZach, dGVOtmZach);
        }

        private void findZach_Click_1(object sender, EventArgs e)
        {
            Find(dGVOtmZach, toolStripTextBox4);
        }

        private void toolStripButton35_Click_1(object sender, EventArgs e)
        {
            Find(dGVOtdel, toolStripTextBox10);
        }

        private void findPlan_Click_1(object sender, EventArgs e)
        {
            Find(dGVPlan, tbFind);
        }

        private void findLI_Click_1(object sender, EventArgs e)
        {
            Find(dGVLichInf, toolStripTextBox2);
        }

        private void toolStripButton21_Click_1(object sender, EventArgs e)
        {
            Find(dGVPass, toolStripTextBox14);
        }

        private void toolStripButton42_Click_1(object sender, EventArgs e)
        {
            Find(dGVFormObuch, toolStripTextBox12);
        }

        private void toolStripButton28_Click_1(object sender, EventArgs e)
        {
            Find(dGVSpecial, toolStripTextBox8);
        }

        private void toolStripButton37_Click_2(object sender, EventArgs e)
        {
            string id_FO = manipulationDB.generationID("SELECT ИД FROM [Форма обучения]" +
                            " WHERE Наименование='" + Convert.ToString(dGVFormObuch.CurrentRow.Cells[1].Value) + "'");

            string queryVibor = "SELECT * FROM План WHERE [Форма обучения]=";
            manipulationDB.DeleteWithVibor(dGVFormObuch, queryVibor, manipulationDB.queryFODel, id_FO);
        }

        private void toolStripButton15_Click_1(object sender, EventArgs e)
        {
            string ID_pass = manipulationDB.generationID("SELECT ИД FROM Паспорт WHERE Серия='" + Convert.ToString(dGVPass.CurrentRow.Cells[1].Value) + "'AND " +
                            "Номер='" + Convert.ToString(dGVPass.CurrentRow.Cells[2].Value) + "'AND" +
                            " Идентификатор='" + Convert.ToString(dGVPass.CurrentRow.Cells[3].Value) + "'");

            string queryVibor = "SELECT * FROM [Личная информация] WHERE Паспорт=";
            manipulationDB.DeleteWithVibor(dGVPass, queryVibor, manipulationDB.queryPassportDel, ID_pass);
        }

        private void bindingNavigatorDeleteItem_Click_2(object sender, EventArgs e)
        {
            string ID_spec = manipulationDB.generationID("SELECT ИД FROM Специальность WHERE Название='" + dGVPlan.CurrentRow.Cells[1].Value + "'");

            string ID_otdel = manipulationDB.generationID("SELECT ИД FROM [Отделение] WHERE Наименование='" + dGVPlan.CurrentRow.Cells[2].Value + "'");

            string ID_FO = manipulationDB.generationID("SELECT ИД FROM [Форма обучения] WHERE Наименование='" + dGVPlan.CurrentRow.Cells[3].Value + "'");

            string ID_plan = manipulationDB.generationID("SELECT ИД FROM [План] WHERE Специальность='" + ID_spec + "' AND " +
                "Отделение='" + ID_otdel + "' AND [Форма обучения]='" + ID_FO + "' AND " +
                "Количество = '" + Convert.ToString(dGVPlan.CurrentRow.Cells[4].Value) + "' AND " +
                "Класс='" + Convert.ToString(dGVPlan.CurrentRow.Cells[5].Value) + "'");

            manipulationDB.Delete(dGVPlan, manipulationDB.queryPlanDel, ID_plan);
        }

        private void toolStripButton30_Click_2(object sender, EventArgs e)
        {
            string ID_otdel = manipulationDB.generationID("SELECT ИД FROM [Отделение] WHERE Наименование='" + Convert.ToString(dGVOtdel.CurrentRow.Cells[1].Value) + "'");

            string queryVibor = "SELECT * FROM План WHERE Отделение=";
            manipulationDB.DeleteWithVibor(dGVOtdel, queryVibor, manipulationDB.queryOtdelDel, ID_otdel);
        }

        private void toolStripButton9_Click_1(object sender, EventArgs e)
        {
            string ID_Otm = manipulationDB.generationID("SELECT ИД FROM [Отметка о зачислении] WHERE Дата ='" + Convert.ToString(dGVOtmZach.CurrentRow.Cells[1].Value) + "' " +
                            "AND [Номер приказа]='" + Convert.ToString(dGVOtmZach.CurrentRow.Cells[2].Value) + "'");

            string queryVibor = "SELECT * FROM План WHERE Специальность=";
            manipulationDB.DeleteWithVibor(dGVOtmZach, queryVibor, manipulationDB.querySpecDel, ID_Otm);
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            BackUp(dGVSpecial);
        }

        private void toolStripButton25_Click(object sender, EventArgs e)
        {
            Back(dGVSpecial);
        }

        private void toolStripButton26_Click(object sender, EventArgs e)
        {
            Next(dGVSpecial);
        }

        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            NextUp(dGVSpecial);
        }

        private void toolStripButton38_Click(object sender, EventArgs e)
        {
            BackUp(dGVFormObuch);
        }

        private void toolStripButton39_Click(object sender, EventArgs e)
        {
            Back(dGVFormObuch);
        }

        private void toolStripButton40_Click(object sender, EventArgs e)
        {
            Next(dGVFormObuch);
        }

        private void toolStripButton41_Click(object sender, EventArgs e)
        {
            NextUp(dGVFormObuch);
        }

        private void toolStripButton44_Click(object sender, EventArgs e)
        {
            BackUp(dGVSvodnVedom);
        }

        private void toolStripButton45_Click(object sender, EventArgs e)
        {
            Back(dGVSvodnVedom);
        }

        private void toolStripButton46_Click(object sender, EventArgs e)
        {
            Next(dGVSvodnVedom);
        }

        private void toolStripButton47_Click(object sender, EventArgs e)
        {
            NextUp(dGVSvodnVedom);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            BackUp(dGVLichInf);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Back(dGVLichInf);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Next(dGVLichInf);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            NextUp(dGVLichInf);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            BackUp(dGVPlan);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            Back(dGVPlan);
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            Next(dGVPlan);
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            NextUp(dGVPlan);
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            BackUp(dGVZhurnalReg);
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            Back(dGVZhurnalReg);
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            Next(dGVZhurnalReg);
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            NextUp(dGVZhurnalReg);
        }

        private void toolStripButton31_Click(object sender, EventArgs e)
        {
            BackUp(dGVOtdel);
        }

        private void toolStripButton32_Click(object sender, EventArgs e)
        {
            Back(dGVOtdel);
        }

        private void toolStripButton33_Click(object sender, EventArgs e)
        {
            Next(dGVOtdel);
        }

        private void toolStripButton34_Click(object sender, EventArgs e)
        {
            NextUp(dGVOtdel);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            BackUp(dGVOtmZach);
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Back(dGVOtmZach);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            Next(dGVOtmZach);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            NextUp(dGVOtmZach);
        }


        private void toolStripButton22_Click_1(object sender, EventArgs e)
        {
            saveToWord(dGVZhurnalReg, "Журнал регистрации документов", "Журнал регистрации документов");
        }

        private void toolStripButton29_Click_1(object sender, EventArgs e)
        {
            saveToWord(dGVPlan, "План приёма", "План приёма");
        }

        private void toolStripButton36_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Открываем шаблон

                DateTime moment = new DateTime();
                int year = moment.Year;
                string yearNow = DateTime.Now.Year.ToString();

                string special = "";
                if(cbSpecialnost.Text == "ПОИТ")
                {
                    special = "Программное обеспечение информационных технологий";
                }
                else if(cbSpecialnost.Text == "БУАИК")
                {
                    special = "Бухгалтерский учет, анализ и контроль";
                }
                else if (cbSpecialnost.Text == "ДОУ")
                {
                    special = "Документационное обеспечение управления";
                }
                for (int i = 0; i < dGVSvodnVedom.Rows.Count; i++)
                {
                    var wordApp = new Word.Application();
                    var wordDoc = wordApp.Documents.Open(Application.StartupPath + @"\Шаблоны WORD\Извещение о зачислении.docx");

                    ReplaceStub("{FIO}", Convert.ToString(dGVSvodnVedom.Rows[i].Cells[2].Value), wordDoc);
                    ReplaceStub("{ADDRESS}", Convert.ToString(dGVSvodnVedom.Rows[i].Cells[4].Value), wordDoc);
                    ReplaceStub("{formob}", cbOtdel.Text, wordDoc);
                    ReplaceStub("{spec}", special, wordDoc);
                    ReplaceStub("{num_prik}", "0000" , wordDoc);
                    ReplaceStub("{dateprikaz}", "31.08."+yearNow, wordDoc);
                    wordDoc.SaveAs2(Application.StartupPath + @"\Зачисленные\" + Convert.ToString(dGVSvodnVedom.Rows[i].Cells[2].Value) + ".docx");
                    wordDoc.Close();
                }

                MessageBox.Show("Документы сформированы!", "Отчёт");

            ///Может быть много таких меток
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //  _Document oDoc = GetDoc(Environment.CurrentDirectory + "\\Templates\\referat.dot");
            //Document oDoc = oWord.Documents.Add(@"F:\ДИПЛОМ\Автоматизированная система для приемной комиссии УО НГАЭК\Шаблоны WORD\Контрольные цифры приёма.docx");
            //SetTemplate(oDoc);
            //oDoc.SaveAs(@"E:\КЦП2.docx");
            //oDoc.Close();
        }

        private void связьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectWithRazrab svyaz = new ConnectWithRazrab();
            svyaz.ShowDialog();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgrammInfoBox pIB = new ProgrammInfoBox();
            pIB.ShowDialog();
        }

        private void tabMenu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (UsersTF.user==1 || UsersTF.user==2)
            {
                if (tabMenu.SelectedTab == tabPageSvodnVedom)
                {
                    gPDopMenu.Visible = true;
                    gPMenuControl.Visible = false;
                }
                else
                {
                    gPDopMenu.Visible = false;
                    gPMenuControl.Visible = true;
                }
            }
        }

        private void регистрацияНовогоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrationUser registrationUser = new RegistrationUser();
            registrationUser.Show();
        }

        private void просмотрИИзменениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllUsers showUser = new AllUsers();
            showUser.ShowDialog();
            this.Hide();
        }

        private void toolStripButton43_Click_2(object sender, EventArgs e)
        {
            try
            {
                //Открываем шаблон

                DateTime moment = new DateTime();
                int year = moment.Year;
                string yearNow = DateTime.Now.Year.ToString();
                string monthNow = DateTime.Now.Month.ToString();
                string dayNow = DateTime.Now.Day.ToString();

                string special = "";
                string nameSpec = "";
                string srokObuch = "";
                string specializ = "";
                if (cbSpecialnost.Text == "ПОИТ" && cbOtdel.Text=="дневное" && cbClass.Text=="11")
                {
                    special = "2-40 01 01	«Программное обеспечение информационных технологий»";
                    nameSpec = "техник-программист";
                    srokObuch = "2 года 8 месяцев";
                    specializ = "2-40 01 01 35 «Программное обеспечение экономической и деловой информации»";
                }
                else if (cbSpecialnost.Text == "ПОИТ" && cbOtdel.Text == "дневное" && cbClass.Text == "9")
                {
                    special = "2-40 01 01	«Программное обеспечение информационных технологий»";
                    nameSpec = "техник-программист";
                    srokObuch = "3 года 8 месяцев";
                    specializ = "2-40 01 01 35 «Программное обеспечение экономической и деловой информации»";
                }
                else if (cbSpecialnost.Text == "ПОИТ" && cbOtdel.Text == "заочное")
                {
                    special = "2-40 01 01	«Программное обеспечение информационных технологий»";
                    nameSpec = "техник-программист";
                    srokObuch = "3 года 8 месяцев";
                    specializ = "2-40 01 01 35 «Программное обеспечение экономической и деловой информации»";
                }
                else if (cbSpecialnost.Text == "БУАИК" && cbOtdel.Text == "дневное" && cbClass.Text == "11")
                {
                    special = "Бухгалтерский учет, анализ и контроль";
                    nameSpec = "бухгалтер";
                    srokObuch = "1 года 10 месяцев";
                    specializ = "3-40 01 01 35 «Бухгалтерия экономической и деловой информации»";
                }
                else if (cbSpecialnost.Text == "БУАИК" && cbOtdel.Text == "дневное" && cbClass.Text == "9")
                {
                    special = "Бухгалтерский учет, анализ и контроль";
                    nameSpec = "бухгалтер";
                    srokObuch = "2 года 10 месяцев";
                    specializ = "3-40 01 01 35 «Бухгалтерия экономической и деловой информации»";
                }
                else if (cbSpecialnost.Text == "БУАИК" && cbOtdel.Text == "заочное")
                {
                    special = "Бухгалтерский учет, анализ и контроль";
                    nameSpec = "бухгалтер";
                    srokObuch = "1 года 8 месяцев";
                    specializ = "3-40 01 01 35 «Бухгалтерия экономической и деловой информации»";
                }
                else if (cbSpecialnost.Text == "ДОУ")
                {
                    special = "Документационное обеспечение управления";
                    nameSpec = "секретарь-референт";
                    srokObuch = "2 года 10 месяцев";
                    specializ = "1-40 01 01 35 «Обработка экономической и деловой информации»";
                }
                for (int i = 0; i < dGVSvodnVedom.Rows.Count; i++)
                {
                    var wordApp = new Word.Application();
                    var wordDoc = wordApp.Documents.Add(Application.StartupPath + @"\Шаблоны WORD\Договор о зачислении.docx");

                    ReplaceStub("{day}", dayNow, wordDoc);
                    ReplaceStub("{month}", monthNow, wordDoc);
                    ReplaceStub("{year}", yearNow, wordDoc);

                    ReplaceStub("{FIO}", Convert.ToString(dGVSvodnVedom.Rows[i].Cells[2].Value), wordDoc);
                    ReplaceStub("{spec}", special, wordDoc);
                    ReplaceStub("{nameSpec}", nameSpec, wordDoc);
                    ReplaceStub("{specializ}", specializ, wordDoc);

                    ReplaceStub("{formobuch}", cbOtdel.Text, wordDoc);
                    ReplaceStub("{SROKOBUCH}", srokObuch, wordDoc);
                    ReplaceStub("{ADDRESS}", Convert.ToString(dGVSvodnVedom.Rows[i].Cells[4].Value), wordDoc);

                    wordDoc.SaveAs2(Application.StartupPath + @"\Договоры с зачисленными абитуриентами\" + "Договор с " + Convert.ToString(dGVSvodnVedom.Rows[i].Cells[2].Value) + ".docx");
                    wordDoc.Close();
                }

                MessageBox.Show("Документы сформированы!", "Отчёт");

                ///Может быть много таких меток
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"F:\ДИПЛОМ\Автоматизированная система для приемной комиссии УО НГАЭК\Abiturient NGAEK\Aboturient NGAEK\bin\Debug\Шаблоны WORD\Справочная информация об Абитуриент НГАЭК.docx");
        }

        private void dGVSvodnVedom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void controlMenuAdministrirov_Click(object sender, EventArgs e)
        {

        }
    }
}