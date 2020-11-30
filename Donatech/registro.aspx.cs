using Donatech.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donatech
{
    public partial class registroperfil : System.Web.UI.Page
    {
        private readonly RegistroController controller;

        public registroperfil()
        {
            controller = new RegistroController(this);
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    await controller.CargarListaComunas();
                    await controller.CargarListaTiposUsuario();
                }
            }
            catch(Exception ex)
            {
                ShowAlertMessage($"Ha ocurrido un error inesperado. Detalle: {ex.Message}");
            }
        }

        protected async void btnRegistrarme_Click(object sender, EventArgs e)
        {
            try
            {
                var validationResult = ValidateFields();
                if (!validationResult.Result)
                {
                    ShowAlertMessage($"Existen errores en la solicitud. Detalle: <br> {validationResult.Message}");
                    return;
                }

                var usuario = new Usuario();
                usuario.Nombre = this.txtNombre.Text.Trim();
                usuario.Apellidos = this.txtApellidos.Text.Trim();
                usuario.Direccion = this.txtDireccion.Text.Trim();
                usuario.Email = this.txtEmail.Text.Trim();
                usuario.IdComuna = int.Parse(this.ddlComuna.SelectedValue);
                usuario.IdRol = int.Parse(this.ddlTipoUsuario.SelectedValue);
                usuario.Password = this.txtPassword.Text.Trim();
                usuario.Run = this.txtRun.Text.Trim();
                usuario.Enabled = true;

                var result = await controller.RegistrarUsuario(usuario);
                if(result.Result)
                {
                    ShowInfoMessage(result.Message, ResolveUrl("~/login.aspx"));
                    return;
                }

                ShowAlertMessage(result.Message);
            }
            catch(Exception ex)
            {
                ShowAlertMessage($"Ha ocurrido un error inesperado. Detalle: {ex.Message}");
            }
        }

        private (bool Result, string Message) ValidateFields()
        {
            bool result = true;
            string validationError = "<ul>";

            if (!MethodUtils.ValidaRut(this.txtRun.Text.Trim()))
            {
                result = false;
                validationError += $"<li>Debe ingresar un rut valido.</li>";
            }
            if (!MethodUtils.ValidateEmail(this.txtEmail.Text.Trim()))
            {
                result = false;
                validationError += "<li>Debe ingresar un email valido.</li>";
            }
            if (string.IsNullOrEmpty(this.txtNombre.Text.Trim()))
            {
                result = false;
                validationError += "<li>Debe ingresar un nombre.</li>";
            }
            if (string.IsNullOrEmpty(this.txtApellidos.Text.Trim()))
            {
                result = false;
                validationError += "<li>Debe ingresar un apellido.</li>";
            }
            if (string.IsNullOrEmpty(this.txtDireccion.Text.Trim()))
            {
                result = false;
                validationError += "<li>Debe ingresar una direccion.</li>";
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {
                result = false;
                validationError += "<li>Debe ingresar un password.</li>";
            }
            if (string.IsNullOrEmpty(this.txtRePassword.Text.Trim()))
            {
                result = false;
                validationError += "<li>Debe confirmar el password.</li>";
            }
            if (!string.IsNullOrEmpty(this.txtPassword.Text.Trim()) &&
                !string.IsNullOrEmpty(this.txtRePassword.Text.Trim()))
            {
               if(this.txtRePassword.Text.Trim() != this.txtPassword.Text.Trim())
                {
                    result = false;
                    validationError += "<li>Los password son diferentes.</li>";
                }
            }

            validationError += "</ul>";

            return (result, validationError);
        }

        private void ShowInfoMessage(string message, string url)
        {
            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "showInfoMessage",
                $"showInfoMessage(\"{message}\", \"{url}\")",
                true);
        }

        private void ShowAlertMessage(string message)
        {
            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "showAlertMessage",
                $"showAlertMessage(\"{message}\")",
                true);
        }
        
    }
}