using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ViewAgregarProductos : Form
    {
        Productos pr = new Productos();
        Personas p1 = new Personas();
        Conectar cn = new Conectar();
        ValidarDatos vd = new ValidarDatos();
        SqlDataReader rows;
        int x;

        public ViewAgregarProductos()
        {
            InitializeComponent();

            this.Text = "Administrar Productos";
            this.CenterToScreen();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Properties.Resources.image;


        }

        private void btnSelimg_Click(object sender, EventArgs e)
        {
            this.cargarImagen();

        }

        private void cargarImagen() // OK
        {
            openFileDialog1.Filter = "jpeg Image|*.jpeg|jpg|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|png Image|*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Redimencionamos la imagen a la dimencion del picture
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); // Mostramos la imagen cargada al openDialog

                }
                catch (Exception)
                {
                    MessageBox.Show("La imagen excede el tamaño permitido");
                }
            }

        }


        private void ViewAgregarProductos_Load(object sender, EventArgs e)
        {
            this.agregarGrillaCategoria();
            this.CargarCategoriasCombo();
            this.agregarGrillaProductos();
            // Validando largo
            this.qwwe.MaxLength = 50;
            this.txtPrecio.MaxLength = 8;
            this.txtStock.MaxLength = 5;
            this.txtPrecio.MaxLength = 8;
            this.txtNombreCat.MaxLength = 20;
            this.txtBusqueda.MaxLength = 20;
            // this.txtDescuento.MaxLength = 3;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pr.agregarCategoriasP(txtNombreCat.Text);
            this.txtNombreCat.Clear();
            this.txtNombreCat.Focus();
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            pr.agregarCategoriasP(txtNombreCat.Text);
            this.txtNombreCat.Clear();
            this.txtNombreCat.Focus();
            this.agregarGrillaCategoria();
            this.cbxCategoria.Items.Clear();
            this.CargarCategoriasCombo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }


        private void CargarCategoriasCombo()
        {
            rows = cn.getSqlQuery("Select * from Categoria_Productos");
            cbxCategoria.Text = "--Seleccione--";
            while (rows.Read())
            {
                cbxCategoria.Items.Add(rows["nombreCategoria"]);
            }
        }
        /*  private void CargarDescuentoCombo()
          {
              for (int a = 0; a < 101; a++)
              {
                  cbxDescuento.Items.Add(a);
              }

          } */


        private void agregarGrillaCategoria()
        {
            dgcategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgcategorias.AllowUserToAddRows = false;

            p1.actualizarDatosUsuarios(this.dgcategorias, "Select id_CatProducto, nombreCategoria from Categoria_Productos");
            dgcategorias.Columns[0].Width = 0;
            dgcategorias.Columns[1].HeaderText = "Nombre Categoria";
            dgcategorias.Columns[1].Width = 250;

        }
        private void agregarGrillaProductos()
        {
            dgProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgProductos.AllowUserToAddRows = false;

            p1.actualizarDatosUsuarios(this.dgProductos, "Select id_producto, Categoria_Productos.nombreCategoria, Productos.Nombre, Productos.Precio, Productos.Stock from Productos INNER JOIN Categoria_Productos on Categoria_Productos.id_CatProducto = Productos.id_CatProducto ");
            dgProductos.Columns[1].HeaderText = "Categoria ";
            dgProductos.Columns[2].HeaderText = "Nombre ";
            dgProductos.Columns[3].HeaderText = "Precio ";
            dgProductos.Columns[4].HeaderText = "Stock ";
            dgProductos.Columns[0].Width = 100;
            dgProductos.Columns[1].Width = 150;
            dgProductos.Columns[2].Width = 40;
            dgProductos.Columns[3].Width = 40;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            int p;
            if (cbxCategoria.Text.Length == 0)
            {
                MessageBox.Show("Debe seleccionar una Categoria!");
                return;
            }
            else if (qwwe.Text == String.Empty)
            {
                MessageBox.Show("Debe rellenar el campo Nombre");
                qwwe.Focus();
            }
            else if (txtStock.Text == String.Empty)
            {
                MessageBox.Show("Debe rellenar el campo stock");
                txtStock.Focus();
            }
            else if (txtPrecio.Text == String.Empty)
            {
                MessageBox.Show("Debe rellenar el campo precio");
                txtPrecio.Focus();
            }

            else
            {
                String a = cbxCategoria.SelectedItem.ToString();
                x = pr.capturarIdCategoria(a);
                p = Convert.ToInt32(txtPrecio.Text);
                int s = Convert.ToInt32(txtStock.Text);
                cn.Conectarx();
                pr.insertarProducto(x, qwwe.Text, p, s, pictureBox1);
                this.LimpiarCampos();
                this.agregarGrillaProductos();

            }





            // pr.insertarProducto(x, txtNombre.Text, txtPrecio, txtStock, txtDescuento, pictureBox1);
        }


        private void cv_Click(object sender, EventArgs e)
        {

        }

        private void cbxCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgcategorias_KeyPress(object sender, KeyPressEventArgs e)
        {

        }



        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            this.cbxCategoria.SelectedIndex = -1;
            this.qwwe.Clear();
            this.txtPrecio.Clear();
            this.txtStock.Clear();

            pictureBox1.Image = Properties.Resources.image;
            this.qwwe.Focus();
        }

        private void dgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            vd.ValidarDigitos(e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            vd.ValidarDigitos(e);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void agregarGrillaBusqueda()
        {
            Personas p1 = new Personas();
            dgProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgProductos.AllowUserToAddRows = false;

            //  p1.actualizarDatosUsuarios(this.dgProductos, "Select Productos.id_producto,Categoria_Productos.nombreCategoria, Productos.Nombre, Productos.Precio, Productos.Stock from Productos INNER JOIN Categoria_Productos on Categoria_Productos.id_CatProducto = Productos.id_CatProducto where Nombre like '" + txtBusqueda.Text + "%" + "' and  Stock >0");
            p1.actualizarDatosUsuarios(this.dgProductos, "Select Productos.id_producto,Categoria_Productos.nombreCategoria, Productos.Nombre, Productos.Precio, Productos.Stock from Productos INNER JOIN Categoria_Productos on Categoria_Productos.id_CatProducto = Productos.id_CatProducto where Nombre like '" + txtBusqueda.Text + "%" + "' and  Stock >0");
            dgProductos.Columns[1].HeaderText = "Categoria ";
            dgProductos.Columns[2].HeaderText = "Nombre ";
            dgProductos.Columns[3].HeaderText = "Precio ";
            dgProductos.Columns[4].HeaderText = "Stock ";
            dgProductos.Columns[0].Width = 100;
            dgProductos.Columns[1].Width = 150;
            dgProductos.Columns[2].Width = 40;
            dgProductos.Columns[3].Width = 40;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != String.Empty)
            {
                this.agregarGrillaBusqueda();
            }
            else
            {
                MessageBox.Show("Por Favor rellene el campo de busqueda");
                this.txtBusqueda.Focus();
            }

        }

        private void dgcategorias_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // generamos objeto contextmenu
                ContextMenu y = new ContextMenu();

                // añadimos opcion al menu
                y.MenuItems.Add("Eliminar Categoria").Name = "del";

                int currentMouseOverRow = dgcategorias.HitTest(e.X, e.Y).RowIndex;

                y.Show(dgcategorias, new Point(e.X, e.Y));

                // Verificamos si es la opcion que queremos
                if (y.MenuItems[0].Text.ToString() == "Eliminar Categoria")
                {
                    ViewEliminarCategoria ve = new ViewEliminarCategoria();
                    ve.setCategoria(dgcategorias.CurrentRow.Cells[0].Value.ToString(), dgcategorias.CurrentRow.Cells[1].Value.ToString());
                    ve.Show();
                    this.Close();
                    /* cn.Conectarx();
                     cn.BorrarDatos()
                     MessageBox.Show("" +dgcategorias.CurrentRow.Cells[0].Value.ToString());
                     * */

                }
            }
        }

        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
