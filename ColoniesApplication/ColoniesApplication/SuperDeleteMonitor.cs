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
    public partial class SuperDeleteMonitor : Form
    {
        ControladorSuper cs;
        public SuperDeleteMonitor()
        {
            cs = new ControladorSuper();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String dni = textBox1.Text;

            if (cs.borrarMonitor(dni)) 
                {
                    MessageBox.Show("Monitor eliminado");
                    this.Close();
                }
            else
            {
                    MessageBox.Show("Monitor no eliminado");
                }
            }
    }
}
