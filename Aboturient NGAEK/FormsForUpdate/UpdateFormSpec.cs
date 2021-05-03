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
    public partial class UpdateFormSpec : MetroForm
    {
        public UpdateFormSpec()
        {
            InitializeComponent();
        }

        private void btUpdCloseSpec_Click(object sender, EventArgs e)
        {
            try
            {
                ControlForm cf = new ControlForm();
                string query = "UPDATE [Специальность] SET Название = '" + tbNam.Text + "', Код = '"+  tbKod.Text + "' WHERE ИД =";
                cf.Update(cf.dGVSpecial, query);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void UpdateFormSpec_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }

        private void UpdateFormSpec_Load(object sender, EventArgs e)
        {

        }
    }
}
