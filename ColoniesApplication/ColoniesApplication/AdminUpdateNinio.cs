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
    public partial class AdminUpdateNinio : Form
    {
        ControladorAdmin ca;
        public AdminUpdateNinio(AdminForm parent)
        {
            ca = new ControladorAdmin();
            InitializeComponent();
            this.MdiParent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int carnet = int.Parse(textBox1.Text);
            String nombre = textBox2.Text;
            String apellido = textBox3.Text;
            String calle = textBox4.Text;
            char sexo = comboBox3.SelectedItem.ToString()[0];
            int año = int.Parse(comboBox1.SelectedItem.ToString());
            String casa = comboBox2.SelectedItem.ToString().Substring(0, 3);

            Ninio n = new Ninio(carnet, nombre, apellido, calle, sexo, año);

            if (ca.modificarNen(n, casa))
            {

                MessageBox.Show("Niño añadido");
            }
            else
            {
                MessageBox.Show("Niño no añadido");

            }
        }
    }
}
