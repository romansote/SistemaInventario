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
using System.Globalization;
using WindowsFormsApplication1.Vistas;

namespace WindowsFormsApplication1
{
    public partial class ViewRealizarVenta : Form
    {

        Conectar cn = new Conectar();
        Productos pr = new Productos();


        int total = 0;
        String codigos = "";
        public SqlDataReader datos;
        string precio_f;

        string categoria;
        string nombre;
        string precio;
        string stock;
        string id;
        int id_cliente;

        public ViewRealizarVenta()
        {
            InitializeComponent();
            // deshabilitamos campos clientes
            this.deshabilitarCliente();
            // deshabilitamos campos de busqueda
            this.deshabilitarBusqueda();
            // deshabilitamos campo de total y terminar venta
            this.DeshabilitarFinalizarVenta();
            // Titulo ventana
            this.Text = "Realizar Venta - [Desarrollado por Roman Mardones Valenzuela]";
            // Centrar ventana al cargar el proyecto
            this.CenterToScreen();


        }

        private void deshabilitarCliente()
        {
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            txtFecha.Enabled = false;
        }

        private void deshabilitarBusqueda()
        {
            txtBusqueda.Enabled = false;
        }

        private void DeshabilitarFinalizarVenta()
        {

            btnTerminarVenta.Enabled = false;
        }
        private void HabilitarBusqueda()
        {
            txtBusqueda.Enabled = true;
        }

        private void HabilitarFinalizarVenta()
        {

            btnTerminarVenta.Enabled = true;
        }
        private void ViewRealizarPedidos_Load(object sender, EventArgs e)
        {
            ViewLogin vl = new ViewLogin();
            vl.Hide();
            this.txtBusqueda.MaxLength = 20;
            this.agregarGrillaBusqueda();

        }

