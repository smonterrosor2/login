using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics.Contracts;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data.OracleClient;
using login.Datos;


namespace login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //se usa para que se mueva nuestra ventana a varios lados
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);

        //se utiliza cuando el mouse sale del cuadro de texto del usuario
        private void textuser_Leave(object sender, EventArgs e)
        {
            if (textuser.Text == "")
            {
                textuser.Text = "USUARIO";
                textuser.ForeColor = Color.DimGray;
            }

        }
        //codigo de la contraseña
        private void textpass_Enter(object sender, EventArgs e)
        {
            if (textpass.Text == "CONTRASEÑA")
            {
                textpass.Text = "";
                textpass.ForeColor = Color.LightGray;
                textpass.UseSystemPasswordChar = true;
            }
        }

        private void textpass_Leave(object sender, EventArgs e)
        {
            if (textpass.Text == "")
            {
                textpass.Text = "CONTRASEÑA";
                textpass.ForeColor = Color.DimGray;
                textpass.UseSystemPasswordChar = false;
            }
        }
        //codigo del usuario
        private void textuser_Enter(object sender, EventArgs e)
        {
            if (textuser.Text == "USUARIO")
            {
                textuser.Text = "";
                textuser.ForeColor = Color.LightGray;
            }

        }
        //configuración de los botones para cerrar y minimizar
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnmaximizar.Visible = false;
            btnrestaurar.Visible = true;
        }
        private void btnrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnrestaurar.Visible = false;
            btnmaximizar.Visible = true;
        }
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        //se utiliza para arrastrar la ventana con el mouse
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //LOGIN Y CONEXION DE MENU

        private string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));User Id=InventarioDB;Password=root;";
        //OracleConnection conexion = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));User Id=InventarioDB;Password=root;");
        private void btnlogin_Click(object sender, EventArgs e)
        {
            /*OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));User Id=InventarioDB;Password=root;");
            ora.Open();
            MessageBox.Show("abierto");
            ora.Close();*/
            /*if (textuser.Text == "admin" && textpass.Text == "123")
            {
                menu menu = new menu();
                this.Hide();
                menu.Show();
            }

            else
            {
                MessageBox.Show("Usuario y Contraseña Incorrectos");

            }*/

            /*conexion.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIOS WHERE NOMBRES = :usuario AND APELLIDOS = :contra", conexion);
            //comando.Parameters.AddWithValue(":usuario", textuser.Text);
            //comando.Parameters.AddWithValue(":contra", textpass.Text);
            comando.Parameters.Add(":usuario", OracleDbType.Varchar2).Value = textuser.Text;
            comando.Parameters.Add(":contra", OracleDbType.Varchar2).Value = textpass.Text;

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                /*menu formulario = new menu();
                conexion.Close();
                formulario.Show();*/

            /*  menu menu = new menu();
              this.Hide();
              menu.Show(); 
            MessageBox.Show("Usuario y Contraseña Incorrectos");
            conexion.Close();
        }*/

            // Obtiene los valores ingresados
            string usuarioIngresado = textuser.Text;
            string contraseñaIngresada = textpass.Text;

            // Llama al método para comprobar las credenciales
            if (ComprobarCredenciales(usuarioIngresado, contraseñaIngresada))
            {
                // MessageBox.Show("Inicio de sesión exitoso.");
                menu menu = new menu();
                this.Hide();
                menu.Show();
                // Procede con la lógica de inicio de sesión exitoso
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }

        }
        private bool ComprobarCredenciales(string usuario, string contraseña)
        {
            // Usa try-catch para manejar posibles excepciones
            try
            {
                OracleConnection connection = new OracleConnection(connectionString);
                connection.Open();
                ConexionBD.Conex = connection; // Asignas la conexión para uso futuro
                string query = "SELECT COUNT(*) FROM USUARIOS WHERE NOMBRES = :usuario AND CONTRASEÑA = :contraseña";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    // Añade los parámetros para prevenir inyección SQL
                    command.Parameters.Add(new OracleParameter("usuario", usuario));
                    command.Parameters.Add(new OracleParameter("contraseña", contraseña));

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Si count es 1, entonces las credenciales son correctas
                    return count == 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al comprobar las credenciales: {ex.Message}");
                return false;
            }
        }

        /*private void Listado_us()
        {
            D_Usuarios Datos = new D_Usuarios();
            cmbUsuarios.DataSource = Datos.listado_us();
            cmbUsuarios.ValueMember = "NOMBRES";
        }*/
    }
}