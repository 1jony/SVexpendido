using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expendido
{
    public partial class Form1 : Form
    {
        public static Form1 mdiobj;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void articuloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmArticulo frma = new frmArticulo();
            frma.Show();
        }

        private void inisiarSecionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCategoria frmc = new frmCategoria();
            frmc.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            almacenToolStripMenuItem.Enabled = false;
            comprasToolStripMenuItem.Enabled = false;
            ventasToolStripMenuItem.Enabled = false;
            trabajadorToolStripMenuItem.Enabled = false;
            login frm = new login();
            frm.Show();
            frm.MdiParent = this;
            mdiobj = this;
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
