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

namespace RegistroUsuarios.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Limpiar();
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
                    repositorio.Dispose();
                }
                else
                {
                    NuevoButton_Click(null, null);
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
            UsuarioRadioButton.Checked = true;
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (!ValidarClave())
                return;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            bool paso = false;
            Usuarios user = LlenaClase();

            if (user.UsuarioID == 0)
            {
                if (!ValidarUsuario())
                    return;
                paso = repositorio.Guardar(user);
            }
            else
            {
                RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
                Usuarios OldUser = repositorioBase.Buscar(user.UsuarioID);
                if (OldUser.UserName.Equals(user.UserName))
                    paso = repositorio.Modificar(user);
                else
                {
                    if (!ValidarUsuario())
                        return;
                    paso = repositorio.Modificar(user);
                }
                repositorioBase.Dispose();
            }
                
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
            repositorio.Dispose();
        }
        public bool ValidarUsuario()
        {
            bool paso = true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> usuario = new List<Usuarios>();
            Expression<Func<Usuarios, bool>> filtro = x => true;
            var username = NombreUsuarioTextBox.Text;
            filtro = x => x.UserName.Equals(username);
            usuario = repositorio.GetList(filtro);
            if (usuario.Exists(x => username.Equals(username)))
            {
                Alerta(3);
                paso = false;
            }
            return paso;
        }
        private void Alerta(int tipoError)
        {
            if (tipoError == 1)
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "successalert()", true);
            if (tipoError == 2)
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "erroralert()", true);
            if (tipoError == 3)
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "erroralertuser()", true);
            if (tipoError == 4)
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "erroralertclave()", true);
        }
        private Usuarios LlenaClase()
        {
            Usuarios user = new Usuarios();
            if (IdTextBox.Text.Equals(string.Empty))
                IdTextBox.Text = "0";
            user.UsuarioID = IdTextBox.Text.ToInt();
            user.Nombre = NombreTextBox.Text;
            user.UserName = NombreUsuarioTextBox.Text;
            user.Password = ClaveTextBox.Text.SHA1();
            user.TipoUsuario = AdministradorRadioButton.Checked ? "A" : "U";
            return user;
        }
        private void LlenaCampos(Usuarios user)
        {
            IdTextBox.Text = user.UsuarioID.ToString();
            NombreTextBox.Text = user.Nombre;
            NombreUsuarioTextBox.Text = user.UserName;
            ClaveTextBox.Text = user.Password.SHA1();
            ClaveConfTextBox.Text = user.Password.SHA1();
            AdministradorRadioButton.Checked = user.TipoUsuario.Equals("A") ? true : false;
        }
        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            int id = (IdTextBox.Text).ToInt();

            Usuarios user = repositorio.Buscar(id);

            if (user == null)
                Alerta(2);
            else
            {
                repositorio.Eliminar(id);
                Alerta(1);
            }

            repositorio.Dispose();
        }

        public static string CheckEmail(string NombreUsuario)
        {
            String value = string.Empty;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> ListaUsuarios = repositorio.GetList(x => x.UserName.Equals(NombreUsuario));
            if (ListaUsuarios.Count > 0)
            {
                value = "true";
            }
            else
            {
                value = "false";
            }

            return value;
        }
        private bool ValidarClave()
        {
            if (!ClaveTextBox.Text.SHA1().Equals(ClaveConfTextBox.Text.SHA1()))
            {
                Alerta(4);
                return false;
            }
                
            return true;
        }
        protected void NombreUsuarioTextChanged(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ExisteUsuario", "ExisteUsuario()", true);
        }
        //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
    }
}