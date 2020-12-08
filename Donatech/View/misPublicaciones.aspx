<%@ Page Title="Donatech - Mis Publicaciones" Language="C#" MasterPageFile="~/View/Shared/Main.Master" AutoEventWireup="true" Async="true" CodeBehind="misPublicaciones.aspx.cs" Inherits="Donatech.View.misPublicaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .card-img-top {
            width: 100%;
            height: 15vw;
            object-fit: cover;
        }

        .row {
           display: flex;
           flex-wrap: wrap;
        }

        .row > div[class*='col-'] {
          display: flex;
        }

        .card-deck {
            margin-bottom: 15px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <div class="container">
        <fieldset>
            <legend>Mis publicaciones</legend>
    
            <div class="row col-md-9">
                <asp:Repeater ID="lstPublicaciones" runat="server">
                    <ItemTemplate>
                        <%# Eval("CardDeckHeaderHtml") %>
                        <div class="card">
                            <img src='<%# Eval("ImagenBase64") %>' class="card-img-top" alt='<%# Eval("Titulo") %>'>
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Titulo") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <p class="card-text"><small class="text-info">Estado: <%# Eval("Estado") %></small></p>
                                <p class="card-text">
                                    <small class='<%# Eval("IdDemandante") == null ? "badge badge-success" : "badge badge-warning" %>'>
                                        <%# Eval("IdDemandante") == null ? "Disponible" : "No Disponible" %>
                                    </small> 
                                </p>
                                <p class="card-text"><small class="text-muted">Publicado el <%# Eval("FchPublicacion") %></small></p>
                                <p class="card-text" style='<%# Eval("IdDemandante") == null ? "display:none" : "" %>'>
                                    <a class="badge badge-info" href='<%# Eval("UrlContacto") %>'>Ver info de contacto</a>
                                </p>
                            </div>
                        </div>
                        <%# Eval("CardDeckFooterHtml") %>
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="card" style='<%# ((Repeater)Container.NamingContainer).Items.Count > 0 ? "display:none" : "" %>'>
                            <div class="card-body">
                                <p class="card-text">
                                    No tienes publicaciones registradas.
                                </p>
                            </div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>  
            </div>
        </fieldset>
    </div>

</asp:Content>
