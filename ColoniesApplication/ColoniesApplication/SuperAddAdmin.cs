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
    public partial class SuperAddAdmin : Form
    {
        Administrador a;
        ControladorSuper cs;
        public SuperAddAdmin()
        {
            cs = new ControladorSuper();
            a = null;
            InitializeComponent();
        }

        internal Personal getPersonal()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String dni = textBox1.Text;
            String nombre = textBox2.Text;
            String apellido = textBox3.Text;
            String telefono = textBox4.Text;
            String email = textBox5.Text;
            int nSS = int.Parse(textBox6.Text);
            String titulacion = textBox7.Text;
            a = new Administrador(dni,nombre,apellido,telefono,email,nSS,titulacion);

            if (cs.insertarAdmin(a)) {
                MessageBox.Show("Administrador añadido");
            } else {
                MessageBox.Show("Administrador no añadido");
            }
        }
    }
}
