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

namespace ColoniesApplication
{
    public partial class Login : Form
    {
        Colonias parent;
        public Login(Colonias parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
            this.parent = parent;
            textBox2.Text = "72621359D";
            textBox1.Text = "sadmin@colonias.com";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColoniesBD db = new ColoniesBD();
            String u = textBox2.Text;
            String p = textBox1.Text;
            Personal usuario= db.login(u, p);
            if (usuario!=null)
            { 
                MessageBox.Show("Login ok ");
                if(usuario is Administrador){
                    Administrador a = (Administrador)usuario;
                    if (a.getTitulacion().Equals("Super"))
                    {
                        new Super(parent).Show();
                        this.Close();
                    }
                    else if (a.getTitulacion().Equals("Admin")) {

                        new AdminForm(parent).Show();
                        this.Close();

                    }
                }
                else if(usuario is Monitor){
                    new MoniForm(parent).Show();
                    this.Close();
                }
            }
            else {
                MessageBox.Show("Login fail");
            }
        }
    }
}
