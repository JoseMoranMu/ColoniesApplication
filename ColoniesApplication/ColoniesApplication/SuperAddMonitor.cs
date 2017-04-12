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
    public partial class SuperAddMonitor : Form
    {
        Monitor m;
        ControladorSuper cs;
        public SuperAddMonitor(Super parent)
        {
            m = null;
            cs = new ControladorSuper();
            InitializeComponent();
            MdiParent= parent;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String dni = textBox1.Text;
            String nombre = textBox2.Text;
            String apellido = textBox3.Text;
            String telefono = textBox4.Text;
            String email = textBox5.Text;
            DateTime naixement = dateTimePicker1.Value.Date;
            DateTime fecha = dateTimePicker1.Value.Date;
            m = new Monitor(dni, nombre, apellido, telefono, email, naixement);

            if (cs.insertarMonitor(m))
            {
                MessageBox.Show("Monitor añadido");
                this.Close();
            }
            else
            {
                MessageBox.Show("Monitor no modificado");
            }
            
        }
        
    }

}
