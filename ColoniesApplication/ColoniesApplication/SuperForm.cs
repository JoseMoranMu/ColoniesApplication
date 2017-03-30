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
    public partial class Super : Form
    {
        ControladorSuper cs;
        Colonias parent;
        public Super(ColoniesBD bd, Colonias parent)
        {
            cs = new ControladorSuper(bd);
            InitializeComponent();
            this.parent = parent;
            this.MdiParent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
