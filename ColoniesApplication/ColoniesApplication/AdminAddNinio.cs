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
    public partial class AdminAddNinio : Form
    {
        ControladorAdmin ca;
        public AdminAddNinio(AdminForm parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
            ca = new ControladorAdmin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int carnet = int.Parse(textBox1.Text);
            String nombre = textBox2.Text;
            String apellido = textBox3.Text;
            String calle = textBox4.Text;
            char sexo = comboBox3.SelectedItem.ToString()[0];
            int año = int.Parse(comboBox1.SelectedItem.ToString());
            String casa = comboBox2.SelectedItem.ToString().Substring(0,3);

            Ninio n = new Ninio(carnet,nombre,apellido,calle,sexo,año);

            if (ca.insertatNens(n, casa))
            {

                MessageBox.Show("Niño modificado");
            }
            else {
                MessageBox.Show("Niño no modificado");

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
