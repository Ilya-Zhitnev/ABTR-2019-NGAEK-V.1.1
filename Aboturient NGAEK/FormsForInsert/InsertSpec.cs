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
    public partial class InsertSpec : MetroForm
    {
        public InsertSpec()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void InsertSpec_Load(object sender, EventArgs e)
        {

        }

        private void btInsSpec_Click_1(object sender, EventArgs e)
        {
            string query = "INSERT INTO Специальность VALUES ('" + tbNam.Text + "','" + tbKod.Text + "')";
            manipulationDB.Insert(query);
            tbNam.Text = null;
            tbKod.Text = null;
        }

        private void btInsCloseSpec_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Специальность VALUES ('" + tbNam.Text + "','" + tbKod.Text + "')";
            manipulationDB.Insert(query);
            Close();
        }
    }
}
