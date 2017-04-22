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
    public partial class MoniForm : Form
    {
        ControladorMonitor cm;
        public MoniForm()
        {
            InitializeComponent();
            cm = new ControladorMonitor();
        }

        private void añadirTareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoniAddTareaTanda bd = new MoniAddTareaTanda(this);
            bd.Show();
        }
    }
}
