using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApplication1.Vistas;

namespace WindowsFormsApplication1
{
    class Personas
    {
        private string nombre;
        private string usuario;
        private string contraseña;
        private string correo;
        private int cod_privilegio;
        private String user;
        private String psw;
        public String a;
        String query1;
        Conectar con = new Conectar();
        ViewRealizarVenta vh1 = new ViewRealizarVenta();
        ViewAñadirCuentaAdmin viewAñadirCuentaAdmin;
        private String prueba;

        public Personas()
        {

        }

        public Personas(String usuario, String contraseña)
        {
            this.user = usuario;
            this.psw = contraseña;
        }

        public void setUser(String nombre_u)
        {
            this.prueba = nombre_u;
        }

        public string getuser()
        {
            return this.prueba;
        }

        public Personas(String nombre, String usuario, String contraseña, String correo, ViewAñadirCuentaAdmin viewAñadirCuentaAdmin)
        {
            this.nombre = nombre;
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.correo = correo;
            this.viewAñadirCuentaAdmin = viewAñadirCuentaAdmin;
        }

        public String capturarUser()
        {
            return user;
        }

        public void LoginValidacion()
        {
            ViewLogin vl1 = new ViewLogin();

            con.Conectarx();

            a = Convert.ToString(user);

            String b = Convert.ToString(psw);

            String query = "SELECT COUNT(*) From Personas where Usuario = '" + a + "' and Contraseña = '" + b + "'";

            SqlCommand comm = new SqlCommand(query, con.conexion);
           
            int count = System.Convert.ToInt32(comm.ExecuteScalar());
           
            if (count > 0)
            {
                vh1.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vl1.Show();
                return;
            }
        }


        public void AgregarUsuario()
        {
            con.Conectarx();

            String query = "Select * from Personas where Usuario = '" + usuario + "'";

            SqlCommand comm = new SqlCommand(query, con.conexion);
           
            int count = System.Convert.ToInt32(comm.ExecuteScalar());
           
            if (count > 0)
            {
                MessageBox.Show("Este usuario existe, por favor utilice otro");
            }
            else
            {
                query1 = "INSERT INTO Personas(id_tipUser,Nombre,Usuario,Contraseña,Correo)";
                query1 += "VALUES('10','" + nombre + "','" + usuario + "','" + contraseña + "','" + correo + "')";

                con.Query(query1);

            }
        }

        public void actualizarDatosUsuarios(DataGridView DataGrid, String query)
        {
            con.Conectarx();
           
            /** obejeto dataset **/
            System.Data.DataSet d = new System.Data.DataSet();

            /** objeto data **/
            SqlDataAdapter da = new SqlDataAdapter(query, con.conexion);

            da.Fill(d, "Personas");
          
            DataGrid.DataSource = d;

            DataGrid.DataMember = "Personas";

            con.Desconectar();
        }

        public void AgregarClientes(String nombre, String rut, int telefono)
        {
            String fecha = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            con.Conectarx();

            String query = "Select * from Clientes where Rut ='" + rut + "'";

            SqlCommand comm = new SqlCommand(query, con.conexion);

            int count = System.Convert.ToInt32(comm.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show("Este rut esta registrado, por favor utilice otro");
            }
            else
            {
                string a = "INSERT INTO Clientes(NombreCliente,Rut,Ranking,Telefono,Fecha_ingreso)";
                a += "values";
                a += "('" + nombre + "','" + rut + "',10,'" + telefono + "','" + fecha + "')";
                con.Query(a);

            }
        }
    }
}
