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
                        new Super(db, parent).Show();
                        this.Close();
                    }
                    else if (a.getTitulacion().Equals("Admin")) {


                    }
                }
                else if(usuario is Monitor){

                }
            }
            else {
                MessageBox.Show("Login fail");
            }
        }
    }
}
