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

namespace Aboturient_NGAEK
{
    public partial class InsertPlan : MetroForm
    {
        public InsertPlan()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void btInsPlan_Click(object sender, EventArgs e)
        {

        }

        private void btInsClosePlan_Click(object sender, EventArgs e)
        {

        }

        private void InsertPlan_Load(object sender, EventArgs e)
        {
            manipulationDB.SelectComboBox("SELECT * FROM Специальность", cbSpec, "Название", "ИД");
            manipulationDB.SelectComboBox("SELECT * FROM Отделние", cbOtdel, "Наименование", "ИД");
            manipulationDB.SelectComboBox("SELECT * FROM [Форма обучения]", cbFormObuch, "Наименование", "ИД");
        }

        private void btInsPlan_Click_1(object sender, EventArgs e)
        {
            string query = "INSERT INTO [План] " +
            "VALUES ('" + cbSpec.SelectedValue + "','" + cbOtdel.SelectedValue + "','" + cbFormObuch.SelectedValue + "','" + tbKolvo.Text + "','" + mCbClass.Text+"')";
            manipulationDB.Insert(query);
            tbKolvo.Text = null;
        }

        private void btInsClosePlan_Click_1(object sender, EventArgs e)
        {
            string query = "INSERT INTO [План] " +
            "VALUES ('" + cbSpec.SelectedValue + "','" + cbOtdel.SelectedValue + "','" + cbFormObuch.SelectedValue + "','" + tbKolvo.Text + "','" + mCbClass.Text + "')";
            manipulationDB.Insert(query);
            tbKolvo.Text = null;
            Close();
        }
    }
}
