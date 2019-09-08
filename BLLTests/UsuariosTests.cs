using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL.Tests
{
    [TestClass()]
    public class UsuariosTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Usuarios user = new Usuarios();
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            user.Nombre = "Anthony";
            user.TelefonoDetalle.Add(new TelefonoDetalle(0,"829-935-9510",1,1));
            Assert.AreEqual(true, db.Guardar(user));
        }
        [TestMethod()]
        public void ModificarTest()
        {
            Usuarios user = new Usuarios();
            RepositorioUsuarios db = new RepositorioUsuarios();
            user.UsuarioID = 1;
            user.Nombre = "Anthony Barrera";
            user.TelefonoDetalle.Add(new TelefonoDetalle(0, "829-935-9510", 1, 1));
            Assert.AreEqual(true, db.Modificar(user));
        }
        [TestMethod()]
        public void BuscarTest()
        {
            Usuarios user = new Usuarios();
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            user.UsuarioID = 1;
            Usuarios us = db.Buscar(user.UsuarioID);
            Assert.AreEqual(true,us is null ? false : true );
        }
        [TestMethod()]
        public void GetListTest()
        {
            List<Usuarios> user = new List<Usuarios>();
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            user = db.GetList(x => true);
            Assert.AreEqual(true, user.Count>0 ?true : false );
        }
        [TestMethod()]
        public void EliminarTest()
        {
            Usuarios user = new Usuarios();
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            user.UsuarioID = 1;
            Assert.AreEqual(true, db.Eliminar(user.UsuarioID));
        }
    }
}