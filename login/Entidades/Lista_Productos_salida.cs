using login.Datos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace login.Entidades
{
    public partial class Lista_Productos_salida : Form

    {
        private SalidaInvenario salidaInventarioForm;

        public Lista_Productos_salida(SalidaInvenario salidaInvenario)
        {
            InitializeComponent();
            CargarDatosEnListBox();
            salidaInventarioForm = salidaInvenario;
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // Verificar si hay algún elemento seleccionado en el listBox1
            if (listBox1.SelectedItem != null)
            {
                // Obtener el elemento seleccionado y dividirlo en código y nombre
                string selectedItem = listBox1.SelectedItem.ToString();
                string[] parts = selectedItem.Split('-');
                string codigo = parts[0].Trim(); // Código del producto

                // Verificar si la instancia de entradaInventarioForm es nula antes de intentar acceder a ella
                if (salidaInventarioForm != null)
                {
                    // Llamar al método SetTextCodigo del formulario EntradaInventario para establecer el valor del textCodigo
                    salidaInventarioForm.SetTextCodigo(codigo);

                    // Cerrar el formulario ListaProductos
                    this.Close();
                }
                else
                {
                    // Si la instancia de entradaInventarioForm es nula, mostrar un mensaje de error
                    MessageBox.Show("Error: La instancia de entradaInventarioForm es nula.");
                }
            }
        }

        public void CargarDatosEnListBox()
        {
            if (ConexionBD.Conex.State != ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            try
            {
                string query = @"SELECT COD_PRODUCTO, NOMBRE FROM PRODUCTOS";

                using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Limpiar ListBox antes de agregar elementos
                        listBox1.Items.Clear();

                        // Iterar a través de los datos y agregarlos al ListBox
                        while (reader.Read())
                        {
                            // Obtener el código y el nombre del producto
                            string codigo = reader["COD_PRODUCTO"].ToString();
                            string nombre = reader["NOMBRE"].ToString();

                            // Agregar el código y el nombre del producto al ListBox
                            listBox1.Items.Add(codigo + " - " + nombre);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
