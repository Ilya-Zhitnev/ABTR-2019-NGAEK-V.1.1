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
    public partial class InsertOtdel : MetroForm
    {
        public InsertOtdel()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void InsertOtdel_Load(object sender, EventArgs e)
        {

        }

        private void btInsOtdel_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Отделение VALUES ('" + tbName.Text + "')";
            manipulationDB.Insert(query);
            tbName.Text = null;
        }

        private void btInsCloseOtdel_Click_1(object sender, EventArgs e)
        {
            string query = "INSERT INTO Отделение VALUES ('" + tbName.Text + "')";
            manipulationDB.Insert(query);
            this.Close();
        }

        private void InsertOtdel_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
