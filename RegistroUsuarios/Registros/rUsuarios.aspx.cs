using System;
using RegistroUsuarios.Extensiones;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;
using System.Linq.Expressions;
using System.Web.UI.HtmlControls;

namespace RegistroUsuarios.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Limpiar();
                int id = (Request.QueryString["id"]).ToInt();
                if (id > 0)
                {
                    RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
                    Usuarios user = repositorio.Buscar(id);
                    if (user.EsUsuarioNulo())
                        Alerta(TipoAlerta.ErrorAlert);
                    else
                        LlenaCampos(user);
                    repositorio.Dispose();
                }
                else
                {
                    Limpiar();
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
            NombreUsuarioTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
            ClaveConfTextBox.Text = string.Empty;
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (!ValidarClave())
                return;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            bool paso = false;
            Usuarios user = LlenaClase();
            try
            {

                if (user.UsuarioID == 0)
                {
                    if (!RepositorioUsuarios.ValidarUsuario(user.UserName))
                        return;
                    paso = repositorio.Guardar(user);
                }
                else
                {
                    Usuarios OldUser = repositorioBase.Buscar(user.UsuarioID);
                    if (OldUser.UserName.Equals(user.UserName))
                        paso = repositorio.Modificar(user);
                    else
                    {
                        if (!RepositorioUsuarios.ValidarUsuario(user.UserName))
                        {
                            Alerta(TipoAlerta.ErrorAlertUser);
                            return;
                        }
                        paso = repositorio.Modificar(user);
                    }
                }
                if (paso)
                {
                    Alerta(TipoAlerta.SuccessAlert);
                    Limpiar();
                }
                else
                    Alerta(TipoAlerta.ErrorAlert);
            }
            catch (Exception)
            { throw; }
            finally
            {
                repositorio.Dispose();
                repositorioBase.Dispose();
            }

        }
        private void Alerta(TipoAlerta tipoAlerta)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"{ tipoAlerta.ToString().ToLower()}()", true);
        }
        private Usuarios LlenaClase()
        {
            Usuarios user = new Usuarios();
            if (IdTextBox.Text.Equals(string.Empty))
                IdTextBox.Text = "0";
            user.UsuarioID = IdTextBox.Text.ToInt();
            user.Nombre = NombreTextBox.Text;
            user.UserName = NombreUsuarioTextBox.Text;
            user.Password = RepositorioUsuarios.SHA1(ClaveTextBox.Text);
            user.TipoUsuario = GetTipoUsuario();
            return user;
        }
        private void LlenaCampos(Usuarios user)
        {
            IdTextBox.Text = user.UsuarioID.ToString();
            NombreTextBox.Text = user.Nombre;
            NombreUsuarioTextBox.Text = user.UserName;
            ClaveTextBox.Text = RepositorioUsuarios.SHA1(user.Password);
            ClaveConfTextBox.Text = RepositorioUsuarios.SHA1(user.Password);
            AdministradorRadioB.Checked = user.TipoUsuario.Equals("A") ? true : false;
        }
        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            int id = ((IdTextBox.Text).isEmpty()) ? 0 : (IdTextBox.Text).ToInt();
            Usuarios user = repositorio.Buscar(id);
            if (user.EsUsuarioNulo())
                Alerta(TipoAlerta.ErrorAlert);
            else
            {
                repositorio.Eliminar(id);
                Alerta(TipoAlerta.SuccessAlert);
            }
            repositorio.Dispose();
        }
        private bool ValidarClave()
        {
            if (!RepositorioUsuarios.SHA1(ClaveTextBox.Text).Equals(RepositorioUsuarios.SHA1(ClaveConfTextBox.Text)))
            {
                Alerta(TipoAlerta.ErrorAlertClave);
                return false;
            }
            return true;
        }
        private string GetTipoUsuario()
        {
            return AdministradorRadioB.Checked ? "A" : "U"; ;
        }
        //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
    }
}