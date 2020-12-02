<%@ Page Title="Donatech - Ingresar Publicacion" Language="C#" MasterPageFile="~/View/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ingresarPublicacion.aspx.cs" Async="true" Inherits="Donatech.View.ingresarPublicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <script>
        const readURL = (input) => {
            if (input.files && input.files[0]) {
                var reader = new FileReader()
                reader.onload = (e) => {
                    $('#imgPreview').attr('src', e.target.result)
                    $('#<%= hdnImagenBase64.ClientID %>').val(e.target.result)
                }

                reader.readAsDataURL(input.files[0])
            }
        }

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

                $("#<%=txtImagen.ClientID%>").change(() => {
                    readURL(document.getElementById("<%=txtImagen.ClientID%>"))
                })
            })
        }

        const volverAction = () => {
            history.back()
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

        <fieldset>
            <legend>Ingresar Publicaci&oacute;n</legend>
            <div class="form-group col-md-6">
                <label for="txtTitulo">T&iacute;tulo</label>
                <asp:TextBox ID="txtTitulo" name="txtTitulo" CssClass="form-control" runat="server" MaxLength="30" required></asp:TextBox>
                <div class="invalid-feedback">
                  Debe ingresar un t&iacute;tulo.
                </div>
                <small id="titleHelp" class="form-text text-muted">M&aacute;ximo 30 caracteres.</small>
            </div>      
            <div class="form-group col-md-6">
                <div class="form-row">
                    <div class="col-md-6">
                        <label for="txtPassword">Imagen</label>
                        <input type="file" id="txtImagen" name="txtImagen" runat="server" class="form-control-file" />
                        <input type="hidden" id="hdnImagenBase64" runat="server">
                        <div class="invalid-feedback">
                          Debe ingresar un imagen.
                        </div>
                        <small id="imgHelp" class="form-text text-muted">Formatos aceptados .png, .jpg</small>
                    </div>
                    <div class="col-md-6">
                        <img class="mb-4 img-thumbnail" id="imgPreview" alt="Preview" width="150">
                    </div>
                </div>
            </div>
        </fieldset>

        <div class="form-group col-md-6">
            <label for="ddlTipoProducto">Tipo Producto</label>
            <asp:DropDownList ID="ddlTipoProducto" name="ddlTipoProducto" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group col-md-6">
            <label for="ddlEstadoProducto">Estado Producto</label>
            <asp:DropDownList ID="ddlEstadoProducto" name="ddlEstadoProducto" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group col-md-6">
            <label for="txtDescripcion">Descripci&oacute;n</label>
            <asp:TextBox ID="txtDescripcion" name="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" MaxLength="300" ></asp:TextBox>
            <div class="invalid-feedback">
                Debe ingresar una descripci&oacute;n
            </div>
            <small id="descHelp" class="form-text text-muted">Ingrese una descripci&oacute;n de m&aacute;ximo 300 caracteres.</small>
        </div>

        <div class="form-group col-md-6">
            <asp:Button ID="btnPublicar" CssClass="btn btn-info btn-block my-4" runat="server" Text="Publicar" OnClick="btnPublicar_Click" />
            <button class="btn btn-secondary btn-block my-4" name="btnCancelar" onclick="volverAction()">Cancelar</button>
        </div>
    </div>

</asp:Content>
