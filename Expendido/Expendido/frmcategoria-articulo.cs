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
    public partial class frmcategoria_articulo : Form
    {
        conexion c = new conexion();
        int poc;
       public string nombre;
         string idtex;
        public int ids;
        public static frmcategoria_articulo mdiobj;
        public frmcategoria_articulo()
        {
            InitializeComponent();
           
        }
        
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void buscar_categoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            poc = buscar_categoria.CurrentRow.Index;
            idtex = buscar_categoria[0, poc].Value.ToString();
            ids = Convert.ToInt32(idtex);
            nombre = buscar_categoria[1, poc].Value.ToString();
            frmArticulo.mdiobj.idcategoria = ids;
            frmArticulo.mdiobj.txtCategoria.Text = nombre;
            this.Close();
            this.Dispose();
            




        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        
        }

        private void frmcategoria_articulo_Load(object sender, EventArgs e)
        {
            c.buscarcategoria(buscar_categoria);
        }

        private void buscar_categoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
