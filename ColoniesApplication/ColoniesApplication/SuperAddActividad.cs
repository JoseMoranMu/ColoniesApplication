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
    public partial class SuperAddActividad : Form
    {
        Actividad a;
        ControladorSuper cs;
        public SuperAddActividad(Colonias parent)
        {
            InitializeComponent();
            a = null;
            cs = new ControladorSuper();
            MdiParent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String codigo;
            String descripcion;
            String casa;
            int nivel;

                codigo = textBox2.Text;
                descripcion = textBox3.Text;
            casa = comboBox1.SelectedItem.ToString().Substring(0, 3);
                nivel = (int)numericUpDown1.Value;

                a = new Actividad(codigo, descripcion);
            Console.WriteLine(nivel);
            if (cs.insertarActividadCasa(a, casa, nivel)) {
                MessageBox.Show("Actividad añadida");
                this.Close();
            }
            else
            {
                MessageBox.Show("Actividad no añadida");
            }
        }
    }
}
