using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Datos
{
    public static class CargarDatos
    {
        public static void CargarUltimoIDInventario(TextBox textNoDoc, OracleConnection conexion)
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }

                string query = "SELECT MAX(NO_DOCUMENTO) AS ULTIMO_ID FROM INVENTARIO";
                using (OracleCommand command = new OracleCommand(query, conexion))
                {
                    object resultado = command.ExecuteScalar();

                    if (resultado != DBNull.Value && resultado != null)
                    {
                        int ultimoID = Convert.ToInt32(resultado) + 1;
                        textNoDoc.Text = ultimoID.ToString();
                    }
                    else
                    {
                        textNoDoc.Text = "1";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el último ID de inventario: {ex.Message}");
            }
        }
    }
}
