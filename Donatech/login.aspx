﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Donatech.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">

        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <title>Donatech :: Login</title>
        <link rel="icon" type="image/png" href="img/logo1.png">
        <link href="css/estilos.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
        <style>
            .donatech-login {
              width: 100%;
              max-width: 330px;
              padding: 15px;
              margin: auto;
            }
        </style>
    </head>
    <body>

        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>        

        <form id="frmLoginSistema" runat="server">
            <asp:ScriptManager ID="scriptManagerLogin" runat="server">
                <Scripts>
                    <asp:ScriptReference Path="https://code.jquery.com/jquery-3.5.1.slim.min.js" />
                    <asp:ScriptReference Path="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" />
                </Scripts>
            </asp:ScriptManager>

            <asp:UpdatePanel ChildrenAsTriggers="true" ID="updLogin" runat="server">
                <ContentTemplate>
                    <div class="container text-center mb-4">
                        <div class="donatech-login">

                            <div class="col" style="text-align:center">
                                <asp:Label ID="lblMensajeLogin" runat="server" Text=""></asp:Label>
                            </div>
                       
                            <img class="mb-4" src="img/donatech.png" alt="" width="72" height="72">

                            <p class="h4 mb-4">Donatech - Login</p>
                        
                            <asp:TextBox ID="txtEmail" CssClass="form-control mb-4" runat="server" placeholder="Email"></asp:TextBox>
  
                            <asp:TextBox ID="txtPassword" CssClass="form-control mb-4" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>

                            <asp:Button ID="cmdLogin" CssClass="btn btn-info btn-block my-4" runat="server" Text="Iniciar Sesión" OnClick="cmdLogin_Click" />
                        
                            <div class="row">
                                <div class="col">
                                    <asp:LinkButton ID="lnkRecuperarPassword" runat="server" OnClick="lnkRecuperarPassword_Click">¿Olvido su password?</asp:LinkButton>
                                </div>
                            </div>
                            <br />
                            <div>
                                <div class="col">
                                    <asp:LinkButton ID="lnkRegistrarse" runat="server" OnClick="lnkRegistrarse_Click">Registrarse</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
    </body>
</html>
