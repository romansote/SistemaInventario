using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ValidarCampos : Form
    {
        FrmMenu menu = new FrmMenu();
        Validacion validacion = new Validacion();
        public ValidarCampos()
        {
            InitializeComponent();
        }

        private void btnNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.ValidarNumeros(e);
        }

        private void btnLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.ValidarLetras(e);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu.Show();
        }
    }
}
