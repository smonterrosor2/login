using System;
using System.Security.Cryptography;
using System.Text;

namespace login.Utilidades
{
    public static class Helper
    {
        public static string EncodePassword(string originalPassword)
        {
            using (SHA1 sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] inputBytes = Encoding.Unicode.GetBytes(originalPassword);
                byte[] hash = sha1.ComputeHash(inputBytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}
