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
            listar();
        }

        private void listar()
        {
            listView1.Clear();
            List<Personal> list = cs.listarTodos();
            for(int i=0;i<list.Count;i++)
            {
                ListViewItem lVI = listView1.Items.Add(list[i].getDNI());
                lVI.SubItems.Add(list[i].getName());
                lVI.SubItems.Add(list[i].getLastName());
                lVI.SubItems.Add(list[i].getPhone());
                lVI.SubItems.Add(list[i].getEmail());
                lVI.SubItems.Add(list[i].getRole());
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperAddAdmin add = new SuperAddAdmin();
            if (add.ShowDialog() == DialogResult.OK) {
                Personal p = add.getPersonal();
                add.Close();
                cs.insertarAdmin(p,"Admin");
            }
        }
    }
}
