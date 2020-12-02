using Donatech.Model;
using Donatech.View.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donatech.View
{
    public partial class ingresarPublicacion : System.Web.UI.Page
    {
        private readonly PublicacionController controller;

        public ingresarPublicacion()
        {
            controller = new PublicacionController(this);
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    this.Form.Enctype = "multipart/form-data";
                    await controller.CargarListaEstadosProducto();
                    await controller.CargarListaTiposProducto();
                }
            }
            catch (Exception ex)
            {
                ((Main)this.Master).ShowModalMessage(this, 
                    "Donatech - Error", 
                    $"Ha ocurrido un error inesperado. Detalle: {ex.Message}");
            }
        }

        protected async void btnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] imageData = this.hdnImagenBase64.Value?.Split(new char[] { ',' }) ?? null;

                if(imageData == null)
                {
                    ((Main)this.Master).ShowAlertMessage(this,
                        Utils.AlertMessageTypeEnum.Danger,
                        "Debe ingresar una imagen referencial del producto.");
                    return;
                }

                var producto = new ProductoDto();
                producto.Titulo = txtTitulo.Text.Trim();
                producto.Descripcion = txtDescripcion.Text.Trim();
                producto.Estado = this.ddlEstadoProducto.SelectedValue;
                producto.FchPublicacion = DateTime.Now;
                producto.IdOferente = ((Main)this.Master).GetDatosUsuarioSession().Id;
                producto.IdDemandante = null;
                producto.IdTipo = int.Parse(this.ddlTipoProducto.SelectedValue);
                producto.Imagen = Convert.FromBase64String(imageData[1]);
                producto.ImagenMimeType = imageData[0];
                producto.Enabled = true;

                var result = await controller.RegistrarPublicacion(producto);
                if (result.Result)
                {
                    ((Main)this.Master).ShowAlertMessage(this,
                        Utils.AlertMessageTypeEnum.Info,
                        result.Message,
                        ResolveUrl("~/View/home.aspx"));
                    return;
                }

                ((Main)this.Master).ShowAlertMessage(this,
                        Utils.AlertMessageTypeEnum.Danger,
                        result.Message);
            }
            catch (Exception ex)
            {
                ((Main)this.Master).ShowModalMessage(this,
                   "Donatech - Error",
                   $"Ha ocurrido un error inesperado. Detalle: \"{ex.Message}\"");
            }
        }
    }
}