using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HamzaIndividueelProject
{
    public class Hasher
    {
        public static string hashPassword (string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider ();
            byte[] password_bytes = Encoding.ASCII.GetBytes (password);
            byte[] encrypted_bytes = sha1.ComputeHash(password_bytes);
            return Convert.ToBase64String(encrypted_bytes);
        }
        
        
        
        /*public static string Hash(string password)
        {
            // One Liner :)
            return Convert.ToBase64String(SHA512.Create().ComputeHash(Encoding.UTF32.GetBytes(password)));
       }*/
    }
}
