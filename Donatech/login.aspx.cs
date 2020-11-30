using Donatech.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donatech
{

    public partial class login : System.Web.UI.Page
    {
        private readonly LoginController ctrLogin;

        public login()
        {
            ctrLogin = new LoginController(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            // Limpiando mensajes login
            lblMensajeLogin.Text = "";

            if (txtEmail.Text.Equals("") || txtPassword.Text.Equals(""))
            {
                lblMensajeLogin.Text = "Debe completar email y/o password para iniciar sesión";
                lblMensajeLogin.CssClass = "alert-danger";
                return;
            }

            // Validando formato ingresado de usuario y password
            if (!MethodUtils.ValidateEmail(txtEmail.Text.Trim()) || txtPassword.Text.Length < 6)
            {
                lblMensajeLogin.Text = "Nombre de usuario o password, no cumplen con el formato requerido para validar.\n"
                                       + "Email valido.\n"
                                       + "Password minimo 6 caracteres.";
                lblMensajeLogin.CssClass = "alert-danger";
                return;
            }

            string resultadoLogin = ctrLogin.ValidarUsuario(txtEmail.Text, txtPassword.Text);
            if (resultadoLogin != "" && (resultadoLogin.Contains("01OF") || resultadoLogin.Contains("01DE")))
            {
                // Redireccionando usuario a menu
                Response.Redirect("~/View/home.aspx");
                return;
            }

            lblMensajeLogin.Text = "Usuario no encontrado";
            lblMensajeLogin.CssClass = "alert-warning";
        }

        protected void lnkRecuperarPassword_Click(object sender, EventArgs e)
        {

            // Solicitar recuperar password

            Response.Redirect("~/recuperarpassword.aspx");

        }

        protected void lnkRegistrarse_Click(object sender, EventArgs e)
        {

            // Solicitar crear cuenta

            Response.Redirect("~/registro.aspx");

        }
    }
}