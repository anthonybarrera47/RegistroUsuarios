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
                    if (user == null)
                        Alerta(2);
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
                Alerta(1);
                Limpiar();
            }
            else
                Alerta(2);
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
            repositorio.Dispose();
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
            user.TipoUsuario = GetTipoUsuario();
            return user;
        }
        private void LlenaCampos(Usuarios user)
        {
            IdTextBox.Text = user.UsuarioID.ToString();
            NombreTextBox.Text = user.Nombre;
            NombreUsuarioTextBox.Text = user.UserName;
            ClaveTextBox.Text = user.Password.SHA1();
            ClaveConfTextBox.Text = user.Password.SHA1();
            AdministradorRadioB.Checked = user.TipoUsuario.Equals("A") ? true : false;
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
        private bool ValidarClave()
        {
            if (!ClaveTextBox.Text.SHA1().Equals(ClaveConfTextBox.Text.SHA1()))
            {
                Alerta(4);
                return false;
            }  
            return true;
        }
        private string GetTipoUsuario()
        {
            string value;
            List<Tuple<RadioButton, HtmlGenericControl>> listRadio = new List<Tuple<RadioButton, HtmlGenericControl>>();
            listRadio.Add(new Tuple<RadioButton, HtmlGenericControl>(AdministradorRadioB, lb_AdministradorRadioButton));
            listRadio.Add(new Tuple<RadioButton, HtmlGenericControl>(UsuariosRadioButton, lbl_UsuariosRadioButton));

            foreach (Tuple<RadioButton, HtmlGenericControl> objPair in listRadio)
            {
                objPair.Item2.Attributes["class"] = "btn btn-default " + (objPair.Item1.Checked ? " active" : "");
                objPair.Item2.Attributes["onclick"] = "javascript:setTimeout('__doPostBack(\\'" + objPair.Item1.ClientID + "\\',\\'\\')', 0);";
            }
            value = AdministradorRadioB.Checked ? "A" :  "U";
            return value;
        }
        //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
    }
}