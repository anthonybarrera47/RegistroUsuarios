using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using RegistroUsuarios.Extensiones;
using System.Web.UI.WebControls;
using Entidades;
using System.Linq.Expressions;
using BLL;

namespace RegistroUsuarios.Consultas
{
    public partial class cUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuarios, bool>> filtro = x => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();

            int id;
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0:
                    filtro = x => true;
                    break;
                case 1://ID
                    id = (FiltroTextBox.Text).ToInt();
                    filtro = x =>x.UsuarioID  == id;
                    break;
                case 2:// nombre
                    filtro = c => c.Nombre.Contains(FiltroTextBox.Text);
                    break;
            }
            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();
            repositorio.Dispose();
        }
    }
}