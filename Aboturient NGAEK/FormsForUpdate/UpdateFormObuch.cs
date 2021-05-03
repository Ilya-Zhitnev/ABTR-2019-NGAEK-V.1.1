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
    public partial class UpdateFormObuch : MetroForm
    {
        public UpdateFormObuch()
        {
            InitializeComponent();
        }

        private void UpdateFormObuch_Load(object sender, EventArgs e)
        {

        }

        ControlForm cf = new ControlForm();
        ManipulationDB manipulationDB = new ManipulationDB();

        private void UpdateFormObuch_Deactivate(object sender, EventArgs e)
        {
            //File.Delete("znach.txt");
            //ControlForm cf = new ControlForm();
            ////cf.Enabled = true
            //Application.Exit();
            //ControlForm cf2 = new ControlForm();
            //Application.Run(new ControlForm());
            //cf2.Activate();
            //cf2.Visible = true;
            //cf.Update();
            //cf.Refresh();
            cf.DisplayHeader = true;
            cf.tabMenu.SelectTab(1);

            //Activate();
            //cf.BringToFront();
            File.Delete("index.txt");
        }

        private void UpdateFormObuch_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }

        private void btUpdCloseFO_Click(object sender, EventArgs e)
        {
            try
            {
                ControlForm cf = new ControlForm();
                string query = "UPDATE [Форма обучения] SET Наименование = '" + tbNamFO.Text + "' WHERE ИД =";
                cf.Update(cf.dGVFormObuch, query);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
