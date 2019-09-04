using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioUsuarios :RepositorioBase<Usuarios>
    {
        public RepositorioUsuarios() : base()
        {

        }
        public static bool ValidarUsuario(string NombreUsuario)
        {
            bool paso = true;
            RepositorioBase<Entidades.Usuarios> repositorio = new RepositorioBase<Entidades.Usuarios>();
            List<Entidades.Usuarios> usuario = new List<Entidades.Usuarios>();
            Expression<Func<Entidades.Usuarios, bool>> filtro = x => true;
            var username = NombreUsuario;
            filtro = x => x.UserName.Equals(username);
            usuario = repositorio.GetList(filtro);
            if (usuario.Exists(x => username.Equals(username)))
                paso = false;
            repositorio.Dispose();
            return paso;
        }
        public static string SHA1(object password)
        {
            using (System.Security.Cryptography.SHA1Managed SHa1 = new System.Security.Cryptography.SHA1Managed())
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
