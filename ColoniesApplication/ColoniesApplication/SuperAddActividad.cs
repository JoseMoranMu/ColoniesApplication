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
        public SuperAddActividad()
        {
            InitializeComponent();
            a = null;
            cs = new ControladorSuper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String codigo = textBox1.Text;
            String descripcion = textBox2.Text;
            String casa = textBox3.Text;
            int nivel = int.Parse(textBox4.Text);

            a = new Actividad(codigo,descripcion);

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
