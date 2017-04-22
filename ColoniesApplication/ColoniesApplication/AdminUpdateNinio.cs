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
            loadData();
        }

        private void loadData()
        {
            List<int> list = ca.getCarnetNinos();
            foreach (int s in list) {

                comboBox4.Items.Add(s.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int carnet = int.Parse(comboBox4.SelectedItem.ToString());
            String nombre = textBox2.Text;
            String apellido = textBox3.Text;
            String calle = textBox4.Text;
            char sexo = comboBox3.SelectedItem.ToString()[0];
            int año = int.Parse(comboBox1.SelectedItem.ToString());
            String casa = comboBox2.SelectedItem.ToString().Substring(0, 3);

            Ninio n = new Ninio(carnet, nombre, apellido, calle, sexo, año);

            if (ca.modificarNen(n, casa))
            {

                MessageBox.Show("Niño modificado");
                this.Close();
            }
            else
            {
                MessageBox.Show("Niño no modificado");

            }
        }
    }
}
