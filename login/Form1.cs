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
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (textuser.Text == "admin" && textpass.Text == "123")
            {
                menu menu = new menu();
                this.Hide();
                menu.Show();
            }

            else
            {
                MessageBox.Show("Usuario y Contraseña Incorrectos");
                
            }

        }
    }
}
