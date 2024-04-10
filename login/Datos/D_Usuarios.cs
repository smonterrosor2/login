using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Datos
{
    public class D_Usuarios
    {
        public DataTable listado_us()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("SELECT NOMBRES,CONTRASEÑA FROM USUARIOS;", SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            { 
                if(SqlCon.State==ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
