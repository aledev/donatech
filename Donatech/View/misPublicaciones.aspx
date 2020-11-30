<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Main.Master" AutoEventWireup="true" CodeBehind="misPublicaciones.aspx.cs" Inherits="Donatech.View.misPublicaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <asp:Repeater ID="lstUsuarios" runat="server">
        <HeaderTemplate>
            <div class="card-deck">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="card">
                <img src='<%# Eval("Imagen") %>' class="card-img-top" alt='<%# Eval("Estado") %>'>
                <div class="card-body">
                    <h5 class="card-title"><%# Eval("Titulo") %></h5>
                    <p class="card-text"><%# Eval("Descripcion") %></p>
                    <p class="card-text"><small class="text-info"><%# Eval("Estado") %></small></p>
                    <p class="card-text"><small class="text-muted">Publicado el <%# Eval("FchPublicacion") %></small></p>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            <asp:Label ID="lblEmptyData" runat="server" Visible='<%# ((Repeater)Container.NamingContainer).Items.Count == 0 %>' Text="No tienes publicaciones registradas." />
            </div>
        </FooterTemplate>
    </asp:Repeater>  

</asp:Content>
