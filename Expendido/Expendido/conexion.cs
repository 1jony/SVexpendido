using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Expendido
{
    class conexion
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataTable dt;
        
        public conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=LAPTOP-EKAM9B6P;Initial Catalog=dbventas;Integrated Security=True");
                cn.Open();


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto con la base de datos: " + ex.ToString(),"Error de conexion",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        // metodo para insertar un nuevo registo categorias
        public string Insertar(string nombre, string descripcion)
        {


            SqlCommand command = new SqlCommand("uspinsertar_categoria", cn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter pnombre = new SqlParameter();
            pnombre.ParameterName = "@nombre";
            pnombre.SqlDbType = SqlDbType.VarChar;
            pnombre.Size = 50;
            command.Parameters.Add(pnombre);


            SqlParameter pdescripcion = new SqlParameter();
            pdescripcion.ParameterName = "@descripcion";
            pdescripcion.SqlDbType = SqlDbType.VarChar;
            pdescripcion.Size = 256;
            command.Parameters.Add(pdescripcion);

            SqlParameter pestatus = new SqlParameter();
            pestatus.ParameterName = "@estatus";
            pestatus.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pestatus);
            pestatus.Value = 1;
            pnombre.Value = nombre;
            pdescripcion.Value = descripcion;

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Guardado correctamente","Nuevo registro",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar" + ex.ToString(),"No se guardo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return null;
        }
        //termina metodo de insercion

        // metodo para insertar un nuevo registo en articulos
        public string Insertar_articulo(int estatus, int id, string codigo,string nombre, string descripcion)
        {


            SqlCommand command = new SqlCommand("uspinsertar_articulo", cn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter pcodigo = new SqlParameter();
            pcodigo.ParameterName = "@codigo";
            pcodigo.SqlDbType = SqlDbType.VarChar;
            pcodigo.Size = 50;
            command.Parameters.Add(pcodigo);

            SqlParameter pnombre = new SqlParameter();
            pnombre.ParameterName = "@nombre";
            pnombre.SqlDbType = SqlDbType.VarChar;
            pnombre.Size = 50;
            command.Parameters.Add(pnombre);


            SqlParameter pdescripcion = new SqlParameter();
            pdescripcion.ParameterName = "@descripcion";
            pdescripcion.SqlDbType = SqlDbType.VarChar;
            pdescripcion.Size = 256;
            command.Parameters.Add(pdescripcion);


            SqlParameter pcategoria = new SqlParameter();
            pcategoria.ParameterName = "@idcategoria";
            pcategoria.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pcategoria);

            SqlParameter pestatus = new SqlParameter();
            pestatus.ParameterName = "@estatus";
            pestatus.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pestatus);

            pestatus.Value = estatus;
            pnombre.Value = nombre;
            pdescripcion.Value = descripcion;
            pcodigo.Value = codigo;
            pcategoria.Value = id;

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Guardado correctamente", "Nuevo registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar" + ex.ToString(), "No se guardo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        //termina metodo de insercion

        // metodo para editar un registo
        public string Editar(int id,int estatus, string nombre, string descripcion)
        {


            SqlCommand command = new SqlCommand("uspeditar_categoria", cn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@idcategoria";
            pid.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pid);

            SqlParameter pnombre = new SqlParameter();
            pnombre.ParameterName = "@nombre";
            pnombre.SqlDbType = SqlDbType.VarChar;
            pnombre.Size = 50;
            command.Parameters.Add(pnombre);


            SqlParameter pdescripcion = new SqlParameter();
            pdescripcion.ParameterName = "@descripcion";
            pdescripcion.SqlDbType = SqlDbType.VarChar;
            pdescripcion.Size = 256;
            command.Parameters.Add(pdescripcion);

            SqlParameter pestatus = new SqlParameter();
            pestatus.ParameterName = "@estatus";
            pestatus.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pestatus);
            pestatus.Value =estatus;
            pid.Value = id;
            pnombre.Value = nombre;
            pdescripcion.Value = descripcion;
            
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Editado correctamente","Editar",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar" + ex.ToString());
            }
            return null;
        }
        //termina metodo editar registro
        //berificacion login
        public string Login(string log,string usuario, string password)
        {
            string lusuario = usuario;
            string ppassword = password;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM trabajador WHERE usuario='" + usuario + "' AND password='" + password + "'",cn );
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Form1.mdiobj.almacenToolStripMenuItem.Enabled = true;
                Form1.mdiobj.comprasToolStripMenuItem.Enabled = true;
                Form1.mdiobj.ventasToolStripMenuItem.Enabled = true;
                Form1.mdiobj.trabajadorToolStripMenuItem.Enabled = true;
                
                log = "si";
            }
            else
            {
                MessageBox.Show("Usuario no registrado","usuario no valido",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            return log;
        }
        // termina berificacion de login

        //cargar DGW de categorias
        public void cargarcategorias(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select * from categoria ", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO se puede llenar el campo tabla" + ex.ToString(),"Error de datos",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        //termina cargar DCW de categorias

        //cargar DGW de articulos
        public void cargararticulos(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("exec dbo.uspmostrar_articulo; ", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO se puede llenar el campo tabla" + ex.ToString(), "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //termina cargar DCW de articulos


        //cargar DGW de categorias
        public void buscarcategoria(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select * from categoria  where estatus=1", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO se puede llenar el campo tabla" + ex.ToString(), "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //termina cargar DCW de categorias
    }
}
