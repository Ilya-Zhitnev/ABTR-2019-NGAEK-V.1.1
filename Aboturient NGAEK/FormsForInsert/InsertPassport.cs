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

namespace Aboturient_NGAEK.FormsForUpdate
{
    public partial class InsertPassport : MetroForm
    {
        public InsertPassport()
        {
            InitializeComponent();
        }

        private void InseprtPassport_Load(object sender, EventArgs e)
        {

        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void btInsertPas_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO [Паспорт] VALUES ('" + tbSeia.Text + "', '" + tbNum.Text + "', '" + shifr_PBKDF2.Encrypt(Convert.ToString(tbId.Text), "822822") + "')";
            
            manipulationDB.Insert(query);
            tbSeia.Text = null;
            tbNum.Text = null;
            tbId.Text = null;
        }

        private void btInsertClosePas_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO [Паспорт] VALUES ('" + tbSeia.Text + "', '" + tbNum.Text + "', '" + shifr_PBKDF2.Encrypt(Convert.ToString(tbId.Text), "822822") + "')";
            manipulationDB.Insert(query);
            Close();
        }
    }
}
