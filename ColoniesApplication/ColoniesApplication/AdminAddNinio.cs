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
    public partial class AdminAddNinio : Form
    {
        public AdminAddNinio(AdminForm parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
        }
    }
}
