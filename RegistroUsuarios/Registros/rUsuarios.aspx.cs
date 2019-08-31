using System;
using RegistroUsuarios.Extensiones;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace RegistroUsuarios.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //si llego in id
                int id = (Request.QueryString["id"]).ToInt();
                if (id > 0)
                {
                    RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
                    Usuarios user = repositorio.Buscar(id);
                    if (user == null)
                        Alerta(2);
                    else
                        LlenaCampos(user);
                }
            }
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            bool paso = false;
            Usuarios user = LlenaClase();
            if (user.UsuarioID == 0)
                paso = db.Guardar(user);
            else
                paso = db.Modificar(user);
            if (paso)
            {
                //Extensores.MostrarMensaje(this, GetType(), "Popup", "succesalert()", true);
                Alerta(1);
                Limpiar();
            }
            else
            {
                //Extensores.MostrarMensaje(this, GetType(), "Popup", "erroralert()", true);

                Alerta(2);
            }
        }
        private void Alerta(int tipoError)
        {
            if (tipoError == 1)
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "successalert()", true);
            if (tipoError == 2)
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "erroralert()", true);
        }
        private Usuarios LlenaClase()
        {
            Usuarios user = new Usuarios();
            if (IdTextBox.Text.Equals(string.Empty))
                IdTextBox.Text = "0";
            user.UsuarioID = IdTextBox.Text.ToInt();
            user.Nombre = NombreTextBox.Text;
            return user;
        }
        private void LlenaCampos(Usuarios user)
        {
            IdTextBox.Text = user.UsuarioID.ToString();
            NombreTextBox.Text = user.Nombre;
        }
        //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
    }
}