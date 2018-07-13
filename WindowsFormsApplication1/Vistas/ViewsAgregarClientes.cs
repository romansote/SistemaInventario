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
    public partial class ViewsAgregarClientes : Form
    {
        Personas p1 = new Personas();
        Conectar conn = new Conectar();
        ValidarDatos vd = new ValidarDatos();
        private string cri;
        public ViewsAgregarClientes()
        {
            InitializeComponent();
            this.Text = "Administrar Clientes";
            this.CenterToScreen();
            this.dtFecha.Enabled = false;

            //  lbRanking.Hide();
            //lbTitRanking.Hide();
            recRanking.Hide();

            this.txtNombre.MaxLength = 30;
            this.txtRut.MaxLength = 10;
            this.txtTelefono.MaxLength = 9;


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewsAgregarClientes_Load(object sender, EventArgs e)
        {

            actualizarGrilla();
            actualizarComboBox();

        }


        private void actualizarComboBox()
        {
            cbCriterio.Text = "-- Criterio --";
            cbCriterio.Items.Add("Nombre");
            cbCriterio.Items.Add("Rut");
            cbCriterio.Items.Add("Telefono");
        }
        private void actualizarGrilla()
        {
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AllowUserToAddRows = false;

            p1.actualizarDatosUsuarios(this.dgvClientes, "Select * from Clientes");

            dgvClientes.Columns[1].HeaderText = "Nombre";
            dgvClientes.Columns[2].HeaderText = "Rut";
            dgvClientes.Columns[3].HeaderText = "Ranking";
            dgvClientes.Columns[4].HeaderText = "Telefono";
            dgvClientes.Columns[5].HeaderText = "Cliente desde";

            /** Ajustando tamaño **/
            for (int a = 0; a < 4; a++)
                dgvClientes.Columns[a].Width = 104;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show(txtRut.Text);
            if (txtNombre.Text == String.Empty)
            {
                MessageBox.Show("Por favor rellena el campo nombre");
                this.txtNombre.Focus();
            }
            else if (txtTelefono.Text == String.Empty)
            {
                MessageBox.Show("Por favor rellena el campo Telefono");
                this.txtTelefono.Focus();
            }
            else if (txtRut.Text == String.Empty)
            {
                MessageBox.Show("Por favor rellena el campo Rut");
                this.txtRut.Focus();
            }
            else
            {

                p1.AgregarClientes(txtNombre.Text, txtRut.Text, Convert.ToInt32(txtTelefono.Text));
                this.limpiarCampos();
                this.actualizarGrilla();
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTelefono.Clear();
            txtRut.Clear();
            txtNombre.Clear();

        }
        private void limpiarCampos()
        {
            txtTelefono.Clear();
            txtRut.Clear();
            txtNombre.Clear();
        }

        private void RankingDisable()
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {

            vd.ValidarDigitos(e);
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtRut_TextChanged(object sender, EventArgs e)
        {

        }

        private void realizarBusqueda(string criterio, string coincidencia)
        {

            if (criterio == "Nombre")
            {
                cri = "NombreCliente";
            }
            else if (criterio == "Rut")
            {
                cri = "Rut";
            }
            else if (criterio == "Telefono")
            {
                cri = "Telefono";
            }
            Personas p1 = new Personas();
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AllowUserToAddRows = false;

            p1.actualizarDatosUsuarios(this.dgvClientes, "Select * from Clientes where " + cri + " like '" + coincidencia + "%'");

            dgvClientes.Columns[0].HeaderText = "Id";
            dgvClientes.Columns[1].HeaderText = "Nombre";
            dgvClientes.Columns[2].HeaderText = "Rut";
            dgvClientes.Columns[3].HeaderText = "Ranking";
            dgvClientes.Columns[4].HeaderText = "Telefono";
            dgvClientes.Columns[4].HeaderText = "Cliente desde";

            /** Ajustando tamaño **/
            for (int a = 0; a < 5; a++)
                dgvClientes.Columns[a].Width = 104;
        }

        private void dgvClientes_MouseClick(object sender, MouseEventArgs e)
        {
            Conectar cn = new Conectar();


            if (e.Button == MouseButtons.Right)
            {
                // generamos objeto contextmenu
                ContextMenu y = new ContextMenu();

                // añadimos opcion al menu
                y.MenuItems.Add("Eliminar Cliente").Name = "del";

                int currentMouseOverRow = dgvClientes.HitTest(e.X, e.Y).RowIndex;

                y.Show(dgvClientes, new Point(e.X, e.Y));

                // Verificamos si es la opcion que queremos
                if (y.MenuItems[0].Text.ToString() == "Eliminar Cliente")
                {
                    if (MessageBox.Show("Esta seguro que desea eliminar los registros de este cliente?", "Eliminar registros?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string id = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                        //  MessageBox.Show("" + id);

                        cn.BorrarCategoriaP("DELETE from Ventas where id_cliente = '" + id + "'");

                        cn.BorrarCategoriaP("DELETE from Clientes where id_cliente = '" + id + "'");
                        MessageBox.Show("Datos modificados!");
                        this.actualizarGrilla();
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.cbCriterio.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un criterio");
                this.cbCriterio.Focus();
            }
            else
            {
                String a = cbCriterio.SelectedItem.ToString();
                this.realizarBusqueda(a, txtBusqueda.Text.ToString());
            }
        }


    }
}
