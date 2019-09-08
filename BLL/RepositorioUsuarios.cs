using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioUsuarios : RepositorioBase<Usuarios>
    {
        public RepositorioUsuarios() : base()
        {

        }
        public override Usuarios Buscar(int id)
        {
            Usuarios usuarios = new Usuarios();
            try
            {
                usuarios = _db.Usuario.Include(x => x.TelefonoDetalle)
                    .Where(w => w.UsuarioID == id)
                    .FirstOrDefault();
                //usuarios.TelefonoDetalle.Count();
            }
            catch (Exception)
            { throw; }
            //finally
            //{Dispose();}

            return usuarios;
        }
        public override bool Modificar(Usuarios entity)
        {
            bool paso = false;
            try
            {
                Usuarios Anterior = Buscar(entity.UsuarioID);
                foreach (var item in Anterior.TelefonoDetalle)
                {
                    if (entity.TelefonoDetalle.Exists(x => x.ID == item.ID))
                        _db.Entry(item).State = EntityState.Deleted;
                }
                foreach (var item in entity.TelefonoDetalle)
                {
                    var estado = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    _db.Entry(item).State = estado;
                }
                _db.Entry(entity).State = EntityState.Modified;
                paso = _db.SaveChanges() > 0;
            }
            catch (Exception)
            { throw; }
            //finally
            //{Dispose();}
            return paso;
        }
        public static bool ValidarUsuario(Usuarios user)
        {
            bool paso = true;

            RepositorioBase<Entidades.Usuarios> repositorio = new RepositorioBase<Entidades.Usuarios>();
            List<Entidades.Usuarios> usuario = new List<Entidades.Usuarios>();
            Expression<Func<Entidades.Usuarios, bool>> filtro = x => true;
            var username = user.UserName;
            filtro = x => x.UserName.Equals(username);
            usuario = repositorio.GetList(filtro);

            
            if (user.UsuarioID == 0)
            {
                if (usuario.Exists(x => username.Equals(username)))
                    paso = false;
            }
            else
            {
                if(user.UsuarioID!=0)
                {
                    Usuarios UsuarioComprobar = new RepositorioBase<Entidades.Usuarios>().Buscar(user.UsuarioID);
                    if (!UsuarioComprobar.UserName.Equals(user.UserName))
                    {
                        if (usuario.Exists(x => username.Equals(username)))
                            paso = false;
                    }
                }
                  
            }
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
