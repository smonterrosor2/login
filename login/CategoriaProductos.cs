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
using login.Datos;

namespace login
{
    public partial class CategoriaProductos : Form
    {
        public CategoriaProductos()
        {
            InitializeComponent();
        }

        private void CategoriaProductos_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttBuscar_Click(object sender, EventArgs e)
        {
            BuscarCategoria(textCategoria.Text);
        }

        private void BuscarCategoria(string codigo)
        {
            try
            {
                if (ConexionBD.Conex.State != System.Data.ConnectionState.Open)
                {
                    ConexionBD.Conex.Open(); // Intenta abrir la conexión si no está abierta
                }

                string query = "SELECT NOMBRE, DESCRIPCION FROM CATEGORIA_PRODUCTOS WHERE COD_CATEGORIA = :codigo";

                using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
                {
                    command.Parameters.Add(new OracleParameter("codigo", codigo));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textNombre.Text = reader["NOMBRE"].ToString();
                            textDescripcion.Text = reader["DESCRIPCION"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Categoría no encontrada.");
                            textNombre.Clear();
                            textDescripcion.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar la categoría: {ex.Message}");
            }
        }

        private void buttModificar_Click(object sender, EventArgs e)
        {
            string codigoCategoria = textCategoria.Text;
            string nombreActualizado = textNombre.Text;
            string descripcionActualizada = textDescripcion.Text;

            // Llama al método para actualizar los datos
            ActualizarCategoria(codigoCategoria, nombreActualizado, descripcionActualizada);

            LimpiarCampos();
        }

        private void ActualizarCategoria(string codigoCategoria, string nombreNuevo, string descripcionNueva)
        {
            // Prepara la consulta SQL para actualizar los datos
            string query = "UPDATE CATEGORIA_PRODUCTOS SET NOMBRE = :nombre, DESCRIPCION = :descripcion WHERE COD_CATEGORIA = :codigo";

            // Verifica si la conexión está abierta
            if (ConexionBD.Conex.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            try
            {
                using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
                {
                    // Añade los parámetros para prevenir inyección SQL
                    command.Parameters.Add(new OracleParameter("nombre", nombreNuevo));
                    command.Parameters.Add(new OracleParameter("descripcion", descripcionNueva));
                    command.Parameters.Add(new OracleParameter("codigo", codigoCategoria));

                    // Ejecuta la consulta
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Datos actualizados correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron actualizar los datos. Asegúrate de que el código de categoría sea correcto.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar los datos: {ex.Message}");
            }
        }

        private void buttNuevo_Click(object sender, EventArgs e)
        {
            // Obtiene los valores ingresados
            string codigoCategoria = textCategoria.Text;
            string nombre = textNombre.Text;
            string descripcion = textDescripcion.Text;

            // Llama al método para insertar los datos
            InsertarCategoria(codigoCategoria, nombre, descripcion);

            LimpiarCampos();
        }

        private void InsertarCategoria(string codigoCategoria, string nombre, string descripcion)
        {
            // Prepara la consulta SQL para insertar los datos
            string query = "INSERT INTO CATEGORIA_PRODUCTOS (COD_CATEGORIA, NOMBRE, DESCRIPCION) VALUES (:codigo, :nombre, :descripcion)";

            // Verifica si la conexión está abierta
            if (ConexionBD.Conex.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            try
            {
                using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
                {
                    // Añade los parámetros para prevenir inyección SQL
                    command.Parameters.Add(new OracleParameter("codigo", codigoCategoria));
                    command.Parameters.Add(new OracleParameter("nombre", nombre));
                    command.Parameters.Add(new OracleParameter("descripcion", descripcion));

                    // Ejecuta la consulta
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Datos insertados correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron insertar los datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar los datos: {ex.Message}");
            }
        }

        private void buttEliminar_Click(object sender, EventArgs e)
        {
            string codigoCategoria = textCategoria.Text;

            // Llama al método para eliminar los datos
            EliminarCategoria(codigoCategoria);

            LimpiarCampos();
        }

        private void EliminarCategoria(string codigoCategoria)
        {
            // Prepara la consulta SQL para eliminar los datos
            string query = "DELETE FROM CATEGORIA_PRODUCTOS WHERE COD_CATEGORIA = :codigo";

            // Verifica si la conexión está abierta
            if (ConexionBD.Conex.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            try
            {
                using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
                {
                    // Añade el parámetro para prevenir inyección SQL
                    command.Parameters.Add(new OracleParameter("codigo", codigoCategoria));

                    // Ejecuta la consulta
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Categoría eliminada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la categoría para eliminar. Verifica el código proporcionado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la categoría: {ex.Message}");
            }
        }

        private void buttGuardar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textCategoria.Text = "";
            textNombre.Text = "";
            textDescripcion.Text = "";
        }
    }
}
