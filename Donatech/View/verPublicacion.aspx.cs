using Donatech.Controller;
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
    public partial class verPublicacion : System.Web.UI.Page
    {
        private readonly VerPublicacionController controller;

        public verPublicacion()
        {
            controller = new VerPublicacionController(this);
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int idProducto = int.Parse(Request.QueryString["id"] ?? "0");
                    var result = await controller.ObtenerPublicacion(idProducto);

                    if(result.Producto != null)
                    {
                        this.ltlTitulo.Text = result.Producto.Titulo;
                        this.ltlTipoProducto.Text = result.Producto.TipoProducto.Descripcion;
                        this.ltlEstado.Text = result.Producto.Estado;
                        this.ltlDescripcion.Text = result.Producto.Descripcion;
                        this.ltlComuna.Text = result.Producto.Oferente.Comuna.Nombre;
                        this.hdnIdProducto.Value = result.Producto.Id.ToString();
                        this.lblFechaPublicacion.Text = result.Producto.FchPublicacion.ToString();
                        this.imgProducto.Src = result.Producto.ImagenBase64;
                    }
                }
            }
            catch (Exception ex)
            {
                ((Main)this.Master).ShowModalMessage(this, 
                    "Donatech - Error", 
                    $"Ha ocurrido un error inesperado. Detalle: {ex.Message}");
            }
        }

        protected async void btnAceptarDonaction_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoDto producto = new ProductoDto();
                producto.Id = int.Parse(this.hdnIdProducto.Value);
                producto.IdDemandante = ((Main)this.Master).GetDatosUsuarioSession().Id;
                producto.FchFinalizacion = DateTime.Now;

                var result = await controller.AceptarDonacion(producto);
                if (result.Result != null)
                {
                    ((Main)this.Master).ShowAlertMessage(this,
                        Utils.AlertMessageTypeEnum.Info,
                        result.Message);

                    ((Main)this.Master).ShowModalMessage(this,
                        "Donatech - Donacion aceptada",
                        $"<p><h4>Datos de Contacto</h4></p>" +
                        $"<p><h5>{result.Result.Nombre} {result.Result.Apellidos}</h5></p>" + 
                        $"<p><span class='text-muted'>Celular: {result.Result.Celular}</span></p>" +
                        $"<p><span class='text-muted'>Email: {result.Result.Email}</span></p>" +
                        $"<p><span class='text-muted'>Direccion: {result.Result.Direccion}, {result.Result.Comuna.Nombre}</span></p>");
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