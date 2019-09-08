using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLTests
{
    [TestClass()]
    public class TipoTelefonoTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
            TiposTelefono tipoTelefono = new TiposTelefono();
            RepositorioBase<TiposTelefono> db = new RepositorioBase<TiposTelefono>();
            tipoTelefono.Descripcion = "Celular";
            Assert.AreEqual(true, db.Guardar(tipoTelefono));
        }
    }
}
