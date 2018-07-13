using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Vistas
{
    public partial class ViewAñadirCuentaAdmin : Form
    {
        public ViewAñadirCuentaAdmin()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Administrar Cuentas de usuario";
            txtNombre.MaxLength = 40;
            txtUser.MaxLength = 20;
            txtpsw.MaxLength = 12;
            txtpsw2.MaxLength = 12;
            txtCorreo.MaxLength = 30;

            this.cargarGrilla();
        }


        private void cargarGrilla()
        {
            Personas p1 = new Personas();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            p1.actualizarDatosUsuarios(this.dataGridView1, "Select id_admin, Nombre,Usuario,Correo from Personas");
            /** Renombrando titulo de columnas **/

            dataGridView1.Columns[0].HeaderText = "Id ";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Usuario";
            dataGridView1.Columns[3].HeaderText = "Correo Electronico";
            /** Ajustando tamaño **/
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 171;
        }

        private void GuardarUsuario()
        {
            if (txtNombre.Text == String.Empty)
            {
                MessageBox.Show("Por favor complete el campo nombre");
                this.txtNombre.Focus();
                return;


            }
            else if (txtUser.Text == String.Empty)
            {
                MessageBox.Show("Por favor complete el campo usuario");
                this.txtUser.Focus();
                return;

            }
            else if (txtpsw.Text == String.Empty)
            {
                MessageBox.Show("Por favor complete el campo contraseña");
                this.txtpsw.Focus();

            }
            else if (txtpsw2.Text == String.Empty)
            {
                MessageBox.Show("Por favor complete el campo repita la contraseña");
                this.txtpsw2.Focus();
                return;
            }
            else
            {
                if (txtpsw.Text.Equals(txtpsw2.Text))
                {
                    Personas p1 = new Personas(txtNombre.Text, txtUser.Text, txtpsw.Text, txtCorreo.Text, this);
                    p1.AgregarUsuario();
                    this.limpiarCampos();
                    this.cargarGrilla();
                }
                else
                {
                    MessageBox.Show("La contraseña no coincide, por favor intentelo nuevamente");
                    this.txtpsw.Clear();
                    this.txtpsw2.Clear();
                    this.txtpsw.Focus();
                    return;
                }

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarUsuario();


        }

        private void limpiarCampos()
        {
            this.txtNombre.Clear();
            this.txtCorreo.Clear();
            this.txtpsw.Clear();
            this.txtpsw2.Clear();
            this.txtUser.Clear();
            this.txtNombre.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // generamos objeto contextmenu
                ContextMenu y = new ContextMenu();

                // añadimos opcion al menu
                y.MenuItems.Add("Eliminar Cuenta").Name = "del";

                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                y.Show(dataGridView1, new Point(e.X, e.Y));

                // Verificamos si es la opcion que queremos
                if (y.MenuItems[0].Text.ToString() == "Eliminar Cuenta")
                {
                    if (MessageBox.Show("Esta seguro que deseas eliminar esta cuenta?", "Eliminar Cuenta ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Conectar cn = new Conectar();
                        cn.BorrarDatos("DELETE from Personas where id_admin ='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
                        this.cargarGrilla();
                    }
                    /* cn.Conectarx();
                     cn.BorrarDatos()
                     MessageBox.Show("" +dgcategorias.CurrentRow.Cells[0].Value.ToString());
                     * */

                }
            }
        }
    }
}