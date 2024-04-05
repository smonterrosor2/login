using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Entidades
{
    public class E_Usuarios
    {
        public int Emp_codigo {  get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set;}
        public string Direccion { get; set;}
        public int No_identificacion { get; set;}
        public string Tipo_usuario { get; set;}
        public string Contraseña { get; set;}
        public string Genero { get; set;}
    }
}
