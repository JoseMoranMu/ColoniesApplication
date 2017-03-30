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
            String u = textBox2.Text;
            String p = textBox1.Text;
            Personal usuario= ColoniesBD.login(u, p);
            if (usuario!=null)
            {
                MessageBox.Show("Login ok ");
                ColoniesBD db = new ColoniesBD();
                if (usuario.getRole().Equals("Super"))
                {
                    new Super(db, parent).Show();
                    this.Close();
                }
                else if (usuario.getRole().Equals("Admin"))
                {

                }
                else if (usuario.getRole().Equals("Monitor"))
                {

                }
            }
            else {
                MessageBox.Show("Login fail");
            }
        }
    }
}
