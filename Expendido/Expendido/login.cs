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
    public partial class login : Form
    {
        string log = "no";
        conexion c = new conexion();
        public login()
        {
            InitializeComponent();
            LblHora.Text = DateTime.Now.ToString();
        }
        Form1 fo = new Form1();
        private void login_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {

            if (TxtUsuario.Text == "")
            {
                MessageBox.Show("Campo Ususario vacio","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                TxtUsuario.Focus();
            }
            else if (TxtPassword.Text == "")
            {
                MessageBox.Show("Campo Password vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtPassword.Focus();
            }
            else
            {
                 log = c.Login(log, TxtUsuario.Text, TxtPassword.Text);
                if (log == "si")
                {
                    this.Close();
                    this.Dispose();

                }
            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            
        }
    }
    }
