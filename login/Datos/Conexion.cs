using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Datos
{
    public class Conexion
    {
        private static Conexion con = null;
        public Conexion()
        {

        }
        public OracleConnection CrearConexion()
        {
            OracleConnection cadena = new OracleConnection();
            try
            {
                cadena.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)" +
                                            "(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)))" +
                                             ";User Id=InventarioDB;Password=root;";
            }
            catch (Exception ex)
            {
                cadena = null;
                throw ex;
            }
            return cadena;
        }

        //Valida si ya hay conexión a la BD, sino hay crea una nueva
        public static Conexion getInstancia()
        { 
            if (con == null)
            {  
                con = new Conexion(); 
            }
            return con;
        }
    }
}
