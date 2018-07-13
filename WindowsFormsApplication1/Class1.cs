using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Class1 
    {
        public void mostrarDatos(string nombre, string apellido, string edad)
        {
            MessageBox.Show("hola "+ nombre + " "+ apellido + ", su edad es "+edad );
            
        }
    }
}
