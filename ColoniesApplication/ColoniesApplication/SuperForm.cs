using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controlador;

namespace ColoniesApplication
{
    public partial class Super : Form
    {
        ControladorSuper cs;

        public Super()
        {
            cs = new ControladorSuper();
            InitializeComponent();

        }


        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperAddAdmin add = new SuperAddAdmin(this);
            add.Show();
        }


        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperUpdateAdmin update = new SuperUpdateAdmin(this);
            update.Show();
        }

        private void añadirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SuperAddMonitor add = new SuperAddMonitor(this);
            add.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperDeleteMonitor delete = new SuperDeleteMonitor(this);
            delete.Show();
        }

        private void añadirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SuperAddActividad add = new SuperAddActividad(this);
            add.Show();
        }

        private void close(object sender, FormClosedEventArgs e)
        {

        }
    }
}
