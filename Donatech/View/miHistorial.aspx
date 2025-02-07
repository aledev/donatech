﻿<%@ Page Title="Donatech - Mi Historial" Language="C#" MasterPageFile="~/View/Shared/Main.Master" AutoEventWireup="true" Async="true" CodeBehind="miHistorial.aspx.cs" Inherits="Donatech.View.miHistorial" %>
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
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <div class="container">
        <fieldset>
            <legend>Mi Historial</legend>
    
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
                                <p class="card-text"><small class="text-muted">Donacion aceptada el <%# Eval("FchFinalizacion") %></small></p>
                                <p class="card-text">
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
                                    No tienes historial registrado.
                                </p>
                            </div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>  
            </div>
        </fieldset>
    </div>

</asp:Content>
