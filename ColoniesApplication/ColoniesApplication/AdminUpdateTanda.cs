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
using Model;

namespace ColoniesApplication
{
    public partial class AdminUpdateTanda : Form
    {
        ControladorAdmin ca;
        public AdminUpdateTanda(AdminForm parent)
        {
            ca = new ControladorAdmin();
            InitializeComponent();
            this.MdiParent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int carnet = int.Parse(textBox1.Text);
            String fecha = comboBox2.SelectedItem.ToString();
            String casa = comboBox1.SelectedItem.ToString().Substring(0, 3);
            int numero = int.Parse(numericUpDown1.Value.ToString());


            if (ca.modificarInscripcion(carnet, fecha, casa, numero))
            {
                MessageBox.Show("Inscripcion modificada");
            }
            else
            {
                MessageBox.Show("Error modificando");
            }
        }
    }
}
