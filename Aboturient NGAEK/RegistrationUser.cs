﻿using System;
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
    public partial class RegistrationUser : MetroForm
    {
        public RegistrationUser()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void RegistrationUser_Load(object sender, EventArgs e)
        {

        }

        private void btRegistr_Click(object sender, EventArgs e)
        {
            
            bool validationUser = false;
            string queryUser = "SELECT * FROM Пользователь WHERE Имя='" + tbUser.Text + "'"; 
            connect.Open();
            SqlCommand comm = new SqlCommand(queryUser, connect);

            if(comm.ExecuteScalar()==null)
            {
                validationUser = false;
            }
            else
            {
                validationUser = true;
            }
            connect.Close();

            if (validationUser==true)
            {
                MessageBox.Show("Пожалуйста, придумайте другое имя пользователю!","Ошибка регистрации");
            }
            else
            {
                int admin = 0;
                admin = chbAdmin.Checked == true ? 1 : 0;
                if (tbPassword.Text == tbPasswordRepeat.Text)
                {
                    string queryRegistrUser = "INSERT INTO Пользователь VALUES ('" + tbUser.Text + "', " +
                        "'" + shifr_PBKDF2.Encrypt(Convert.ToString(tbPassword.Text), "204503") + "'," +
                        "'" + admin + "' )";
                    manipulationDB.Insert(queryRegistrUser);
                    tbUser.Text = null;
                    tbPassword.Text = null;
                    tbPasswordRepeat.Text = null;
                    chbAdmin.Checked = false;
                    MessageBox.Show("Успешно", "Регистрация пользователя прошла успешно!");
                }
                else
                {
                    MessageBox.Show("Ошибка паролей", "Введенные пароли не совпадают. " +
                        "Пожалуйста, проверьте правильность введённых паролей.");
                }
            }
        }
    }
}
