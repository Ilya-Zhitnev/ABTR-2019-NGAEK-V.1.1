using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using System.IO;

namespace Aboturient_NGAEK.FormForUpdate
{
    public partial class UpdateFormPlan : MetroForm
    {
        public UpdateFormPlan()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void btUpdClosePlan_Click(object sender, EventArgs e)
        {
            try
            {
                ControlForm cf = new ControlForm();
                string query = "UPDATE [План] SET " +
                    "Специальность = '" + cbSpec.SelectedValue + "', Отделение = '" + cbOtdel.SelectedValue + "', [Форма обучения] = '" + cbFormObuch.SelectedValue + "', Количество = '" + tbKolvo.Text + "', Класс = '" + mCbClass.Text + "'" +
                    " WHERE ИД =";
                cf.Update(cf.dGVPlan, query);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void UpdateFormPlan_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }

        private void UpdateFormPlan_Load(object sender, EventArgs e)
        {
            //manipulationDB.SelectComboBox("SELECT * FROM Специальность", cbSpec, "Название", "ИД");
            //manipulationDB.SelectComboBox("SELECT * FROM Отеделние", cbOtdel, "Наименование", "ИД");
            //manipulationDB.SelectComboBox("SELECT * FROM [Форма обучения]", cbFormObuch, "Наименование", "ИД");
        }
    }
}
