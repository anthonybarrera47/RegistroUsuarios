using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using RegistroUsuarios.Extensiones;
using System.Web.UI.WebControls;
using Entidades;
using System.Linq.Expressions;

namespace RegistroUsuarios.Consultas
{
    public partial class cUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            //Inicializando el filtro en True
            Expression<Func<Usuarios, bool>> filtro = x => true;
            BLL.RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();

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
        }
    }
}