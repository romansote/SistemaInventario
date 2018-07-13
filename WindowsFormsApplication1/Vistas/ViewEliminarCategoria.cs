using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ViewEliminarCategoria : Form
    {
        Conectar cn = new Conectar();
        private string id;
        private string nombre;
        private string total;
        SqlDataReader rows;
        public ViewEliminarCategoria()
        {
            InitializeComponent();
            this.CenterToScreen();
            radioButton2.AutoCheck = false;
            radioButton2.AutoCheck = true;
            radioButton1.AutoCheck = false;
            radioButton1.AutoCheck = true;
        }

        private void ViewEliminarCategoria_Load(object sender, EventArgs e)
        {

            this.Text = "Eliminar Categoria :" + id + " -" + nombre;
            this.lbMensaje.Text = "Actualmente tienes productos en esta categoria";
            this.DeshabilitarCambioCat();
            this.CargarCategoriasCombo();

        }

        public void setCategoria(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }


        private void DeshabilitarCambioCat()
        {
            this.rsCP.Hide();
            this.lbCP.Hide();
            this.cbxCP.Hide();
        }

        private void HabilitarCambioCat()
        {
            this.rsCP.Show();
            this.lbCP.Show();
            this.cbxCP.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.DeshabilitarCambioCat();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {

                this.HabilitarCambioCat();

            }

        }
        private void EliminarRegistros()
        {
            if (MessageBox.Show("Esta seguro que deseas eliminar la categoria y sus productos?", "Eliminar registros?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.EliminarProductosCategoria();
                this.EliminarCategoria();

            }
        }

        private void EliminarProductosCategoria()
        {
            cn.Conectarx();

            cn.BorrarCategoriaP("delete from productos where id_CatProducto = '" + id + "'");
        }

        private void EliminarCategoria()
        {
            cn.Conectarx();
            cn.BorrarCategoriaP("Delete Categoria_Productos where id_CatProducto = '" + id + "'");
        }

        private void btnEliminarCat_Click(object sender, EventArgs e)
        {
            ViewAgregarProductos vap = new ViewAgregarProductos();

            if (radioButton1.Checked == true)
            {
                this.EliminarRegistros();
                this.Hide();
                vap.Show();
            }
            else if (radioButton2.Checked == true)
            {

                if (cbxCP.Text.Length != 0)
                {
                    this.MigrarProdCategoria();
                    this.EliminarCategoria();

                    this.Hide();
                    vap.Show();
                    // actualizar registros a nueva categoria
                    // eliminar categoria
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Categoria!");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar una accion para continuar");
            }

            // 
        }

        private void CargarCategoriasCombo()
        {
            cn.Conectarx();
            String cadena = "Select * from Categoria_Productos where id_CatProducto not in (" + id + ")";
            rows = cn.getSqlQuery(cadena);
            cbxCP.Text = "--Seleccione--";
            while (rows.Read())
            {
                cbxCP.Items.Add(rows["id_CatProducto"] + " - " + rows["nombreCategoria"]);
            }
        }

        private void MigrarProdCategoria()
        {
            String a = cbxCP.SelectedItem.ToString();
            String value = a;
            Char delimiter = '-';
            String[] substrings = value.Split(delimiter);

            String codigo = Convert.ToString(substrings[0]);

            cn.Conectarx();
            cn.queryMigrarCategoria("update Productos set id_CatProducto = '" + codigo + "' where id_CatProducto = '" + id + "';");
        }

    }
}
