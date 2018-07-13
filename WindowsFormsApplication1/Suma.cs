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
    
    public partial class Suma : Form
    {
        Validacion validacion = new Validacion();
        public Suma()
        {
            InitializeComponent();
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            double num1, num2, res;
            num1 = Convert.ToDouble(txtnum1.Text);
            num2 = Convert.ToDouble(txtnum2.Text);
            res = num1 + num2;
            textBox1.Text = Convert.ToString(res);
        }

        private void txtnum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.ValidarNumeros(e);
        }

        private void txtnum2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.ValidarNumeros(e);
        }


       

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
       
    }
}
