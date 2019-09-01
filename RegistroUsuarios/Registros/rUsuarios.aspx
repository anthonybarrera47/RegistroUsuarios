<%@ Page
    Title="Registro de Usuarios"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="rUsuarios.aspx.cs"
    Inherits="RegistroUsuarios.Registros.rUsuarios" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: "Exito!!",
                text: "Su registro ha sido guardado Exitosamente",
                icon: "success",
                button: "Continuar!",
            });
        }
    </script>
    <script type="text/javascript">
        function erroralert() {
            swal({
                title: "Fallo!",
                text: "Su registro no ha sido guardado",
                icon: "error",
                button: "Continuar!",
            });
        }
    </script>
    <script type="text/javascript">
        function erroralertuser() {
            swal({
                title: "Fallo!",
                text: "Usuario Ya existe en la base de datos",
                icon: "error",
                button: "Continuar!",
            });
        }
    </script>
    <script type="text/javascript">
        function erroralertclave() {
            swal({
                title: "Fallo!",
                text: "Contraseñas no coinciden",
                icon: "error",
                button: "Continuar!",
            });
        }
    </script>
    <div class="panel panel-primary">
        <div class="panel-heading">Registro de Usuarios</div>
        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">
                <%--UsuarioID--%>
                <div class="form-group">
                    <label for="IdTextBox" class="col-md-3 control-label input-sm">Id: </label>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:TextBox ID="IdTextBox" runat="server" ReadOnly="True" Text="0" class="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                <%--Nombre--%>
                <div class="form-group">
                    <label for="NombreTextBox" class="col-md-3 control-label input-sm">Nombre</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="NombreTextBox" placeHolder="Nombre" runat="server"
                            Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            runat="server" ID="RFVNombreTextBox"
                            ControlToValidate="NombreTextBox" ForeColor="Red"
                            ErrorMessage="Por favor llenar el campo Nombre!"
                            Display="Dynamic" SetFocusOnError="true"
                            ToolTip="Campo Nombre Obligatorio">

                        </asp:RequiredFieldValidator>

                    </div>
                </div>
                <%--Nombre de Usuario--%>
                <div class="form-group">
                    <label for="NombreUsuarioTextBox" class="col-md-3 control-label input-sm">Nombre de Usuario</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="NombreUsuarioTextBox" placeHolder="Nombre de usuarios" runat="server"
                            Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            runat="server" ID="RFVNombreUsuarioTextBox"
                            ControlToValidate="NombreUsuarioTextBox" ForeColor="Red"
                            ErrorMessage="Por favor llenar el campo Nombre de usuario!"
                            Display="Dynamic" SetFocusOnError="true"
                            ToolTip="Campo Nombre Usuario Obligatorio">

                        </asp:RequiredFieldValidator>
                    </div>
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </div>
                <%--Contraseña--%>
                <div class="form-group">
                    <label for="ClaveTextBox" class="col-md-3 control-label input-sm">Contraseña</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="ClaveTextBox" placeHolder="Nombre de usuarios" TextMode="Password" runat="server"
                            Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            runat="server" ID="RFVContrasenia"
                            ControlToValidate="ClaveTextBox" ForeColor="Red"
                            ErrorMessage="Por favor llenar el campo Contraseña!"
                            Display="Dynamic" SetFocusOnError="true"
                            ToolTip="Campo Contraseña Obligatorio">

                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--Confirmar Contraseña--%>
                <div class="form-group">
                    <label for="ClaveConfTextBox" class="col-md-3 control-label input-sm">Confirmar</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="ClaveConfTextBox" placeHolder="Nombre de usuarios" TextMode="Password" runat="server"
                            Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            runat="server" ID="RFVConfirmarContrasenia"
                            ControlToValidate="ClaveConfTextBox" ForeColor="Red"
                            ErrorMessage="Contraseña no coincide!"
                            Display="Dynamic" SetFocusOnError="true"
                            ToolTip="Contraseña no coincide">

                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="lb_AdministradorRadioButton" class="col-md-3 control-label input-sm ">Tipo de Usuario</label>
                    <div class="col-md-6">
                        <div class="btn-group" data-toggle="buttons">
                            <label runat="server" id="lb_AdministradorRadioButton" class="btn btn-default">
                                <asp:RadioButton runat="server" ID="AdministradorRadioB" GroupName="radioTipo"  AutoPostBack="True" />
                                Administrador
                           
                            </label>
                            <label runat="server" id="lbl_UsuariosRadioButton" class="btn btn-default">
                                <asp:RadioButton runat="server" ID="UsuariosRadioButton" GroupName="radioTipo" AutoPostBack="True" />
                                Usuario
                           
                            </label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuardarButton_Click" />
                <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
