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
        public SuperDeleteMonitor(Super parent)
        {
            cs = new ControladorSuper();
            InitializeComponent();
            MdiParent = parent;
            loadData();
        }

        private void loadData()
        {
            List<String> list = cs.getDNIMoni();
            foreach(String s in list)
            {
                comboBox1.Items.Add(s);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String dni = comboBox1.SelectedItem.ToString();

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
