﻿using System;
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
    public partial class SuperUpdateAdmin : Form
    {
        Administrador a;
        ControladorSuper cs;
        public SuperUpdateAdmin(Super parent)
        {
            cs = new ControladorSuper();
            a = null;
            InitializeComponent();
            MdiParent = parent;
            loadComboBox();
        }

        private void loadComboBox()
        {
            List<String> lista= cs.getDNIAdmin();
            foreach (String s in lista) {
                comboBox1.Items.Add(s);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String dni = comboBox1.SelectedItem.ToString();
            String nombre = textBox2.Text;
            String apellido = textBox3.Text;
            String telefono = textBox4.Text;
            String email = textBox5.Text;
            int nSS = int.Parse(textBox6.Text);
            String titulacion = textBox7.Text;
            a = new Administrador(dni, nombre, apellido, telefono, email, nSS, titulacion);

            if (cs.modificarAdmin(a))
            {
                MessageBox.Show("Administrador modificado");
                this.Close();
            }
            else
            {
                MessageBox.Show("Administrador no modificado");
            }
        }
    }
}
