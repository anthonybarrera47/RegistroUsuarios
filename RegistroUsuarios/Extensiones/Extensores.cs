using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace RegistroUsuarios.Extensiones
{
    public static class Extensores
    {
        public static int ToInt(this object obj)
        {
            return Convert.ToInt32(obj);
        }
        public static void MostrarMensaje(Page page,Type type,String key,String script,bool addStringTag)
        {
            ScriptManager.RegisterStartupScript(page,type,key,script,addStringTag);
        }
        public static string SHA1(this object password)
        {
            using (SHA1Managed SHa1 = new SHA1Managed())
            {
                var hash = SHa1.ComputeHash(Encoding.UTF8.GetBytes(password.ToString()));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte item in hash)
                {
                    sb.Append(item.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}