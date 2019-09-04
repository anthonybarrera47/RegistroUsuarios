using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto _db;
        public RepositorioBase()
        {
            _db = new Contexto();
        }
        public T Buscar(int id)
        {
            T entity;
            try
            {
                entity = _db.Set<T>().Find(id);
            }catch(Exception)
            { throw; }
            return entity;
        }
        public bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                T entity = _db.Set<T>().Find(id); ;
                _db.Set<T>().Remove(entity);
                paso = _db.SaveChanges() > 0;
            }catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();
            try
            {
                Lista = _db.Set<T>().Where(expression).ToList();
            }catch(Exception)
            { throw; }
            return Lista;
        }

        public virtual bool Guardar(T entity)
        {
            bool paso = false;
            try
            {
                if (_db.Set<T>().Add(entity) != null)
                    paso = _db.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;
            try
            {
                _db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                if (_db.SaveChanges() > 0)
                    paso = true;

            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }
        public bool ValidarUsuario(string NombreUsuario)
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
        public virtual void Dispose()
        {
            this._db.Dispose();
        }
    }
}
