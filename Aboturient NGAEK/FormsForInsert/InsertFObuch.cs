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
    public partial class InsertFObuch : MetroForm
    {
        public InsertFObuch()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void InsertFObuch_Load(object sender, EventArgs e)
        {

        }

        private void btInsCloseFO_Click_1(object sender, EventArgs e)
        {
            string query = "INSERT INTO [Форма обучения] VALUES ('" + tbNamFO.Text + "')";
            manipulationDB.Insert(query);
            
            Close();
        }

        private void btInsFO_Click_1(object sender, EventArgs e)
        {
            string query = "INSERT INTO [Форма обучения] VALUES ('" + tbNamFO.Text + "')";
            manipulationDB.Insert(query);
            tbNamFO.Text = null;
        }
    }
}
