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
    public partial class AdminAddTanda : Form
    {
        ControladorAdmin ca;
        public AdminAddTanda(AdminForm parent)
        {
            ca = new ControladorAdmin();
            InitializeComponent();
            this.MdiParent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int carnet = int.Parse(textBox1.Text);
            String fecha = comboBox2.SelectedItem.ToString();
            String casa = comboBox1.SelectedItem.ToString().Substring(0,3);
            int numero = int.Parse(numericUpDown1.Value.ToString());


            if (ca.insertarInscripcion(carnet, fecha, casa, numero))
            {
                MessageBox.Show("Inscripcion dada de Alta");
            }
            else {
                MessageBox.Show("Error dando de alta la inscripcion");
            }


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
