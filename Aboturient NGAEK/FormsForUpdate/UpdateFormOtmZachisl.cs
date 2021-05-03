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
    public partial class UpdateFormOtmZachisl : MetroForm
    {
        public UpdateFormOtmZachisl()
        {
            InitializeComponent();
        }

        private void btUpdCloseOtmZach_Click(object sender, EventArgs e)
        {
            try
            {
                ControlForm cf = new ControlForm();
                string query = "UPDATE [Отметка о зачислении] SET " +
                    "Дата = '" + tbDate.Text + "', [Номер приказа] = '" + tbNumPrikaz.Text + "'" +
                    " WHERE ИД =";
                cf.Update(cf.dGVOtmZach, query);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void UpdateFormOtmZachisl_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }
    }
}
