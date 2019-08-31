<%@ Page
    Title="Registro de Usuarios"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="rUsuarios.aspx.cs"
    Inherits="RegistroUsuarios.Registros.rUsuarios" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
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
                        <asp:TextBox ID="NombreTextBox" runat="server"
                            Class="form-control input-sm"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RFVNombre" runat="server" MaxLength="200" 
                            ControlToValidate="NombreTextBox" 
                            ErrorMessage="Campo Nombre obligatorio" ForeColor="Red" 
                            Display="Dynamic" SetFocusOnError="True" 
                            ToolTip="Campo Nombre obligatorio">Por favor llenar el campo Nombre
                        </asp:RequiredFieldValidator>--%>
                    </div>
                </div>
                <div class="form-group">
                    <!-- RadioButton Tipousuario-->
                    <label for="AdministradorRadioButton" class="col-md-3 control-label input-sm">Nombre</label>
                    <div class="col-md-6">
                        <div class="form-check">
                            <input type="radio" class="form-check-input" id="AdministradorRadioButton" name="materialExampleRadios" checked>
                            <label class="form-check-label" for="AdministradorRadioButton">Administrador</label>
                            <input type="radio" class="form-check-input" id="UsuarioRadioButton" name="materialExampleRadios" checked>
                            <label class="form-check-label" for="UsuarioRadioButton">Usuario Normal</label>
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
                <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" />
            </div>
        </div>
    </div>
</asp:Content>
