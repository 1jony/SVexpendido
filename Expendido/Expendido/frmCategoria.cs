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
    public partial class frmCategoria : Form
    {
        int poc;
        int id;
        int estatus;
        string idtex;
        bool editar = false;
        conexion c = new conexion();
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            c.cargarcategorias(DGW_categorias);
            lbl_estatus.Visible = false;
            comboEstatus.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Campo nombre vacio", "Campo vacio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnombre.Focus();
            } else 
            {
                c.Insertar(txtnombre.Text, txtdescripcion.Text);
                c.cargarcategorias(DGW_categorias);
                txtnombre.Text = "";
                txtdescripcion.Text = "";
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                MessageBox.Show("Selecione una categoria de su tabla de categorias");

            }
            else
            {
                comboEstatus.Visible = true;
                lbl_estatus.Visible = true;
                if (comboEstatus.Text == "Alta")
                {
                    estatus = 1;
                }
                else if (comboEstatus.Text == "Baja") { estatus = 0; }
                c.Editar(id, estatus, txtnombre.Text, txtdescripcion.Text);
                c.cargarcategorias(DGW_categorias);
                editar = false;
                comboEstatus.Visible = false;
                lbl_estatus.Visible = false;
                txtnombre.Text = "";
                txtdescripcion.Text = "";
                btn_guardar.Enabled = true;
            }
        }
        private void DGW_categorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_guardar.Enabled = false;
            lbl_estatus.Visible = true;
            comboEstatus.Visible = true;
            poc = DGW_categorias.CurrentRow.Index;
            idtex = DGW_categorias[0, poc].Value.ToString();
            id = Convert.ToInt32(idtex);
            txtnombre.Text = DGW_categorias[1, poc].Value.ToString();
            txtdescripcion.Text = DGW_categorias[2, poc].Value.ToString();
            editar = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DGW_categorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
