using Donatech.Controller;
using Donatech.Model;
using Donatech.Utils;
using Donatech.View.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donatech.View
{
    public partial class contacto : System.Web.UI.Page
    {
        private static ContactoController controller;

        public contacto()
        {
            contacto.controller = new ContactoController(this);
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    int idUsuario = int.Parse(Request.QueryString["idUsuario"] ?? "0");
                    int idProducto = int.Parse(Request.QueryString["idProducto"] ?? "0");

                    var infoContacto = await controller.ObtenerDatosContacto(idUsuario);
                    if(infoContacto.Result == null)
                    {
                        ((Main)this.Master).ShowAlertMessage(this,
                        Utils.AlertMessageTypeEnum.Danger,
                        infoContacto.Message);

                        return;
                    }

                    this.ltlNombre.Text = $"{infoContacto.Result.Nombre} {infoContacto.Result.Apellidos}";
                    this.ltlCelular.Text = infoContacto.Result.Celular;
                    this.ltlEmail.Text = infoContacto.Result.Email;
                    this.ltlDireccion.Text = infoContacto.Result.Direccion;

                    CargarMensajesChat();
                }
            }
            catch (Exception ex)
            {
                ((Main)this.Master).ShowModalMessage(this,
                    "Donatech - Error",
                    $"Ha ocurrido un error inesperado. Detalle: {ex.Message}");
            }
        }

        protected async void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                var mensaje = new MensajeDto();
                mensaje.FchEnvio = DateTime.Now;
                mensaje.IdEmisor = ((Main)this.Master).GetDatosUsuarioSession().Id;
                mensaje.IdReceptor = int.Parse(this.Request.QueryString["idUsuario"]);
                mensaje.IdProducto = int.Parse(this.Request.QueryString["idProducto"]);
                mensaje.Mensaje = this.txtMessage.Value.Trim();
                mensaje.Enabled = true;

                var result = await controller.InsertarMensaje(mensaje);

                if (result.Result)
                {
                    ((Main)this.Master).ShowAlertMessage(this,
                        AlertMessageTypeEnum.Info,
                        "Mensaje enviado correctamente");
                    CargarMensajesChat();
                    return;
                }

                ((Main)this.Master).ShowAlertMessage(this,
                        AlertMessageTypeEnum.Danger,
                        result.Message);
            }
            catch(Exception ex)
            {
                ((Main)this.Master).ShowModalMessage(this,
                    "Donatech - Error",
                    $"Ha ocurrido un error inesperado. Detalle: {ex.Message}");
            }
        }

        private async void CargarMensajesChat()
        {
            int idProducto = int.Parse(Request.QueryString["idProducto"] ?? "0");
            var chats = await controller.ObtenerMensajes(((Main)this.Master).GetDatosUsuarioSession().Id, idProducto);
            if (chats.Mensajes != null)
            {
                this.lstMensajes.DataSource = chats.Mensajes;
                this.lstMensajes.DataBind();
            }
        }

        [WebMethod]
        [ScriptMethod]
        public async static Task<string> ObtenerMensajes()
        {
            int idProducto = int.Parse(HttpContext.Current.Request.QueryString["idProducto"] ?? "0");
            var usuarioSesion = (UsuarioDto)HttpContext.Current.Session[Constantes.SESSION_USER];
            var mensajes = new List<MensajeDto>();
            var result = await controller.ObtenerMensajes(usuarioSesion.Id, idProducto);

            if(result.Mensajes != null)
            {
                mensajes = result.Mensajes;
            }

            return await Task.FromResult(JsonConvert.SerializeObject(mensajes));
        }

        [WebMethod]
        [ScriptMethod]
        public async static Task<string> InsertarMensajes(string jsonMensaje)
        {
            var mensaje = JsonConvert.DeserializeObject<MensajeDto>(jsonMensaje);
            int idProducto = int.Parse(HttpContext.Current.Request.QueryString["idProducto"] ?? "0");
            mensaje.IdProducto = idProducto;
            var result = await controller.InsertarMensaje(mensaje);

            return await Task.FromResult(JsonConvert.SerializeObject(result));
        }
    }
}