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
    public partial class TryCatch : Form
    {
        Validacion val = new Validacion();
        public TryCatch()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           // val.ValidarNumeros(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // val.ValidarNumeros(e);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
             double num1=0, num2=0, res=0;
            try
            {
               
                num1 = Convert.ToDouble(textBox1.Text);
                num2 = Convert.ToDouble(textBox2.Text);
                res = (num1 / num2);
                textBox3.Text = Convert.ToString(res);

            }
            catch
            {
                MessageBox.Show("Ingrese solo valores numericos");         
            }
           

        }
    }
}
