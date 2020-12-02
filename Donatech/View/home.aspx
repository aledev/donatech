<%@ Page Title="Donatech - Home" Language="C#" MasterPageFile="~/View/Shared/Main.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Donatech.View.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .card-img-top {
            width: 100%;
            height: 15vw;
            object-fit: cover;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    
    <div class="container">
        <h5>Bienvenido(a): <%= ((Donatech.View.Shared.Main)this.Master).GetDatosUsuarioSession()?.Nombre %></h5>

        <div class="card mb-3">
          <img class="card-img-top" src='<%=ResolveUrl("~/img/donation.jpg") %>' alt="Donatech Goal">
          <div class="card-body">
            <h5 class="card-title">Donatech - Nuestra Mision</h5>

            <p class="card-text">La pandemia y la crisis económica ha desnudado nuestra sociedad. Muchas personas se han visto obligados a teletrabajar o 
                estudiar de manera telemática, sin tener el soporte tecnológico o los recursos adecuados.</p>
            <p class="card-text">Por otro lado, cada año se lanzan  a la basura muchos dispositivos tecnológicos de los cuales se les puede dar una segunda vida.</p>
            <p class="card-text">De la conjunción de ambas realidades, nace el proyecto colaborativo y sin fines de lucro Donatech, el cual busca dar una segunda 
                vida artefactos tecnológicos, disminuir la basura tecnológica y ayudar a los hogares con las necesidades tecnológicas, en donde 
                con motivo de la pandemia los recursos económicos son cada vez más escasos.</p>

            <p class="card-text"><small class="text-muted">“De nada sirve al hombre lamentarse de los tiempos en que vive. Lo único bueno que puede 
                hacer es intentar mejorarlos.” - Thomas Carlyle</small></p>
          </div>
        </div>
    </div>

</asp:Content>
