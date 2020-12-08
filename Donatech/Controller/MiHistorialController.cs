using Donatech.Model;
using Donatech.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Donatech.Controller
{
    public class MiHistorialController
    {
        private readonly miHistorial view;
        private Model.DbContext.DonatechEntities dbContext;

        public MiHistorialController(miHistorial view)
        {
            this.view = view;
        }

        public async Task<(bool Result, string Message)> CargarMisPublicaciones(int idDemandante)
        {
            try
            {
                List<ProductoDto> publicacionesList = new List<ProductoDto>();

                using(dbContext = new Model.DbContext.DonatechEntities())
                {
                    publicacionesList = await dbContext.Producto.Where(p => p.IdDemandante == idDemandante).Select(p => 
                    new ProductoDto {
                        Id = p.Id,
                        Descripcion = p.Descripcion,
                        Estado = p.Estado,
                        FchFinalizacion = p.FchFinalizacion,
                        FchPublicacion = p.FchPublicacion,
                        IdOferente = p.IdOferente,
                        IdDemandante = p.IdDemandante,
                        Imagen = p.Imagen,
                        ImagenMimeType = p.ImagenMimeType,
                        IdTipo = p.IdTipo,
                        Titulo = p.Titulo,
                        Enabled = p.Enabled
                    }).ToListAsync();
                }

                int index = 0;
                foreach (var item in publicacionesList)
                {
                    item.ImagenBase64 = $"{item.ImagenMimeType},{Convert.ToBase64String(item.Imagen)}";
                    item.Imagen = null;
                    item.ImagenMimeType = null;
                    item.UrlContacto = $"{VirtualPathUtility.ToAbsolute("~/View/contacto.aspx")}?idProducto={item.Id}&idUsuario={item.IdOferente}";
                    item.Index = index;
                    item.CardDeckHeaderHtml = index == 0 || index % 3 == 0 ? "<div class=\"card-deck\">" : "";
                    item.CardDeckFooterHtml = ((index + 1) % 3 == 0) || (index + 1 == publicacionesList.Count) ? "</div>" : "";
                    index++;
                }

                this.view.lstPublicaciones.DataSource = publicacionesList;
                this.view.DataBind();

                return (true, string.Empty);
            }
            catch(Exception ex)
            {
                return (false, $"Error inesperado al obtener la lista de historial. Detalle: \"{ex.Message}\"");
            }
        }
    }
}