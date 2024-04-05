using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Datos
{
    public static class ConexionBD
    {
        public static OracleConnection Conex { get; set; }
    }
}
