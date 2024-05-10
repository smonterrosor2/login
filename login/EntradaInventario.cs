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
using System.Net.NetworkInformation;

namespace login
{
    public partial class EntradaInventario : Form
    {
        public EntradaInventario()
        {
            InitializeComponent();
            ConfigurarColumnasDataGridView();
            EstablecerFechaActual();
            textCosto.Text = "0.00";
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
            dataGridView1.Columns.Add("Columna4", "Costo Unitario");
            dataGridView1.Columns.Add("Columna5", "Costo Total");

            // Configura las columnas para que se ajusten y ocupen el espacio disponible.
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void EstablecerFechaActual()
        {
            // Establece la fecha actual en el TextBox textFecha
            textFecha.Text = DateTime.Now.ToString("dd/MM/yy");
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
            if (!ValidarCantidad())
            {
                // Si la validación falla, salir del método
                return;
            }

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
        private bool ValidarCantidad()
        {
            // Verifica si el campo no está vacío y si el número es mayor a cero
            if (string.IsNullOrEmpty(textCantidad.Text) || int.Parse(textCantidad.Text) <= 0)
            {
                MessageBox.Show("Favor de ingresar una cantidad mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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
                // Consultar la información del producto en la tabla PRODUCTOS
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

                            // Mostrar nombre y presentación en textDescripcion
                            textDescripcion.Text = $"{nombre} {presentacion}";

                            // Asignar el precio al campo textCosto
                            textCosto.Text = precio.ToString();
                        }
                        else
                        {
                            MessageBox.Show("El código de producto no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Salir del método si no se encuentra el producto en la tabla PRODUCTOS
                        }
                    }
                }

                // Consultar la existencia del producto en la tabla DETALLE_INVENTARIO
                string queryDetalle = "SELECT SUM(INGRESO) AS TOTAL_INGRESO, SUM(EGRESO) AS TOTAL_EGRESO FROM DETALLE_INVENTARIO WHERE COD_PRODUCTO = :codigo GROUP BY COSTO";
                using (OracleCommand command = new OracleCommand(queryDetalle, ConexionBD.Conex))
                {
                    command.Parameters.Add(new OracleParameter("codigo", codigo));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal totalIngreso = Convert.ToDecimal(reader["TOTAL_INGRESO"]);
                            decimal totalEgreso = Convert.ToDecimal(reader["TOTAL_EGRESO"]);
                            decimal existencia = totalIngreso - totalEgreso;

                            textExistencia.Text = existencia.ToString();
                        }
                        else
                        {
                            // Si no hay registros en DETALLE_INVENTARIO, se establece existencia como 0
                            textExistencia.Text = "0";
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

            string textoNumerico = LimpiarTextoNumerico(textCantidad);

            // Verificar si el texto es un número válido
            if (!string.IsNullOrEmpty(textoNumerico) && decimal.TryParse(textoNumerico, out decimal cantidad))
            {
                // Obtener el valor de textCosto (asumiendo que ya ha sido validado)
                decimal costo = decimal.Parse(textCosto.Text);

                // Calcular el subtotal multiplicando la cantidad por el costo
                decimal subtotal = cantidad * costo;

                // Formatear el subtotal con el prefijo "Q. " y alineado a la derecha
                textSubTotal.Text = string.Format("Q. {0,10}", subtotal.ToString("#,##0.00"));
            }
            else
            {
                // Si el texto no es un número válido o está vacío, limpiar el campo subtotal
                textSubTotal.Text = "";
            }
        }

        private string LimpiarTextoNumerico(TextBox textBox)
        {
            // Eliminar cualquier carácter no numérico del texto
            string textoNumerico = new string(textBox.Text.Where(char.IsDigit).ToArray());

            // Actualizar el texto del TextBox solo si ha cambiado
            if (textBox.Text != textoNumerico)
            {
                textBox.Text = textoNumerico;
                textBox.SelectionStart = textBox.Text.Length;
            }

            // Devolver el texto limpio
            return textoNumerico;
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

                    textCosto.Text = "0.00";
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

        private void buttNuevo_Click(object sender, EventArgs e)
        {
            // Confirmar si se desea realizar la eliminación
            DialogResult result = MessageBox.Show("¿Seguro que desea insertar los registros indicados?", "Confirmar inserción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                InsertarDatos();
                LimpiarControles();
                CargarDatos.CargarUltimoIDInventario(textNoDoc, ConexionBD.Conex);
                EstablecerFechaActual();
            }
        }

        public void InsertarDatos()
        {
            if (ConexionBD.Conex.State != ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            int usuario = EnviarUsuario.GetUsuario();
            string empCodigo = usuario.ToString();

            // Iniciar una transacción
            OracleTransaction transaction = ConexionBD.Conex.BeginTransaction();

            try
            {
                string tipoDocumento = "EI";
                string fecha = textFecha.Text;
                string noDocumento = textNoDoc.Text;

                string queryInsertarInventario = "INSERT INTO INVENTARIO (NO_DOCUMENTO, TIPO_DOCUMENTO, FECHA) VALUES (:noDocumento, :tipoDocumento, TO_DATE(:fecha, 'DD/MM/YY'))";
                using (OracleCommand command = new OracleCommand(queryInsertarInventario, ConexionBD.Conex))
                {
                    command.Parameters.Add(new OracleParameter("noDocumento", noDocumento));
                    command.Parameters.Add(new OracleParameter("tipoDocumento", tipoDocumento));
                    command.Parameters.Add(new OracleParameter("fecha", fecha));
                    command.ExecuteNonQuery();
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Verificar si la fila es la última fila vacía
                    if (row.IsNewRow)
                        continue; // Saltar la iteración si es la última fila vacía

                    string codProducto = row.Cells["Columna1"].Value.ToString();
                    string descripcion = row.Cells["Columna2"].Value.ToString();
                    decimal ingreso = Math.Truncate(Convert.ToDecimal(row.Cells["Columna3"].Value));
                    decimal costo = Math.Truncate(Convert.ToDecimal(row.Cells["Columna4"].Value));
                    decimal subtotal = Math.Truncate(Convert.ToDecimal(row.Cells["Columna5"].Value.ToString().Replace("Q. ", "")));


                    string queryInsertarDetalle = "INSERT INTO DETALLE_INVENTARIO (COD_PRODUCTO, DESCRIPCION, COSTO, INGRESO, EGRESO, SUBTOTAL, EMP_CODIGO, OBSERVACION, NO_DOCUMENTO, TIPO_DOCUMENTO, LINEA) VALUES (:codProducto, :descripcion, :costo, :ingreso, 0, :subtotal, :empCodigo, :observacion, :noDocumento, 'EI', :linea)";
                    using (OracleCommand detalleCommand = new OracleCommand(queryInsertarDetalle, ConexionBD.Conex))
                    {
                        detalleCommand.Parameters.Add(new OracleParameter("codProducto", codProducto));
                        detalleCommand.Parameters.Add(new OracleParameter("descripcion", descripcion));
                        detalleCommand.Parameters.Add(new OracleParameter("costo", costo));
                        detalleCommand.Parameters.Add(new OracleParameter("ingreso", ingreso));
                        detalleCommand.Parameters.Add(new OracleParameter("subtotal", subtotal));
                        detalleCommand.Parameters.Add(new OracleParameter("empCodigo", empCodigo));
                        detalleCommand.Parameters.Add(new OracleParameter("observacion", textObservacion.Text));
                        detalleCommand.Parameters.Add(new OracleParameter("noDocumento", noDocumento));
                        detalleCommand.Parameters.Add(new OracleParameter("linea", row.Index + 1));
                        detalleCommand.ExecuteNonQuery();
                    }
                }

                // Commit de la transacción si todo se ejecutó correctamente
                transaction.Commit();
                MessageBox.Show("Datos insertados correctamente en la base de datos.");
                CargarDatos.CargarUltimoIDInventario(textNoDoc, ConexionBD.Conex);
            }
            catch (Exception ex)
            {
                // Rollback de la transacción en caso de error
                transaction.Rollback();
                MessageBox.Show($"Error al insertar datos en la base de datos: {ex.Message}");
            }
        }

        private bool ValidarUsuario(string empCodigo)
        {
            string query = "SELECT COUNT(*) FROM USUARIOS WHERE EMP_CODIGO = :empCodigo";
            using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
            {
                command.Parameters.Add(new OracleParameter("empCodigo", empCodigo));
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        private void textNoDoc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void BuscarParaEliminar(string noDocumento)
        {
            // Prepara la consulta SQL para buscar en la tabla DETALLE_INVENTARIO
            string queryDetalle = "SELECT COD_PRODUCTO, DESCRIPCION, INGRESO, COSTO, SUBTOTAL FROM DETALLE_INVENTARIO WHERE NO_DOCUMENTO = :noDocumento";

            // Prepara la consulta SQL para obtener la observación de la tabla DETALLE_INVENTARIO
            string queryObservacion = "SELECT OBSERVACION FROM DETALLE_INVENTARIO WHERE NO_DOCUMENTO = :noDocumento AND ROWNUM = 1";

            // Prepara la consulta SQL para obtener la fecha de la tabla INVENTARIO
            string queryFecha = "SELECT FECHA FROM INVENTARIO WHERE NO_DOCUMENTO = :noDocumento";

            // Verifica si la conexión está abierta
            if (ConexionBD.Conex.State != ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            try
            {
                using (OracleCommand commandDetalle = new OracleCommand(queryDetalle, ConexionBD.Conex))
                {
                    commandDetalle.Parameters.Add(new OracleParameter("noDocumento", noDocumento));
                    using (OracleDataReader readerDetalle = commandDetalle.ExecuteReader())
                    {
                        // Limpiar las filas existentes del DataGridView
                        dataGridView1.Rows.Clear();

                        // Iterar sobre los resultados y agregarlos al DataGridView
                        while (readerDetalle.Read())
                        {
                            object[] rowData = new object[5]; // 5 columnas
                            rowData[0] = readerDetalle["COD_PRODUCTO"];
                            rowData[1] = readerDetalle["DESCRIPCION"];
                            rowData[2] = readerDetalle["INGRESO"];
                            rowData[3] = readerDetalle["COSTO"];
                            rowData[4] = readerDetalle["SUBTOTAL"];
                            dataGridView1.Rows.Add(rowData);
                        }
                    }
                }

                // Obtener la observación de DETALLE_INVENTARIO
                using (OracleCommand commandObservacion = new OracleCommand(queryObservacion, ConexionBD.Conex))
                {
                    commandObservacion.Parameters.Add(new OracleParameter("noDocumento", noDocumento));
                    object observacion = commandObservacion.ExecuteScalar();
                    if (observacion != null)
                    {
                        textObservacion.Text = observacion.ToString();
                    }
                }

                // Obtener la fecha de INVENTARIO
                using (OracleCommand commandFecha = new OracleCommand(queryFecha, ConexionBD.Conex))
                {
                    commandFecha.Parameters.Add(new OracleParameter("noDocumento", noDocumento));
                    object fecha = commandFecha.ExecuteScalar();
                    if (fecha != null)
                    {
                        textFecha.Text = fecha.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarRegistro(string noDocumento)
        {
            // Prepara la consulta SQL para eliminar los datos
            string queryInventario = "DELETE FROM INVENTARIO WHERE NO_DOCUMENTO = :noDocumento";
            string queryDetalle = "DELETE FROM DETALLE_INVENTARIO WHERE NO_DOCUMENTO = :noDocumento";

            // Verifica si la conexión está abierta
            if (ConexionBD.Conex.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            // Iniciar una transacción
            OracleTransaction transaction = ConexionBD.Conex.BeginTransaction();

            try
            {

                // Eliminar los registros de la tabla DETALLE_INVENTARIO asociados al NO_DOCUMENTO
                using (OracleCommand commandDetalle = new OracleCommand(queryDetalle, ConexionBD.Conex))
                {
                    // Añade el parámetro para prevenir inyección SQL
                    commandDetalle.Parameters.Add(new OracleParameter("noDocumento", noDocumento));

                    // Ejecuta la consulta
                    int resultDetalle = commandDetalle.ExecuteNonQuery();

                    if (resultDetalle > 0)
                    {
                        //MessageBox.Show("Registros de detalle de inventario eliminados correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros de detalle de inventario para eliminar. Verifica el número de documento proporcionado.");
                    }
                }

                // Eliminar el registro de la tabla INVENTARIO
                using (OracleCommand commandInventario = new OracleCommand(queryInventario, ConexionBD.Conex))
                {
                    // Añade el parámetro para prevenir inyección SQL
                    commandInventario.Parameters.Add(new OracleParameter("noDocumento", noDocumento));

                    // Ejecuta la consulta
                    int resultInventario = commandInventario.ExecuteNonQuery();

                    if (resultInventario > 0)
                    {
                        // Commit de la transacción si todo se ejecutó correctamente
                        transaction.Commit();
                        MessageBox.Show("Registro eliminado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro de inventario para eliminar. Verifica el número de documento proporcionado.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Rollback de la transacción en caso de error
                transaction.Rollback();
                MessageBox.Show($"Error al eliminar los registros: {ex.Message}");
            }
        }

        private void buttEliminar_Click(object sender, EventArgs e)
        {

            // Obtener el número de documento del TextBox
            string noDocumento = textBuscarDoc.Text;

            // Confirmar si se desea realizar la eliminación
            DialogResult result = MessageBox.Show("¿Seguro que desea eliminar los registros asociados al documento?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Llamar al método para eliminar registros del inventario
                EliminarRegistro(noDocumento);
                LimpiarControles();
                CargarDatos.CargarUltimoIDInventario(textNoDoc, ConexionBD.Conex);
                EstablecerFechaActual();
            }
        }

        private void textCodigo_TextChanged(object sender, EventArgs e)
        {
            LimpiarTextoNumerico(textCodigo);
        }

        private void textCosto_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttBuscarDoc_Click(object sender, EventArgs e)
        {
            string noDocumento = textBuscarDoc.Text;

            // Llama al método para buscar en la base de datos y mostrar la información
            BuscarParaEliminar(noDocumento);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBuscarDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter no es un dígito y tampoco es una tecla de control (como retroceso).
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Maneja el evento, impidiendo que el carácter se escriba en el TextBox.
            }
        }

        private void textObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
