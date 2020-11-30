using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donatech.View
{
    public partial class frmAdminUsuarios : System.Web.UI.Page
    {
        private readonly AdministradorController controller;

        public frmAdminUsuarios()
        {
            this.controller = new AdministradorController(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                controller.CargarListaUsuarios();
            }
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string rut = this.txtRutUsuario.Text;
            string nombre = this.txtNombreUsuario.Text;
            string apellido = this.txtApellidoUsuario.Text;
            string username = this.txtUsername.Text;

            controller.AgregarUsuario(rut, nombre, apellido, username);
            controller.CargarListaUsuarios();
        }
    }
}