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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEj1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ValidarCampos v1 = new ValidarCampos();
            v1.Show();
            
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            this.Hide();
            Suma sum = new Suma();
            sum.Show();
        }

        private void btnTrycatch_Click(object sender, EventArgs e)
        {
            this.Hide();
            TryCatch tr = new TryCatch();
            tr.Show();
        }
    }
}
