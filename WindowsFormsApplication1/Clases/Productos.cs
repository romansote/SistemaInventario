using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Productos
    {

        SqlDataReader dr;
        SqlDataReader id;
        int idCategoria;

        public Productos()
        {

        }

        public void agregarCategoriasP(String nombre)
        {
            Conectar con = new Conectar();

            if (nombre != String.Empty)
            {
                dr = con.getSqlQuery("Select * From Categoria_Productos where nombreCategoria ='" + nombre + "'");
               
                if (dr.Read())
                {
                    MessageBox.Show("El nombre de la categoria ya existe!.");
                }
                else
                {
                    String cadena = "Insert Into Categoria_Productos(nombreCategoria)";
                    cadena += "Values('" + nombre + "')";
                    con.Query(cadena);
                    con.Desconectar();
                }
            }
            else
            {
                MessageBox.Show("Por favor rellene el campo Nombre!.");
            }
        }

        public int capturarIdCategoria(String nombre)
        {
            Conectar cn = new Conectar();
           
            id = cn.getSqlQuery("Select id_CatProducto from Categoria_Productos where nombreCategoria ='" + nombre + "'");

            if (id.Read())
            {
                idCategoria = Convert.ToInt32(id["id_CatProducto"]);
            }

            return this.idCategoria;
        }

        public void insertarProducto(int Categoria, String nombre, int precio, int stock, PictureBox pic)
        {
            Conectar cn = new Conectar();
           
            cn.Conectarx();

            if (nombre == String.Empty)
            {
                MessageBox.Show("Debe rellenar el campo nombre");
                return;
            }
            else if (precio.ToString() == String.Empty)
            {
                MessageBox.Show("Debe rellenar el campo precio");
                return;
            }
            else if (stock.ToString() == String.Empty)
            {
                MessageBox.Show("Debe rellenar el campo nombre");
                return;
            }
            else
            {
                String cadena = "INSERT INTO Productos(id_CatProducto,Nombre,Precio,Stock,Imagen)";
               
                cadena += "VALUES(@id,@nombre,@precio,@stock,@imagen)";

                SqlCommand cmd = new SqlCommand(cadena, cn.conexion);

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                cmd.Parameters.Add("@precio", SqlDbType.Int);
                cmd.Parameters.Add("@stock", SqlDbType.Int);
                cmd.Parameters.Add("@imagen", SqlDbType.Image);
                cmd.Parameters["@id"].Value = Categoria;
                cmd.Parameters["@nombre"].Value = nombre;
                cmd.Parameters["@precio"].Value = precio;
                cmd.Parameters["@stock"].Value = stock;

                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                cmd.Parameters["@imagen"].Value = ms.GetBuffer();

                int c = cmd.ExecuteNonQuery();

                if (c > 0)
                {
                    MessageBox.Show("Producto insertado correctamente");
                }
                else
                {
                    MessageBox.Show("No se insertaron datos");
                    return;
                }
                cn.Desconectar();

            }
        }

        public void insertarVenta(String idProductos, int idCliente, int MedioPago, String fecha, String PrecioVenta)
        {
            Conectar cn = new Conectar();
            MessageBox.Show(idProductos + "-" + idCliente + "-" + MedioPago + "-" + fecha + "-" + PrecioVenta);

            string cadena = "INSERT INTO Ventas";
            cadena += "(id_producto,id_cliente,id_MedioPago,fecha_Venta,PrecioVenta)";
            cadena += "Values('" + idProductos + "'," + idCliente + "," + MedioPago + ",'" + fecha + "','" + PrecioVenta + "')";
            cn.Query(cadena);

        }
    }
}
