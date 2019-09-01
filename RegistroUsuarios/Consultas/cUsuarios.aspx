<%@ Page
    Title=""
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="cUsuarios.aspx.cs"
    Inherits="RegistroUsuarios.Consultas.cUsuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Consulta de Usuarios</div>
        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">
                <div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="BuscarPorDropDownList" runat="server" CssClass="form-control input-sm">
                            <asp:ListItem>Todos</asp:ListItem>
                            <asp:ListItem>UsuariosID</asp:ListItem>
                            <asp:ListItem>Nombre</asp:ListItem>
                            <asp:ListItem>Nombre de Usuario</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="FiltroTextBox" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Button ID="BuscarButton" runat="server" Class="btn btn-success input-sm" Text="Buscar" OnClick="BuscarButton_Click" />
                    </div>
                </div>
                <%--GRID--%>
                <div class="col-md-12">
                    <div class="table table-condensed table-bordered table-responsive">
                        <asp:GridView ID="DatosGridView"
                            runat="server"
                            CssClass="table table-condensed table-bordered table-responsive"
                            CellPadding="4" ForeColor="#333333" GridLines="None">

                            <AlternatingRowStyle BackColor="LightBlue" />

                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:HyperLinkField ControlStyle-ForeColor="blue"
                                    DataNavigateUrlFields="UsuarioID"
                                    DataNavigateUrlFormatString="~/Registros/rUsuarios.aspx?Id={0}"
                                    Text="Editar"></asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
