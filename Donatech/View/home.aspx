<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Main.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Donatech.View.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    Bienvenido(a): <%= ((Donatech.View.Shared.Main)this.Master).GetDatosUsuarioSession()?.Nombre %>

</asp:Content>
