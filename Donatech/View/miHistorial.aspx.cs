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
    public partial class miHistorial : System.Web.UI.Page
    {
        private readonly MiHistorialController controller;

        public miHistorial()
        {
            this.controller = new MiHistorialController(this);
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var result = await controller.CargarMisPublicaciones(((Main)this.Master).GetDatosUsuarioSession().Id);
                    if (!result.Result)
                    {
                        ((Main)this.Master).ShowAlertMessage(this,
                        Utils.AlertMessageTypeEnum.Danger,
                        result.Message);
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                ((Main)this.Master).ShowModalMessage(this,
                  "Donatech - Error",
                  $"Ha ocurrido un error inesperado. Detalle: {ex.Message}");
            }
        }
    }
}