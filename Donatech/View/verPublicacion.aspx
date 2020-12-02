<%@ Page Title="Donatech - Publicacion" Language="C#" MasterPageFile="~/View/Shared/Main.Master" AutoEventWireup="true" CodeBehind="verPublicacion.aspx.cs" Async="true" Inherits="Donatech.View.verPublicacion" %>
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
            })
        }

        const volverAction = () => {
            history.back()
        }

        const aceptarDonacion = () => {
            return Confirm("Esta seguro que desea aceptar la donacion?")
        }

        initPage()

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initPage)
    </script>

    <div class="container">
        <div id="alertInfoMessage" class="alert alert-info" role="alert" style="display:none">
            &nbsp;
        </div>
        <div id="alertErrorMessage" class="alert alert-danger" role="alert" style="display:none">
            &nbsp;
        </div>

        <div class="card mb-3">
            <img id="imgProducto" class="card-img-top" alt="Card image cap" height="300" runat="server">
            <div class="card-body">
                <h5 class="card-title">
                    <asp:HiddenField ID="hdnIdProducto" runat="server" />
                    <asp:Literal ID="ltlTitulo" runat="server"></asp:Literal>
                </h5>
                <p class="card-text">
                    <asp:Literal ID="ltlDescripcion" runat="server"></asp:Literal>
                </p>
                <hr />
                <div class="form-row">
                    <div class="col-md-2">
                        <p><small class="text-muted">Estado: <asp:Literal ID="ltlEstado" runat="server"></asp:Literal></small></p>
                    </div>
                    <div class="col-md-6">
                        <small class="text-muted">Tipo: <asp:Literal ID="ltlTipoProducto" runat="server"></asp:Literal></small>
                    </div>
                    <div class="col-md-4">
                        <p><small class="text-muted">Ubicado en <asp:Literal ID="ltlComuna" runat="server"></asp:Literal></small></p>
                    </div>
                </div>
                <hr />
                <p class="form-row">
                    <small class="text-muted">Publicado el <asp:Literal ID="lblFechaPublicacion" runat="server"></asp:Literal></small>
                </p>
            </div>
        </div>
        <div class="form-group">
            <asp:Button ID="btnAceptarDonacion" CssClass="btn btn-info btn-block my-4" runat="server" OnClientClick="aceptarDonacion" 
                Text="Aceptar Donacion" OnClick="btnAceptarDonaction_Click" />
            <button class="btn btn-secondary btn-block my-4" name="btnCancelar" onclick="volverAction()">Volver</button>
        </div>
    </div>

</asp:Content>