        private void CargarProductos()
        {
            ValidarDatos val = new ValidarDatos();
            int c;

            //obtengo la cantidad de filas que hay añadidas 
            c = Convert.ToInt32(dataGridView1.Rows.Count);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.ColumnCount = 5;

            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "Categoria";
            dataGridView1.Columns[2].Name = "Nombre";
            dataGridView1.Columns[3].Name = "Precio";
            dataGridView1.Columns[4].Name = "Stock";
            dataGridView1.Columns[0].Width = 42;
            dataGridView1.Columns[2].Width = 149;
            dataGridView1.Columns[4].Width = 50;
            // metodo para crear rows con datos

            dataGridView1.Rows.Add(id, categoria, nombre, precio, stock);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void CargarDatosClientes()
        {

            // Consultamos si existe el rut del cliente  
            datos = cn.getSqlQuery("Select * From Clientes WHERE Rut ='" + mskRut.Text + "'");

            if (datos.Read())
            {
                // Cargamos datos del cliente en los txtbox en el caso que existe  
                id_cliente = Convert.ToInt32(datos["id_cliente"]);
                txtNombre.Text = Convert.ToString(datos["NombreCliente"]);
                txtTelefono.Text = Convert.ToString(datos["Telefono"]);
                txtFecha.Text = Convert.ToString(datos["fecha_ingreso"]);

                // Habilitamos paso 2, buscar producto
                this.HabilitarBusqueda();

            }
            else
            {
                MessageBox.Show("El rut ingresado no existe en la base de datos! ");
            }
        }

        private void agregarGrillaBusqueda()
        {
            Personas p1 = new Personas();
            gvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvProductos.AllowUserToAddRows = false;

            p1.actualizarDatosUsuarios(this.gvProductos, "Select Productos.id_producto,Categoria_Productos.nombreCategoria, Productos.Nombre, Productos.Precio, Productos.Stock from Productos INNER JOIN Categoria_Productos on Categoria_Productos.id_CatProducto = Productos.id_CatProducto where Nombre like '" + txtBusqueda.Text + "%" + "' and  Stock >0");

            gvProductos.Columns[0].HeaderText = "Id ";
            gvProductos.Columns[1].HeaderText = "Categoria ";
            gvProductos.Columns[2].HeaderText = "Nombre ";
            gvProductos.Columns[3].HeaderText = "Precio ";
            gvProductos.Columns[4].HeaderText = "Stock ";
            gvProductos.Columns[0].Width = 33;
            gvProductos.Columns[1].Width = 110;
            gvProductos.Columns[2].Width = 160;
            gvProductos.Columns[3].Width = 80;
            gvProductos.Columns[4].Width = 42;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.CargarDatosClientes();
        }

        private void mskRut_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Personas p1 = new Personas();

            this.agregarGrillaBusqueda();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                // generamos objeto contextmenu
                ContextMenu m = new ContextMenu();

                // añadimos opcion al menu
                m.MenuItems.Add("Seleccionar producto").Name = "sel";

                //capturamos posicion
                int currentMouseOverRow = gvProductos.HitTest(e.X, e.Y).RowIndex;


                // mostramos el menu
                m.Show(gvProductos, new Point(e.X, e.Y));

                // Verificamos si es la opcion que queremos
                if (m.MenuItems[0].Text.ToString() == "Seleccionar producto")
                {
                    categoria = gvProductos.CurrentRow.Cells[1].Value.ToString();
                    nombre = gvProductos.CurrentRow.Cells[2].Value.ToString();
                    precio = gvProductos.CurrentRow.Cells[3].Value.ToString();
                    stock = gvProductos.CurrentRow.Cells[4].Value.ToString();
                    id = gvProductos.CurrentRow.Cells[0].Value.ToString();

                    this.CargarProductos();
                    Personas p1 = new Personas();

                    this.agregarGrillaBusqueda();

                    this.HabilitarFinalizarVenta();
                }



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnTerminarVenta_Click(object sender, EventArgs e)
        {


            ValidarDatos vd = new ValidarDatos();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //recorre las celdas y las va sumando
                total += Convert.ToInt32(row.Cells[3].Value);
                //recorre las seldas y va concatenando los id de los productos
                codigos += String.Concat(row.Cells[0].Value + ",");
            }

            precio_f = Convert.ToString(total);
            cn.Query("INSERT INTO Ventas (id_producto,id_cliente,id_MedioPago,fecha_Venta,PrecioVenta) Values ('" + codigos + "'," + id_cliente + ",1000,'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + precio_f + "')");
            cn.Desconectar();

            this.GestionarStock();


        }

        public void GestionarStock()
        {

            String value = codigos;
            Char delimiter = ',';
            String[] substrings = value.Split(delimiter);
            foreach (var substring in substrings)
            {
                if (substring != String.Empty)
                {
                    cn.Conectarx();
                    //MessageBox.Show(""+Convert.ToInt32(substring));
                    String cadena = "Update Productos set Stock = (Stock-1) where id_producto = '" + substring + "'";

                    cn.queryMigrarCategoria(cadena);

                    this.LimpiarCamposVenta();
                }
            }

        }

        private void LimpiarCamposVenta()
        {
            mskRut.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtFecha.Clear();
            txtBusqueda.Clear();
            this.dataGridView1.Rows.Clear();
            this.agregarGrillaBusqueda();
        }


        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void acercaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbPrecio_Click(object sender, EventArgs e)
        {

        }

        private void administrarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAgregarProductos vp = new ViewAgregarProductos();
            vp.Show();
        }

        private void agregarNuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewsAgregarClientes vc = new ViewsAgregarClientes();
            vc.Show();
        }

        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAñadirCuentaAdmin vam = new ViewAñadirCuentaAdmin();
            vam.Show();
        }

        private void copyrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAcerca vacerca = new ViewAcerca();
            vacerca.Show();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                // generamos objeto contextmenu
                ContextMenu y = new ContextMenu();

                // añadimos opcion al menu
                y.MenuItems.Add("Eliminar producto").Name = "del";

                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                y.Show(dataGridView1, new Point(e.X, e.Y));

                // Verificamos si es la opcion que queremos
                if (y.MenuItems[0].Text.ToString() == "Eliminar producto")
                {
                    ViewEliminarCategoria ve = new ViewEliminarCategoria();
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.LimpiarCamposVenta();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
