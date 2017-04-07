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

namespace ColoniesApplication
{
    public partial class AdminForm : Form
    {
        ControladorAdmin ca;
        Colonias parent;
        public AdminForm(Colonias parent)
        {

            InitializeComponent();
            this.parent = parent;
            this.MdiParent = parent;
            ca = new ControladorAdmin();
        }
    }
}
