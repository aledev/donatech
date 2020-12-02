using Donatech.Model;
using Donatech.Model.DbContext;
using Donatech.Utils;
using Donatech.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Donatech
{
    public class PublicacionController
    {
        private readonly ingresarPublicacion view;
        private DonatechEntities dbContext;

        public PublicacionController(ingresarPublicacion view)
        {
            this.view = view;
        }

        public async Task CargarListaTiposProducto()
        {
            try
            {
                using (dbContext = new DonatechEntities())
                {
                    var lstTiposProductoDb = await dbContext.TipoProducto.OrderBy(c => c.Descripcion).ToListAsync();
                    var lstTiposProducto = lstTiposProductoDb.Select(c => new Model.TipoProductoDto
                    {
                        Id = c.Id,
                        Descripcion = c.Descripcion
                    }).ToList();

                    view.ddlTipoProducto.DataSource = lstTiposProducto;
                    view.ddlTipoProducto.DataValueField = "Id";
                    view.ddlTipoProducto.DataTextField = "Descripcion";
                    view.ddlTipoProducto.DataBind();
                }
            }
            catch
            {
                var lstTiposProducto = new List<Model.TipoProductoDto>
                {
                    new Model.TipoProductoDto{ Id = 0, Descripcion = "[Error al cargar la lista]" }
                };

                view.ddlTipoProducto.DataSource = lstTiposProducto;
                view.ddlTipoProducto.DataValueField = "Id";
                view.ddlTipoProducto.DataTextField = "Descripcion";
                view.ddlTipoProducto.DataBind();
            }

            await Task.FromResult(0);
        }

        public async Task CargarListaEstadosProducto()
        {
            view.ddlEstadoProducto.DataSource = Constantes.ListaEstadoProductos;
            view.ddlEstadoProducto.DataBind();

            await Task.FromResult(0);
        }

        public async Task<(bool Result, string Message)> RegistrarPublicacion(ProductoDto producto)
        {
            try
            {
                using (dbContext = new DonatechEntities())
                {
                    dbContext.Producto.Add(new Model.DbContext.Producto
                    {
                        Descripcion = producto.Descripcion,
                        Estado = producto.Estado,
                        Titulo = producto.Titulo,
                        FchFinalizacion = null,
                        FchPublicacion = producto.FchPublicacion,
                        IdDemandante = null,
                        IdOferente = producto.IdOferente,
                        IdTipo = producto.IdTipo,
                        Imagen = producto.Imagen,
                        ImagenMimeType = producto.ImagenMimeType,
                        Enabled = true
                    });

                    var dbResult = await dbContext.SaveChangesAsync();
                    return dbResult > 0 ?
                        (true, "Publicacion ingresada correctamente") :
                        (false, "Error al intentar publicar el producto. Por favor, intentelo nuevamente");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error al intentar registrar la publicacion. Detalle: \"{ex.Message}\"");
            }
        }
    }
}