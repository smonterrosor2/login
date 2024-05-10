using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Security.Cryptography;
using System.Text;

class Encriptacion
{

    public string StringToBase64(string str)
    {
        // Convierte el string en un arreglo de bytes
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
        // Convierte los bytes en Base64
        string base64String = Convert.ToBase64String(bytes);
        return base64String;
    }
    static string Base64ToString(string base64String)
    {
        // Convierte el Base64 en un arreglo de bytes
        byte[] bytes = Convert.FromBase64String(base64String);
        // Convierte los bytes en string
        string str = System.Text.Encoding.UTF8.GetString(bytes);
        return str;
    }
}