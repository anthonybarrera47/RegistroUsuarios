using Entidades;
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
        public static bool isEmpty(this object obj)
        {
            return obj.ToString()==string.Empty;
        }
        public static bool EsUsuarioNulo(this Usuarios usuarios)
        {
            return usuarios==null;
        }
        public static void Alerta(Page page, TipoAlerta tipoAlerta)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", $"{ tipoAlerta.ToString().ToLower()}()", true);
        }
        public static void MostrarMensaje(Page page,Type type,String key,String script,bool addStringTag)
        {
            ScriptManager.RegisterStartupScript(page,type,key,script,addStringTag);
        }
        
    }
}