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
            SuperAddAdmin add = new SuperAddAdmin(parent);
            add.Show();
        }


        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperUpdateAdmin update = new SuperUpdateAdmin(parent);
            update.Show();
        }

        private void añadirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SuperAddMonitor add = new SuperAddMonitor(parent);
            add.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperDeleteMonitor delete = new SuperDeleteMonitor(parent);
            delete.Show();
        }

        private void añadirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SuperAddActividad add = new SuperAddActividad(parent);
            add.Show();
        }

        private void close(object sender, FormClosedEventArgs e)
        {
            Login login = new Login(parent);
            login.Show();
        }

        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listar();
        }
    }
}
