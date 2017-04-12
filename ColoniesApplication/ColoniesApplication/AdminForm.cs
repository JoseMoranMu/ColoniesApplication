using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace ColoniesApplication
{
    public partial class AdminForm : Form
    {
        ControladorAdmin ca;

        public AdminForm()
        {

            InitializeComponent();

            ca = new ControladorAdmin();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminAddNinio add = new AdminAddNinio(this);
            add.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminUpdateNinio add = new AdminUpdateNinio(this);
            add.Show();
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdminAddTanda add = new AdminAddTanda(this);
            add.Show();
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdminUpdateTanda add = new AdminUpdateTanda(this);
            add.Show();
        }
    }
}
