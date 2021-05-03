using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Aboturient_NGAEK
{
    class ManipulationDB
    {
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        //запросы на отображение данных
        public string queryPlan = "SELECT ROW_NUMBER() over (ORDER BY [Специальность].[ИД] ASC) [Порядковый номер], Специальность.Название, Отделение.Наименование AS Отделение, [Форма обучения].Наименование AS [Форма обучения], План.Количество, План.Класс " +
                    "FROM План INNER JOIN Специальность ON План.Специальность=Специальность.ИД " +
                    "INNER JOIN Отделение ON План.Отделение=Отделение.ИД " +
                    "INNER JOIN [Форма обучения] ON План.[Форма обучения]=[Форма обучения].ИД;";
        public string queryPassport = "SELECT ROW_NUMBER() over (ORDER BY [Паспорт].[ИД] ASC) [Порядковый номер], Серия, Номер, Идентификатор FROM [Паспорт]";
        public string queryOtmZach = "SELECT ROW_NUMBER() over (ORDER BY [Отметка о зачислении].[ИД] ASC) [Порядковый номер], Дата, [Номер приказа] " +
            "FROM [Отметка о зачислении]";
        public string queryZhurnal = "SELECT ROW_NUMBER() over (ORDER BY [Журнал].[ИД] ASC) [Порядковый номер], Журнал.[Дата приема], " +
            "[Личная информация].ФИО, [Личная информация].Гражданство, [Личная информация].[Адрес]," +
            " Журнал.Документы AS [Перечень принятых документов], [Личная информация].Льготы, " +
            "Журнал.[Нужда в общежитии], Журнал.Договор AS [По договору с организацией], Журнал.[Отметка о зачислении], " +
            "[Отметка о зачислении].Дата AS [Дата подписания приказа о зачислении], [Отметка о зачислении].[Номер приказа], Журнал.[Отметка об отказе в зачислении], Журнал.[Отметка о возврате]" +
            " FROM Журнал LEFT JOIN [Личная информация] ON Журнал.[Личная информация]=[Личная информация].ИД " +
            "LEFT JOIN [Отметка о зачислении] ON Журнал.[Отметка]=[Отметка о зачислении].ИД";
        public string querySpec = "SELECT ROW_NUMBER() over (ORDER BY [Специальность].[ИД] ASC) [Порядковый номер], Название, Код FROM [Специальность]";
        public string queryOtdel = "SELECT ROW_NUMBER() over (ORDER BY [Отделение].[ИД] ASC) [Порядковый номер], Наименование FROM [Отделение]";
        public string queryFormObuch = "SELECT ROW_NUMBER() over (ORDER BY [Форма обучения].[ИД] ASC) [Порядковый номер], Наименование FROM [Форма обучения]";
        public string queryLI = "SELECT ROW_NUMBER() over (ORDER BY [Личная информация].[ИД] ASC) [Порядковый номер], " +
            "Специальность.Название, Отделение.Наименование, " +
            "[Личная информация].ФИО, [Личная информация].Гражданство, [Личная информация].Адрес, " +
            "[Паспорт].Серия AS [Серия паспорта], [Паспорт].Номер AS [Номер паспорта], [Паспорт].Идентификатор AS [Идентификационный номер паспорта]," +
            " [Личная информация].Льготы, [Личная информация].Школа, [Личная информация].[Средний балл], [Личная информация].Класс " +
            "FROM [Личная информация] LEFT JOIN [Паспорт] ON [Личная информация].Паспорт = Паспорт.ИД " +
            "LEFT JOIN Специальность ON [Личная информация].Специальность = Специальность.ИД " +
            "LEFT JOIN Отделение ON [Личная информация].Отделение = Отделение.ИД";
        public string queryUsers = "SELECT ROW_NUMBER() over (ORDER BY [Пользователь].[ИД] ASC) [Порядковый номер], Имя, Пароль, Администрирование FROM Пользователь";

        //запросы на удаление данных
        public string queryOtdelDel = "DELETE FROM Отделение WHERE ИД=";
        public string queryFODel = "DELETE FROM [Форма обучения] WHERE ИД=";
        public string queryPlanDel = "DELETE FROM План WHERE ИД=";
        public string querySpecDel = "DELETE FROM Специальность WHERE ИД=";
        public string queryZhurnalDel = "DELETE FROM Журнал WHERE ИД=";
        public string queryLIDel = "DELETE FROM [Личная информация] WHERE ИД=";
        public string queryOtmZachDel = "DELETE FROM [Отметка о зачислении] WHERE ИД=";
        public string queryFormObuchDel = "DELETE FROM [Форма обучения] WHERE ИД=";
        public string queryPassportDel = "DELETE FROM [Паспорт] WHERE ИД=";
        public string queryUserstDel = "DELETE FROM Пользователь WHERE ИД=";

        public void Select(string query, DataGridView dGV)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                connect.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dGV.DataSource = dt;
                connect.Close();
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

        public void SelectComboBox(string query, ComboBox cb, string name, string id)
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

        public void Insert(string query)
        {
            try
            {
                connect.Open();
                SqlCommand comm = new SqlCommand(query, connect);
                comm.ExecuteScalar();
                connect.Close();
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

        //public void Update(DataGridView dG, string queryUpd)
        //{
        //    List<int> Num = new List<int>();
        //    try
        //    {
        //        connect.Open();
        //        if (dG.RowCount != 0)
        //        {
        //            if (dG.SelectedCells.Count != 0)
        //            {
        //                Num.Add(Convert.ToInt32(dG[0, dG.CurrentCell.RowIndex].Value));
        //            }
        //        }

        //        for (int i = 0; i < Num.Count; i++)
        //        {
        //            queryUpd = queryUpd + Num[i];
        //            SqlCommand SQLcmd = new SqlCommand(queryUpd, connect);
        //            SQLcmd.ExecuteScalar();
        //        }
        //        Num.Clear();
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message, "Ошибка работы с БД");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Ошибка программы");
        //    }
        //    finally
        //    {
        //        connect.Close();
        //        Num.Clear();
        //    }
        //}

        public void Delete(DataGridView dg, string query, string ID)
        {
            List<int> Num = new List<int>();
            try
            {
                connect.Open();
                if (dg.RowCount != 0)
                {
                    if (dg.SelectedCells.Count != 0)
                    {
                        Num.Add(Convert.ToInt32(ID));
                        dg.Rows.RemoveAt(dg.CurrentCell.RowIndex);
                    }
                }

                for (int i = 0; i < Num.Count; i++)
                {
                    SqlCommand SQLcmd = new SqlCommand(query + Num[i], connect);
                    SQLcmd.ExecuteScalar();
                }
                Num.Clear();
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
                Num.Clear();
            }
        }

        public void DeleteWithVibor(DataGridView dG, string queryVibor, string querydel,string ID)
        {
            List<int> delNum = new List<int>();
            try
            {
                connect.Open();
                queryVibor = queryVibor + ID;
                SqlCommand SQLcmd = new SqlCommand(queryVibor, connect);
                if (Convert.ToString(SQLcmd.ExecuteScalar()) == "")
                {
                    if (dG.RowCount != 0)
                    {
                        if (dG.SelectedCells.Count != 0)
                        {
                            delNum.Add(Convert.ToInt32(ID));
                            dG.Rows.RemoveAt(dG.CurrentCell.RowIndex);
                        }
                    }

                    for (int i = 0; i < delNum.Count; i++)
                    {
                        querydel = querydel + delNum[i];
                        SQLcmd = new SqlCommand(querydel, connect);
                        SQLcmd.ExecuteScalar();
                    }
                }
                else
                {
                    MessageBox.Show("Вы не можете удалить данную строку, т.к. другая таблица зависит от данной строки!");
                }
                connect.Close();
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
                delNum.Clear();
                connect.Close();
            }
        }

        public string generationID(string query)
        {
            string ID = "";
            try
            {
                SqlCommand comm = new SqlCommand(query, connect);
                connect.Open();
                ID = comm.ExecuteScalar().ToString();
                connect.Close();
            }
            catch(SqlException exSQL)
            {
                MessageBox.Show(exSQL.Message,"Ошибка работы с базой данных:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с приложением:");
            }
            finally
            {
                connect.Close();
            }

            return ID;
        }
    }

    class UsersTF
    {
        public static int user = 0;
    }

    class ConnDB
    {
        public static string conn = "";
    }


    public static class shifr_PBKDF2
    {
            // This constant is used to determine the keysize of the encryption algorithm in bits.
            // We divide this by 8 within the code below to get the equivalent number of bytes.
            private const int Keysize = 256;

            // This constant determines the number of iterations for the password bytes generation function.
            private const int DerivationIterations = 1000;

            public static string Encrypt(string plainText, string passPhrase)
            {
                // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
                // so that the same Salt and IV values can be used when decrypting.  
                var saltStringBytes = Generate256BitsOfRandomEntropy();
                var ivStringBytes = Generate256BitsOfRandomEntropy();
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
                {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.BlockSize = 256;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.PKCS7;
                        using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                    var cipherTextBytes = saltStringBytes;
                                    cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                    cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                    memoryStream.Close();
                                    cryptoStream.Close();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            public static string Decrypt(string cipherText, string passPhrase)
            {
                // Get the complete stream of bytes that represent:
                // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
                var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
                // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
                var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
                // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
                var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
                // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
                var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
                {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.BlockSize = 256;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.PKCS7;
                        using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                        {
                            using (var memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    var plainTextBytes = new byte[cipherTextBytes.Length];
                                    var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    memoryStream.Close();
                                    cryptoStream.Close();
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }

            private static byte[] Generate256BitsOfRandomEntropy()
            {
                var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    // Fill the array with cryptographically secure random bytes.
                    rngCsp.GetBytes(randomBytes);
                }
                return randomBytes;
            }
        }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MConnectDB());
        }
    }
}
