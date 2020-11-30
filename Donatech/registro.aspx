<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Donatech.registroperfil" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">

        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <title>Donatech :: Registro Usuario</title>
        <link rel="icon" type="image/png" href="img/logo1.png">
        <link href="css/estilos.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
        
    </head>
    <body>
        <form id="frmLoginSistema" runat="server">
            <asp:ScriptManager ID="scriptManagerLogin" runat="server">
                <Scripts>
                    <asp:ScriptReference Path="https://code.jquery.com/jquery-3.5.1.slim.min.js" />
                    <asp:ScriptReference Path="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" />
                </Scripts>
            </asp:ScriptManager>
            <!-- Custom Scripts -->
            <script>
                const showAlertMessage = (body) => {
                    $("#alertErrorMessage").html(body)
                    $("#alertErrorMessage").show()
                }

                const showInfoMessage = (body, url) => {
                    $("#alertInfoMessage").html(body)
                    $("#alertInfoMessage").show()
                    setTimeout(() => {
                        document.location.href = url
                    }, 3000)
                }
            </script>

            <asp:UpdatePanel ChildrenAsTriggers="true" ID="updLogin" runat="server">
                <ContentTemplate>
                    <div class="container">

                    <div id="alertInfoMessage" class="alert alert-info" role="alert" style="display:none">
                        &nbsp;
                    </div>
                    <div id="alertErrorMessage" class="alert alert-danger" role="alert" style="display:none">
                        &nbsp;
                    </div>

                    <fieldset>
                        <legend>Datos Usuario</legend>
                        <div class="form-group col-md-6">
                            <label for="txtEmail">Email</label>
                            <asp:TextBox ID="txtEmail" name="txtEmail" CssClass="form-control" runat="server" placeholder="Email" ></asp:TextBox>
                        </div>      
                        <div class="form-group col-md-6">
                            <label for="txtPassword">Password</label>
                            <asp:TextBox ID="txtPassword" name="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtRePassword">Confirmar Password</label>
                            <asp:TextBox ID="txtRePassword" name="txtRePassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirmar Password"></asp:TextBox>
                            <small id="passHelp" class="form-text text-muted">Los passwords deben coincidir.</small>
                        </div>
                    </fieldset>

                    <div class="form-group col-md-6">
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
                    </div>
                    <div class="form-group col-md-6">
                        <asp:Button ID="btnRegistrarme" CssClass="btn btn-info btn-block my-4" runat="server" Text="Registrarme" OnClick="btnRegistrarme_Click" />
                    </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
    </body>
</html>
