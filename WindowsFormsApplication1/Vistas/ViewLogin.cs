using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApplication1
{
    public partial class ViewLogin : Form
    {
        ValidarDatos v = new ValidarDatos();


        public ViewLogin()
        {
            InitializeComponent();
            txtContraseña.PasswordChar = '*'; // modificamos el txtbox a txtpsw
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Login - Sistema de gestion";
            this.CenterToScreen(); // centrar pantalla
            this.txtContraseña.MaxLength = 12;
            this.txtUser.MaxLength = 10;




        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {

            String a = Convert.ToString(txtUser.Text);
            String b = Convert.ToString(txtContraseña.Text);
            Personas p1 = new Personas(a, b);
            p1.LoginValidacion();
            this.Hide();
            this.limpiarCampos();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }
        private void limpiarCampos()
        {

            this.txtUser.Clear();
            this.txtContraseña.Clear();
            this.txtUser.Focus();
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
