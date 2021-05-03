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
    public partial class InsertOtmZachisl : MetroForm
    {
        public InsertOtmZachisl()
        {
            InitializeComponent();
        }

        private void InsertOtmZachisl_Load(object sender, EventArgs e)
        {

        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void btInsOtmZach_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO [Отметка о зачислении] VALUES ('" + tbDate.Text + "', '" + tbNumPrikaz.Text + "')";
            manipulationDB.Insert(query);
            tbDate.Text = null;
            tbNumPrikaz.Text = null;
        }

        private void btInsCloseOtmZach_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO [Отметка о зачислении] VALUES ('" + tbDate.Text + "', '" + tbNumPrikaz.Text + "')";
            manipulationDB.Insert(query);
            tbDate.Text = null;
            tbNumPrikaz.Text = null;
            Close();
        }
    }
}
