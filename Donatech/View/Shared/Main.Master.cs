using Donatech.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donatech.View.Shared
{
    public partial class Main : System.Web.UI.MasterPage
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validar que el usuario este loggeado
                if (this.GetDatosUsuarioSession() == null)
                {
                    this.CerrarSession();
                }
            }
        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            this.CerrarSession();
        }
        #endregion

        #region Metodos Privados
        private void CerrarSession()
        {
            // Cerramos sesion y retornamos al login
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
        #endregion

        #region Metodos Publicos
        public UsuarioDto GetDatosUsuarioSession()
        {
            if(Session[Constantes.SESSION_USER] != null)
            {
                return (UsuarioDto)Session[Constantes.SESSION_USER];
            }

            return null;
        }

        public void ShowModalMessage(Page page, string title, string message)
        {
            ScriptManager.RegisterStartupScript(
                page,
                page.GetType(),
                "showMessageDialog",
                $"showModalMessage(\"{title}\",\"{message.Replace("\"", "'")}\")",
                true);
        }

        public void ShowAlertMessage(Page page, AlertMessageTypeEnum type, string message, string url = "")
        {
            ScriptManager.RegisterStartupScript(
                page,
                page.GetType(),
                "showAlertMessage",
                $"showAlertMessage(\"{type}\", \"{message.Replace("\"", "'")}\", \"{url}\")",
                true);
        }
        #endregion
    }
}