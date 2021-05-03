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

namespace Aboturient_NGAEK.FormForUpdate
{
    public partial class UpdateFormOtdel : MetroForm
    {
        public UpdateFormOtdel()
        {
            InitializeComponent();
        }

        private void btUpdCloseOtdel_Click(object sender, EventArgs e)
        {
            try
            {
                ControlForm cf = new ControlForm();
                string query = "UPDATE [Отделение] SET Наименование = '" + tbName.Text + "' WHERE ИД =";
                cf.Update(cf.dGVOtdel, query);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void UpdateFormOtdel_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }

        private void UpdateFormOtdel_Load(object sender, EventArgs e)
        {

        }
    }
}
