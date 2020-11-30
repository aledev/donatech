<%@ Page Title="" Language="C#" MasterPageFile="~/View/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ingresarPublicacion.aspx.cs" Inherits="Donatech.View.ingresarPublicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <script>
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgPreview').attr('src', e.target.result)
        }

        function readURL(input) {
            if (input.files && input.files[0]) {
                reader.readAsDataURL(input.files[0])
            }
        }

        $("#txtImagen").change(function () {
            readURL(this)
        })
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
                <label for="txtTitulo">Titulo</label>
                <asp:TextBox ID="txtTitulo" name="txtTitulo" CssClass="form-control" runat="server" MaxLength="30" ></asp:TextBox>
            </div>      
            <div class="form-group col-md-6">
                <label for="txtPassword">Imagen</label>
                <input type="file" id="txtImagen" name="txtImagen" runat="server" />
                <img class="mb-4" id="imgPreview" alt="" width="72" height="72">
            </div>
        </fieldset>

        <%--<div class="form-group col-md-6">
            <label for="txtRun">RUN</label>
            <asp:TextBox ID="txtRun" name="txtRun" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
            <small id="runHelp" class="form-text text-muted">Ingrese el password sin puntos y con guion (ej: 12345678-9).</small>
        </div>
        <div class="form-group col-md-6">
            <label for="txtNombre">Nombre</label>
            <asp:TextBox ID="txtNombre" name="txtNombre" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label for="txtApellidos">Apellidos</label>
            <asp:TextBox ID="txtApellidos" name="txtApellidos" runat="server" CssClass="form-control" MaxLength="80"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label for="txtDireccion">Direcci&oacute;n</label>
            <asp:TextBox ID="txtDireccion" name="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label for="ddlComuna">Comuna</label>
            <asp:DropDownList ID="ddlComuna" name="ddlComuna" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group col-md-6">
            <label for="ddlTipoUsuario">Tipo Usuario</label>
            <asp:DropDownList ID="ddlTipoUsuario" name="ddlTipoUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>--%>
        <div class="form-group col-md-6">
            <asp:Button ID="btnPublicar" CssClass="btn btn-info btn-block my-4" runat="server" Text="Publicar" OnClick="btnPublicar_Click" />
        </div>
    </div>

</asp:Content>
