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
    public partial class UpdateFormPassport : MetroForm
    {
        public UpdateFormPassport()
        {
            InitializeComponent();
        }

        private void btUpdClosePas_Click(object sender, EventArgs e)
        {
            try
            {
                ControlForm cf = new ControlForm();
                string query = "UPDATE [Паспорт] SET " +
                    "Серия = '" + tbSeria.Text+ "', Номер = '" + tbNum.Text + "', Идентификатор = '" + shifr_PBKDF2.Encrypt(Convert.ToString(tbId.Text), "822822") + "'" +
                    " WHERE ИД =";
                cf.Update(cf.dGVPass, query);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void UpdateFormPassport_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }
    }
}
