<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Main.Master" AutoEventWireup="true" CodeBehind="frmAdminUsuarios.aspx.cs" Inherits="Donatech.View.frmAdminUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <fieldset>
        <legend>Lista de Usuarios</legend>
        <asp:Repeater ID="lstUsuarios" runat="server">
            <HeaderTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th>Rut</th>
                            <th>Nombre</th>
                            <th>Apellido</th>
                            <th>Username</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("RutUsuario") %></td>
                    <td><%# Eval("PrimerNombreUsuario") %></td>
                    <td><%# Eval("ApellidoPaternoUsuario") %></td>
                    <td><%# Eval("UserNameUsuario") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </fieldset>

    <br />

    <fieldset>
        <legend>Agregar Usuario</legend>

        <div class="form-group">
            <label for="txtRutUsuario">Rut</label>
            <asp:TextBox ID="txtRutUsuario" runat="server" CssClass="form-control" name="txtRutUsuario"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtNombreUsuario">Nombre</label>
            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" name="txtNombreUsuario"></asp:TextBox>
        </div> 
        <div class="form-group">
            <label for="txtApellidoUsuario">Apellido</label>
            <asp:TextBox ID="txtApellidoUsuario" runat="server" CssClass="form-control" name="txtApellidoUsuario"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtUsername">Username</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" name="txtUsername"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregarUsuario_Click" />
        </div>
    </fieldset>
    
</asp:Content>
