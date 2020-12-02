using Donatech.Controller;
using Donatech.View.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donatech.View
{
    public partial class buscarPublicaciones : System.Web.UI.Page
    {
        private readonly BuscarPublicacionController controller;

        public buscarPublicaciones()
        {
            this.controller = new BuscarPublicacionController(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        protected async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string textoBusqueda = this.txtBusqueda.Text?.Trim()?.ToLower() ?? null;
                var result = await controller.BuscarListaPublicaciones(textoBusqueda);

                if (!result.Result)
                {
                    ((Main)this.Master).ShowAlertMessage(this,
                        Utils.AlertMessageTypeEnum.Danger,
                        result.Message);
                }
            }
            catch(Exception ex)
            {
                ((Main)this.Master).ShowModalMessage(this,
                   "Donatech - Error",
                   $"Ha ocurrido un error inesperado. Detalle: \"{ex.Message}\"");
            }
        }
    }
}