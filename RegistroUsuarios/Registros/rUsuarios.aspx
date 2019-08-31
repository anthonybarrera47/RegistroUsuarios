<%@ Page
    Title="Registro de Usuarios"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="rUsuarios.aspx.cs"
    Inherits="RegistroUsuarios.Registros.rUsuarios" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <%--UsuarioID--%>
    <div class="form-group">
        <label for="IdTextBox" class="col-md-3 control-label input-sm">Id: </label>
        <div class="col-md-1 col-sm-2 col-xs-4">
            <asp:TextBox ID="IdTextBox" runat="server" ReadOnly="True" placeholder="0" class="form-control input-sm"></asp:TextBox>
        </div>
    </div>

</asp:Content>
