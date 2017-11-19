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
    public partial class frmArticulo : Form
    {
        public static frmArticulo mdiobj;
        public int idcategoria;
        int proc;
        conexion c = new conexion();
        public frmArticulo()
        {
            InitializeComponent();
            
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            
            frmcategoria_articulo frm = new frmcategoria_articulo();
            frm.Show();
            mdiobj = this;
            

            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Campo codigo vacio", "Campo vacio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
            }
            else if (txtNombre.Text == "")
            {
                MessageBox.Show("Campo nombre vacio", "Campo vacio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
            }
            else if (txtCategoria.Text == "")
            {
                MessageBox.Show("Para seleccionar una categoria pulse en el icono de la lupa", "Seleccione una categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
               
                int estatus = 1;
                c.Insertar_articulo(estatus,idcategoria, txtCodigo.Text, txtNombre.Text, txtDescripcion.Text);
                c.cargararticulos(DGW_articulos);
            }
            
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            txtCategoria.Enabled = false;
            c.cargararticulos(DGW_articulos);
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void DGW_articulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
            proc = DGW_articulos.CurrentRow.Index;
            txtCodigo.Text = DGW_articulos[1, proc].Value.ToString();
            txtNombre.Text = DGW_articulos[2, proc].Value.ToString();
            txtDescripcion.Text = DGW_articulos[3, proc].Value.ToString();
            txtCategoria.Text = DGW_articulos[4, proc].Value.ToString();
            lbl_estatus.Visible = true;
            comboEstatus.Visible = true;
            
            
        }

        private void pxImagen_Click(object sender, EventArgs e)
        {

        }
    }
}
