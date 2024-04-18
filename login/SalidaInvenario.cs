using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using login.Datos;

namespace login
{
    public partial class SalidaInvenario : Form
    {
        public SalidaInvenario()
        {
            InitializeComponent();
            ConfigurarColumnasDataGridView();
            EstablecerFechaActual();
            textCosto.Text = "8.00";
        }

        private void SalidaInvenario_Load(object sender, EventArgs e)
        {
            CargarDatos.CargarUltimoIDInventario(textNoDoc, ConexionBD.Conex);
        }

        // CONEXION DE LA BD para buscar

        private void BuscarDetalle_Inventario(string codigoSalida)
        {
            // Verifica si la conexión está abierta
            if (ConexionBD.Conex.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            try
            {
                string query = @"SELECT p.COD_PRODUCTO, p.NO_DOCUMENTO, p.NOMBRE, p.PRESENTACION, p.PRECIO, m.NOMBRE AS NOMBRE_MARCA, c.NOMBRE AS NOMBRE_CATEGORIA
                         FROM PRODUCTOS p
                         JOIN MARCA m ON p.COD_MARCA = m.COD_MARCA
                         JOIN CATEGORIA_PRODUCTOS c ON p.COD_CATEGORIA = c.COD_CATEGORIA
                         WHERE p.COD_PRODUCTO = :codigo";

                using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
                {
                    command.Parameters.Add(new OracleParameter("codigo", codigoSalida));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Asumiendo que tienes los controles TextBox y ComboBox adecuados en tu formulario
                            textFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                            textCodigo.Text = reader["COD_PRODUCTO"].ToString();
                            textNoDoc.Text = reader["NO_DOCUMENTO"].ToString();
                            textDescripcion.Text = reader["DESCRIPCION"].ToString();
                            textExistencia.Text = reader["EGRESO"].ToString(); 
                            //textCantidad.Text = reader["INGRESO"].ToString(); //PENDIENTE
                            textCosto.Text = reader["COSTO"].ToString();
                            textSubTotal.Text = reader["SUBTOTAL"].ToString();
                            textObservacion.Text = reader["OBSERVACION"].ToString();
                            textCantidad2.Text = reader["Cantidad2"].ToString(); //PENDIENTE
                            textTotal.Text = reader["TOTAL"].ToString(); //PENDIENTE


                            // Establece la selección de los ComboBox basándose en los nombres. 
                            // Esto requiere que los ComboBox ya tengan cargados todos los posibles valores.
                            //comboMarca.SelectedIndex = comboMarca.FindStringExact(reader["NOMBRE_MARCA"].ToString());
                            //comboCategoria.SelectedIndex = comboCategoria.FindStringExact(reader["NOMBRE_CATEGORIA"].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Salidas del inventario no encontrado.");
                            // Limpia los campos si se desea
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar datos de las salidas del inventario: {ex.Message}");
            }
        }

        private void buttBuscar_Click(object sender, EventArgs e)
        {

            // Obtiene el código del producto desde el TextBox textCodigo
            string codigoSalida = textCodigo.Text.Trim();

            // Verifica si el campo no está vacío
            if (string.IsNullOrEmpty(codigoSalida))
            {
                MessageBox.Show("Por favor, ingresa un código de producto.");
                return;
            }

            // Llama al método BuscarProducto con el código proporcionado
            BuscarDetalle_Inventario(codigoSalida);
    }


    private void ConfigurarColumnasDataGridView()
        {
            //Limpia el dataGridView antes de agregar columnas.
            dataGridView1.Columns.Clear();

            // Agrega encabezados de las columnas.
            dataGridView1.Columns.Add("Columna1", "Codigo");
            dataGridView1.Columns.Add("Columna2", "Descripcion");
            dataGridView1.Columns.Add("Columna3", "Cantidad");
            dataGridView1.Columns.Add("Columna4", "CostoUnitario");
            dataGridView1.Columns.Add("Columna5", "CostoTotal");

            // Configura las columnas para que se ajusten y ocupen el espacio disponible.
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void EstablecerFechaActual()
        {
            // Establece la fecha actual en el TextBox textFecha
            textFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void SalidaInventario_Load(object sender, EventArgs e)
        {
            CargarDatos.CargarUltimoIDInventario(textNoDoc, ConexionBD.Conex);
        }

        private void textCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter no es un dígito y tampoco es una tecla de control (como retroceso).
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Maneja el evento, impidiendo que el carácter se escriba en el TextBox.
            }
        }

        private void buttInsertar_Click(object sender, EventArgs e)
        {
            ValidarCantidad();

            // Obtener los valores de los TextBox
            string codigo = textCodigo.Text;
            string descripcion = textDescripcion.Text;
            int cantidad = Convert.ToInt32(textCantidad.Text);
            decimal costo = Convert.ToDecimal(textCosto.Text);
            string subtotal = textSubTotal.Text;

            // Agregar una nueva fila al DataGridView con los valores de los TextBox
            dataGridView1.Rows.Add(codigo, descripcion, cantidad, costo, subtotal);

            // Limpiar los TextBox después de la inserción
            LimpiarTextBoxes();
            SumarColumnas();
        }

        // Método para validar el valor ingresado en el campo Cantidad
        private void ValidarCantidad()
        {
            // Verifica si el campo no está vacío y si el número es mayor a cero
            if (string.IsNullOrEmpty(textCantidad.Text) || int.Parse(textCantidad.Text) <= 0)
            {
                MessageBox.Show("Favor de ingresar una cantidad mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void textCantidad_TextChanged(object sender, EventArgs e)
        {
            decimal cantidad = 0;

            if (!string.IsNullOrEmpty(textCantidad.Text))
            {
                cantidad = decimal.Parse(textCantidad.Text);
            }

            // Obtener el valor de textCosto (asumiendo que ya ha sido validado)
            decimal costo = decimal.Parse(textCosto.Text);

            // Calcular el subtotal multiplicando la cantidad por el costo
            decimal subtotal = cantidad * costo;

            // Formatear el subtotal con el prefijo "Q. " y alineado a la derecha
            textSubTotal.Text = string.Format("Q. {0,10}", subtotal.ToString("#,##0.00"));
        }

        private void LimpiarTextBoxes()
        {
            textCodigo.Text = "";
            textDescripcion.Text = "";
            textExistencia.Text = "";
            textCantidad.Text = "";
            textSubTotal.Text = "";
        }

        private void SumarColumnas()
        {
            decimal sumaCantidad = 0;
            decimal sumaTotal = 0;

            // Iterar a través de las filas del DataGridView, excluyendo la última fila
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewRow fila = dataGridView1.Rows[i];

                // Verificar si la celda en la tercera columna es convertible a decimal
                if (decimal.TryParse(fila.Cells[2].Value?.ToString(), out decimal cantidad))
                {
                    // Sumar el valor de la tercera columna
                    sumaCantidad += cantidad;

                    // Obtener el valor de la quinta columna como cadena
                    string textoSubtotal = fila.Cells[4].Value?.ToString();

                    if (!string.IsNullOrEmpty(textoSubtotal))
                    {
                        // Eliminar el prefijo "Q. " si existe
                        textoSubtotal = textoSubtotal.Replace("Q. ", "");

                        // Convertir el valor restante a decimal
                        if (decimal.TryParse(textoSubtotal, out decimal subtotal))
                        {
                            // Sumar el valor de la quinta columna
                            sumaTotal += subtotal;
                        }
                        else
                        {
                            // Manejar el error de conversión
                            MessageBox.Show($"Error de conversión en la fila {i + 1}: Valor no válido '{textoSubtotal}'", "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            // Asignar la suma de la tercera columna a textCantidad2
            textCantidad2.Text = sumaCantidad.ToString();

            // Formatear el valor de sumaTotal con el prefijo "Q. " y alineado a la derecha
            textTotal.Text = string.Format("Q. {0,10}", sumaTotal.ToString("#,##0.00"));
        }

        private void buttGuardar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox && control != textFecha && control != textNoDoc)
                {
                    ((TextBox)control).Text = "";
                }
            }

            // Limpiar el DataGridView
            dataGridView1.Rows.Clear();

        }
    }
}

