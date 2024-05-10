using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Datos
{
    public static class EnviarUsuario
    {
        private static int usuario;

        public static void SetUsuario(int user)
        {
            usuario = user;
        }

        public static int GetUsuario()
        {
            return usuario;
        }
    }
}
