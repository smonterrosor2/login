﻿using login.Datos;
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

namespace login
{
    public partial class MantenimientoMarca : Form
    {
        public MantenimientoMarca()
        {
            InitializeComponent();
        }

        private void buttBuscar_Click(object sender, EventArgs e)
        {
            // Obtiene el código ingresado por el usuario
            string codigoMarca = textCodigo.Text;

            // Llama al método para buscar la marca
            BuscarMarca(codigoMarca);
        }

        private void BuscarMarca(string codigoMarca)
        {
            // Verifica si la conexión está abierta
            if (ConexionBD.Conex.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            try
            {
                string query = "SELECT NOMBRE FROM MARCA WHERE COD_MARCA = :codigo";

                using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
                {
                    // Añade el parámetro para prevenir inyección SQL
                    command.Parameters.Add(new OracleParameter("codigo", codigoMarca));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textNombre.Text = reader["NOMBRE"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Marca no encontrada.");
                            textNombre.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar la marca: {ex.Message}");
            }
        }

        private void buttNuevo_Click(object sender, EventArgs e)
        {
            // Obtiene los valores ingresados por el usuario
            string codigoMarca = textCodigo.Text;
            string nombreMarca = textNombre.Text;

            // Llama al método para insertar la marca
            InsertarMarca(codigoMarca, nombreMarca);

            LimpiarCampos();
        }

        private void InsertarMarca(string codigoMarca, string nombreMarca)
        {
            // Verifica si la conexión está abierta
            if (ConexionBD.Conex.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            try
            {
                string query = "INSERT INTO MARCA (COD_MARCA, NOMBRE) VALUES (:codigo, :nombre)";

                using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
                {
                    // Añade los parámetros para prevenir inyección SQL
                    command.Parameters.Add(new OracleParameter("codigo", codigoMarca));
                    command.Parameters.Add(new OracleParameter("nombre", nombreMarca));

                    // Ejecuta la consulta
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Marca insertada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo insertar la marca.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar la marca: {ex.Message}");
            }
        }

        private void buttModificar_Click(object sender, EventArgs e)
        {
            // Obtiene los valores ingresados por el usuario
            string codigoMarca = textCodigo.Text;
            string nombreNuevo = textNombre.Text;

            // Llama al método para actualizar la marca
            ActualizarMarca(codigoMarca, nombreNuevo);

            LimpiarCampos();
        }

        private void ActualizarMarca(string codigoMarca, string nombreNuevo)
        {
            // Verifica si la conexión está abierta
            if (ConexionBD.Conex.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            try
            {
                string query = "UPDATE MARCA SET NOMBRE = :nombre WHERE COD_MARCA = :codigo";

                using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
                {
                    // Añade los parámetros para prevenir inyección SQL
                    command.Parameters.Add(new OracleParameter("nombre", nombreNuevo));
                    command.Parameters.Add(new OracleParameter("codigo", codigoMarca));

                    // Ejecuta la consulta
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Marca actualizada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la marca para actualizar. Verifica el código proporcionado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la marca: {ex.Message}");
            }
        }

        private void buttEliminar_Click(object sender, EventArgs e)
        {
            // Obtiene el código ingresado por el usuario
            string codigoMarca = textCodigo.Text;

            // Muestra un mensaje de confirmación antes de proceder con la eliminación
            var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta marca?",
                                                 "Confirmar eliminación",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // Llama al método para eliminar la marca
                EliminarMarca(codigoMarca);

                LimpiarCampos();
            }
            
        }

        private void EliminarMarca(string codigoMarca)
        {
            // Verifica si la conexión está abierta
            if (ConexionBD.Conex.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("La conexión a la base de datos no está abierta.");
                return;
            }

            try
            {
                string query = "DELETE FROM MARCA WHERE COD_MARCA = :codigo";

                using (OracleCommand command = new OracleCommand(query, ConexionBD.Conex))
                {
                    // Añade el parámetro para prevenir inyección SQL
                    command.Parameters.Add(new OracleParameter("codigo", codigoMarca));

                    // Ejecuta la consulta
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Marca eliminada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la marca para eliminar. Verifica el código proporcionado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la marca: {ex.Message}");
            }
        }

        private void buttGuardar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textCodigo.Text = "";
            textNombre.Text = "";
        }
    }
}
