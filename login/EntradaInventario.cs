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
    public partial class EntradaInventario : Form
    {
        public EntradaInventario()
        {
            InitializeComponent();
            ConfigurarColumnasDataGridView();
            EstablecerFechaActual();
            textCosto.Text = "8.00";
        }

        // Método que maneja el evento CodigoSeleccionado del formulario ListaProductos
        private void ListaProductosForm_CodigoSeleccionado(string codigo)
        {
            // Asignar el código seleccionado al textbox en EntradaInventario
            textCodigo.Text = codigo;
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

        private void EntradaInventario_Load(object sender, EventArgs e)
        {
            CargarDatos.CargarUltimoIDInventario(textNoDoc, ConexionBD.Conex);
        }

        private void labelNombre_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

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

        private void buttBuscar_Click(object sender, EventArgs e)
        {
            CargarDatosProducto();
        }
        
        private void CargarDatosProducto()
        {
            if (ConexionBD.Conex.State != ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            string codigo = textCodigo.Text;

            try
            {
                string queryDetalle = "SELECT DESCRIPCION, INGRESO, EGRESO, COSTO FROM DETALLE_INVENTARIO WHERE COD_PRODUCTO = :codigo";
                using (OracleCommand command = new OracleCommand(queryDetalle, ConexionBD.Conex))
                {
                    command.Parameters.Add(new OracleParameter("codigo", codigo));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string descripcion = reader["DESCRIPCION"].ToString();
                            decimal ingreso = Convert.ToDecimal(reader["INGRESO"]);
                            decimal egreso = Convert.ToDecimal(reader["EGRESO"]);
                            decimal costo = Convert.ToDecimal(reader["COSTO"]);
                            decimal existencia = ingreso - egreso;

                            textDescripcion.Text = descripcion;
                            textExistencia.Text = existencia.ToString();
                            textCosto.Text = costo.ToString();
                        }
                        else
                        {
                            string queryProductos = "SELECT NOMBRE, PRESENTACION, PRECIO FROM PRODUCTOS WHERE COD_PRODUCTO = :codigo";
                            using (OracleCommand productosCommand = new OracleCommand(queryProductos, ConexionBD.Conex))
                            {
                                productosCommand.Parameters.Add(new OracleParameter("codigo", codigo));
                                using (OracleDataReader productosReader = productosCommand.ExecuteReader())
                                {
                                    if (productosReader.Read())
                                    {
                                        string nombre = productosReader["NOMBRE"].ToString();
                                        string presentacion = productosReader["PRESENTACION"].ToString();
                                        decimal precio = Convert.ToDecimal(productosReader["PRECIO"]);

                                        textDescripcion.Text = $"{nombre} {presentacion}";
                                        textExistencia.Text = "0";
                                        textCosto.Text = precio.ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El código de producto no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el producto: {ex.Message}");
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

        private void textCodigo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                // Crear una instancia del formulario ListaProductos y pasar el formulario EntradaInventario como argumento
                ListaProductos listaProductosForm = new ListaProductos(this);

                // Mostrar el formulario ListaProductos
                listaProductosForm.Show();
            }
        }

        public void SetTextCodigo(string codigo)
        {
            textCodigo.Text = codigo;
        }

        private void textCosto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
