using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColoniesApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String u = textBox2.Text;
            String p = textBox1.Text;
            bool b= Model.LoginBD.login(u, p);
            if (b)
            {
                MessageBox.Show("Login ok");
            }
            else {
                MessageBox.Show("Login fail");
            }
        }
    }
}
