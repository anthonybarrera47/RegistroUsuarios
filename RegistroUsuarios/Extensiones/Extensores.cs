using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}