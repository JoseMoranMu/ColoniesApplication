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
    public partial class SuperForm : Form
    {
        ControladorSuper cs;
        Colonias parent;
        public SuperForm(ColoniesBD bd, Colonias parent)
        {
            cs = new ControladorSuper(bd);
            InitializeComponent();
            this.parent = parent;
            this.MdiParent = parent;
        }
        
    }
}
