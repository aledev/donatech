<%@ Page Title="Donatech - Buscar" Language="C#" MasterPageFile="~/View/Shared/Main.Master" AutoEventWireup="true" Async="true"  CodeBehind="buscarPublicaciones.aspx.cs" Inherits="Donatech.View.buscarPublicaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .product-row:hover {
            background-color: #cfd9df;
            cursor: pointer;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <script>
        const initPage = () => {
            $(document).ready(() => {
                window.addEventListener('load', () => {
                    // Fetch all the forms we want to apply custom Bootstrap validation styles to
                    var forms = document.getElementsByClassName('needs-validation')
                    // Loop over them and prevent submission
                    var validation = Array.prototype.filter.call(forms, (form) => {
                        form.addEventListener('submit', (event) => {
                            if (form.checkValidity() === false) {
                                event.preventDefault()
                                event.stopPropagation()
                            }
                            form.classList.add('was-validated');
                        }, false)
                    })
                }, false)

                addProductRowEvents()
            })
        }

        const addProductRowEvents = () => {
            $(".product-row").click((item) => {
                console.log(item.currentTarget)
                let productId = $(item.currentTarget).find("#hdnProductId").first().val()
                let detailUrl = '<%=ResolveUrl("~/View/verPublicacion.aspx?id=productId")%>'
                detailUrl = detailUrl.replace("productId", productId)

                location.href = detailUrl
            })
        }

        initPage()

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initPage)
    </script>

    <div class="container">
        <fieldset>
            <legend>Lista Publicaciones</legend>
    
            <div class="form-group">
                <div class="form-row">
                    <asp:TextBox ID="txtBusqueda" name="txtBusqueda" CssClass="form-control" runat="server" placeholder="Buscar productos"></asp:TextBox>
                    <small id="passHelp" class="form-text text-muted">Buscar productos por t&iacute;tulo, descripci&oacute;n o tipo (Ej: Perro, Gato, Celular).</small> 
                </div>
                <div class="form-row">
                    <asp:Button ID="btnBuscar" CssClass="btn btn-info btn-block my-4" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
            <hr />
            <div class="form-group">
                <asp:Repeater ID="lstPublicaciones" runat="server">
                    <ItemTemplate>
                        <div class="form-row product-row">
                            <div class="media">
                                <input type="hidden" id="hdnProductId" value='<%# Eval("Id") %>'' />
                                <img src='<%# Eval("ImagenBase64") %>' class="align-self-center mr-3 rounded" width="200" alt='<%# Eval("Titulo") %>'>
                                <div class="media-body">
                                    <h5 class="mt-0"><%# Eval("Titulo") %></h5>
                                    <p class="text-body"><%# Eval("Descripcion") %></p>
                                    <div class="form-row">
                                        <div class="col-md-2">
                                            <p><small class="text-muted">Estado: <%# Eval("Estado") %></small></p>
                                        </div>
                                        <div class="col-md-6">
                                            <small class="text-info">Tipo: <%# Eval("TipoProducto.Descripcion") %></small>
                                        </div>
                                        <div class="col-md-4">
                                            <p><small class="text-muted">Ubicado en <%# Eval("Oferente.Comuna.Nombre") %></small></p>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="col-md-8">
                                            <p>
                                                <small class='<%# Eval("IdDemandante") == null ? "badge badge-success" : "badge badge-warning" %>'>
                                                    <%# Eval("IdDemandante") == null ? "Disponible" : "No Disponible" %>
                                                </small> 
                                            </p>
                                        </div>
                                        <div class="col-md-4">
                                            <small class="text-muted">Publicado el <%# Eval("FchPublicacion") %></small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblEmptyData" runat="server" Visible='<%# ((Repeater)Container.NamingContainer).Items.Count == 0 %>' Text="No tienes publicaciones registradas." />
                    </FooterTemplate>
                </asp:Repeater>  
            </div>
        </fieldset>
    </div>

</asp:Content>
