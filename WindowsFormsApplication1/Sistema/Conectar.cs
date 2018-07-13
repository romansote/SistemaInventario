using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;

namespace WindowsFormsApplication1
{

    public class Conectar
    {

        public SqlConnection conexion;
        public string conneccion;

        public SqlCommand cmd;
        SqlDataReader reader;
        SqlDataReader res;


        public Conectar()
        {
            conneccion = "Data Source=127.0.0.1; Initial Catalog=SoftwareInventario; user id=sa; password=7w9e8r$%&41v6sdf;MultipleActiveResultSets=true;";
        }

        public void Conectarx()
        {
            conexion = new SqlConnection(conneccion);
            try
            {
                conexion.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo establecer conexion" + e);
            }
        }

        public void Desconectar()
        {
            conexion.Close();
        }

        public void Query(String Query)
        {
            SqlCommand comm = new SqlCommand(Query, conexion);
            int filasEn = comm.ExecuteNonQuery();

            if (filasEn > 0)
                MessageBox.Show("Los datos fueron ingresados exitosamente !", "Exito !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Desconectar();
        }

        public void queryMigrarCategoria(string Query)
        {
            this.Conectarx();
            SqlCommand comm = new SqlCommand(Query, conexion);
            int filasEn = comm.ExecuteNonQuery();
            Desconectar();

        }
        public void BorrarCategoriaP(String Query)
        {
            this.Conectarx();
            SqlCommand comm = new SqlCommand(Query, conexion);
            int filasEn = comm.ExecuteNonQuery();


            Desconectar();
        }
        public void BorrarDatos(String Query)
        {
            this.Conectarx();
            SqlCommand comm = new SqlCommand(Query, conexion);
            int filasEn = comm.ExecuteNonQuery();
            MessageBox.Show("Los Datos fueron eliminado exitosamente", "Exito !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (filasEn > 0)
            { }
            else
                MessageBox.Show("Error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Desconectar();
        }

        public void insertarVenta()
        {
            string nombreg = "roman";

            //  MessageBox.Show(idProductos+"-"+idCliente+"-"+MedioPago+"-"+fecha+"-"+PrecioVenta);


            /*     string cadena = "INSERT INTO Ventas";
                 cadena += "(id_producto,id_cliente,id_MedioPago,fecha_Venta,PrecioVenta)";
                 cadena += "Values('" + idProductos + "'," + idCliente + "," + MedioPago + ",'" + fecha + "','" + PrecioVenta + "')";
                 MessageBox.Show(cadena); */
            String cadena = "Insert Into Categoria_Productos(nombreCategoria)";
            cadena += "Values('" + nombreg + "')";
            SqlCommand cmd = new SqlCommand(cadena, conexion);
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

        }

        /** 
         * Metodo para extraer datos de la base de datos
         * **/
        public SqlDataReader getConsultasSql(String query)
        {

            conexion = new SqlConnection(conneccion);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(query, conexion);
            if (cmd.ExecuteNonQuery() > 0)
            {
                reader = cmd.ExecuteReader();
            }
            else
            {
                MessageBox.Show("No se encontraron resultados");

            }
            return reader;
        }

        public SqlDataReader getSqlQuery(String query)
        {
            conexion = new SqlConnection(conneccion);
            conexion.Open();
            cmd = new SqlCommand(query, conexion);

            try
            {
                res = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo ejecutar la consulta, " + ex.ToString());
            }
            return res;

            /**   cmd = new SqlCommand("Select * from Clientes",conexion);

              res = cmd.ExecuteReader();

               while(res.Read())
               {
                   MessageBox.Show(""+res["NombreCliente"]);
               }
             * 
             * **/

        }


    }
}
