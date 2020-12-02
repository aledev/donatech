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
    public class BuscarPublicacionController
    {
        private readonly buscarPublicaciones view;
        private Model.DbContext.DonatechEntities dbContext;

        public BuscarPublicacionController(buscarPublicaciones view)
        {
            this.view = view;
        }

        public async Task<(bool Result, string Message)> BuscarListaPublicaciones(string textoBusqueda)
        {
            try
            {
                List<ProductoDto> publicacionesList = new List<ProductoDto>();

                using (dbContext = new Model.DbContext.DonatechEntities())
                {
                    publicacionesList = await dbContext.Producto.Include("TipoProducto").Include("Usuario").Include("Comuna").Where(p => 
                    ((p.Descripcion.ToLower().Contains(textoBusqueda) || string.IsNullOrEmpty(textoBusqueda)) ||
                    (p.Titulo.ToLower().Contains(textoBusqueda) || string.IsNullOrEmpty(textoBusqueda)) ||
                    (p.TipoProducto.Descripcion.ToLower().Contains(textoBusqueda) || string.IsNullOrEmpty(textoBusqueda))) &&
                    (p.Enabled == true) && (p.FchFinalizacion == null)
                    ).OrderByDescending(p => p.FchPublicacion)
                    .Select(p =>
                    new ProductoDto
                    {
                        Id = p.Id,
                        Descripcion = p.Descripcion,
                        Estado = p.Estado,
                        FchFinalizacion = p.FchFinalizacion,
                        FchPublicacion = p.FchPublicacion,
                        IdOferente = p.IdOferente,
                        Oferente = new UsuarioDto
                        {
                            Apellidos = p.Usuario.Apellidos,
                            Celular = p.Usuario.Celular,
                            Direccion = p.Usuario.Direccion,
                            Email = p.Usuario.Email,
                            Id = p.Usuario.Id,
                            IdComuna = p.Usuario.IdComuna,
                            Comuna = new ComunaDto
                            {
                                Id = p.Usuario.IdComuna,
                                Nombre = p.Usuario.Comuna.Nombre
                            },
                            IdRol = p.Usuario.IdRol,
                            Nombre = p.Usuario.Nombre,
                            Run = p.Usuario.Run
                        },
                        IdDemandante = p.IdDemandante,
                        Imagen = p.Imagen,
                        ImagenMimeType = p.ImagenMimeType,
                        IdTipo = p.IdTipo,
                        TipoProducto = new TipoProductoDto
                        {
                            Id = p.IdTipo,
                            Descripcion = p.TipoProducto.Descripcion
                        },
                        Titulo = p.Titulo,
                        Enabled = p.Enabled
                    }).ToListAsync();
                }

                foreach (var item in publicacionesList)
                {
                    item.ImagenBase64 = $"{item.ImagenMimeType},{Convert.ToBase64String(item.Imagen)}";
                    item.Imagen = null;
                    item.ImagenMimeType = null;
                }

                this.view.lstPublicaciones.DataSource = publicacionesList;
                this.view.DataBind();

                return (true, string.Empty);
            }
            catch(Exception ex)
            {
                return (false, $"Error al intentar buscar publicaciones. Detalle: \"{ex.Message}\"");
            }
        }
    }
}