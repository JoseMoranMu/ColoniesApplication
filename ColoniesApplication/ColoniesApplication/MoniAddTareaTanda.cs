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
    public partial class MoniAddTareaTanda : Form
    {
        ControladorMonitor cm;
        
        public MoniAddTareaTanda(MoniForm moni)
        {
            InitializeComponent();
            cm = new ControladorMonitor();
            MdiParent = moni;
            loadData();
        }

        private void loadData()
        {
            List<String> dni = cm.selectDniMonitor();

            foreach (String s in dni)
            {
                comboBox1.Items.Add(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String dni = comboBox1.SelectedItem.ToString();
            String tarea = comboBox2.SelectedItem.ToString().Substring(0,1);
           
            String fecha = comboBox3.SelectedItem.ToString();
            DateTime data = dateTimePicker1.Value.Date;

            if (cm.registarTascaTanda(dni, tarea, fecha, data))
            {
                MessageBox.Show("Tarea añadida");
            }
            else {
                MessageBox.Show("Tarea NO añadida");
            }

        }
    }
}
