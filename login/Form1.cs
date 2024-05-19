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
//using system.data.oracleclient;
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
        //codigo de la contrase�a
        private void textpass_Enter(object sender, EventArgs e)
        {
            if (textpass.Text == "CONTRASE�A")
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
                textpass.Text = "CONTRASE�A";
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
        //configuraci�n de los botones para cerrar y minimizar
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

            // Obtiene los valores ingresados
            string usuarioIngresado = textuser.Text;
            string contrase�aIngresada = Convert.ToBase64String(Encoding.UTF8.GetBytes(textpass.Text));



            // Llamada al m�todo para comprobar las credenciales
            if (ComprobarCredenciales(usuarioIngresado, contrase�aIngresada))
            {
                menu menu = new menu();
                this.Hide();
                menu.Show();



                int codigoEmpleado = obtenerCodigoUsuario(textuser.Text);
                EnviarUsuario.SetUsuario(codigoEmpleado);

            }
            else
            {
                MessageBox.Show("Usuario o contrase�a incorrectos.");
            }

        }
        private bool ComprobarCredenciales(string usuario, string contrase�a)
        {
            // Usa try-catch para manejar posibles excepciones
            try
            {
                OracleConnection connection = new OracleConnection(connectionString);
                connection.Open();
                ConexionBD.Conex = connection; // Asignas la conexi�n para uso futuro
                string query = "SELECT COUNT(*) FROM USUARIOS WHERE NOMBRES = :usuario AND CONTRASE�A = :contrase�a";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    // A�ade los par�metros para prevenir inyecci�n SQL
                    command.Parameters.Add(new OracleParameter("usuario", usuario));
                    command.Parameters.Add(new OracleParameter("contrase�a", contrase�a));

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


        private void textuser_TextChanged(object sender, EventArgs e)
        {

        }

        public int obtenerCodigoUsuario(string nombreUsuario)
        {
            int codigoEmpleado = -1; // Valor predeterminado si no se encuentra

            try
            {
                if (ConexionBD.Conex.State != ConnectionState.Open)
                {
                    MessageBox.Show("La conexi�n a la base de datos no est� abierta.");
                    return codigoEmpleado;
                }

                string query = "SELECT EMP_CODIGO FROM USUARIOS WHERE NOMBRES = :nombreUsuario";

                using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
                {
                    // Agregar el par�metro para el nombre del usuario
                    command.Parameters.Add(new OracleParameter("nombreUsuario", nombreUsuario));

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        codigoEmpleado = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores
                MessageBox.Show($"Error al obtener el c�digo de usuario: {ex.Message}");
            }

            return codigoEmpleado;
        }

        private void textpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Letras_TextChanged(object sender, EventArgs e)
        {

        }

        private void Letras_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras (a-z, A-Z) y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // Ignorar el evento de tecla
            }
        }

        private void checkBoxMostrarContrase�a_CheckedChanged(object sender, EventArgs e)
        {
            textpass.UseSystemPasswordChar = !checkBoxMostrarContrase�a.Checked;
        }
    }
}