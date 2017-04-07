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
        public Super(Colonias parent)
        {
            ColoniesBD bd = new ColoniesBD();
            cs = new ControladorSuper();
            InitializeComponent();
            this.parent = parent;
            this.MdiParent = parent;
            listar();
        }

        private void listar()
        {
            listView1.Items.Clear();

            List<Personal> list = cs.listarTodos();
            for(int i=0;i<list.Count;i++)
            {
                ListViewItem lVI = listView1.Items.Add(list[i].getDNI());
                lVI.SubItems.Add(list[i].getName());
              lVI.SubItems.Add(list[i].getLastName());
               lVI.SubItems.Add(list[i].getPhone());
               lVI.SubItems.Add(list[i].getEmail());
                if (list[i] is Administrador)
                {
                    lVI.SubItems.Add(((Administrador)list[i]).getTitulacion());
                }
                else {
                    lVI.SubItems.Add("Monitor");
                }
           }
        }

        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperAddAdmin add = new SuperAddAdmin();
            if (add.ShowDialog() == DialogResult.OK) {

            }
            listar();
        }


        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperUpdateAdmin update = new SuperUpdateAdmin();
            if (update.ShowDialog() == DialogResult.OK)
            {

            }
            listar();
        }

        private void añadirToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void añadirToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void Super_Load(object sender, EventArgs e)
        {

        }
    }
}
