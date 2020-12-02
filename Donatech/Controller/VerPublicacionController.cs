using Donatech.Model;
using Donatech.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Donatech.Controller
{
    public class VerPublicacionController
    {
        private readonly verPublicacion view;
        private Model.DbContext.DonatechEntities dbContext;

        public VerPublicacionController(verPublicacion view)
        {
            this.view = view;
        }

        public async Task<(ProductoDto Producto, string Messsage)> ObtenerPublicacion(int idPublicacion)
        {
            try
            {
                ProductoDto producto = null;
                using (dbContext = new Model.DbContext.DonatechEntities())
                {
                    producto = dbContext.Producto.Include("TipoProducto").Include("Usuario").Include("Comuna")
                       .Where(p => p.Id == idPublicacion)
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
                       }).FirstOrDefault();
                }

                producto.ImagenBase64 = $"{producto.ImagenMimeType},{Convert.ToBase64String(producto.Imagen)}";
                producto.Imagen = null;
                producto.ImagenMimeType = null;

                return await Task.FromResult((producto, string.Empty));
            }
            catch(Exception ex)
            {
                return (null, $"Error al intentar obtener la publicacion. Detalle: \"{ex.Message}\"");
            }
        }

        public async Task<(UsuarioDto Result, string Message)> AceptarDonacion(ProductoDto producto)
        {
            try
            {
                using (dbContext = new Model.DbContext.DonatechEntities())
                {
                    var productoDb = dbContext.Producto.FirstOrDefault(p => p.Id == producto.Id);
                    productoDb.IdDemandante = producto.IdDemandante;
                    productoDb.FchFinalizacion = producto.FchFinalizacion;

                    var infoDonante = dbContext.Usuario.Include("Comuna").Where(u => u.Id == productoDb.IdOferente)
                        .Select(u =>
                        new UsuarioDto 
                        {
                            Id = u.Id,
                            Apellidos = u.Apellidos,
                            Celular = u.Celular,
                            Comuna = new ComunaDto
                            {
                                Id = u.Comuna.Id,
                                Nombre = u.Comuna.Nombre
                            },
                            Direccion = u.Direccion,
                            Email = u.Email,
                            IdComuna = u.IdComuna,
                            Nombre = u.Nombre,
                            IdRol = u.IdRol,
                            Run = u.Run
                        }).FirstOrDefault();
                    
                    var dbResult = await dbContext.SaveChangesAsync();

                    return dbResult > 0 ?
                        (infoDonante, "Donacion aceptada existosamente. En un momento le enviaremos la informacion de contacto del donante") :
                        (null, "Error al intentar aceptar la donacion. Por favor, intentelo nuevamente");
                }
            }
            catch (Exception ex)
            {
                return (null, $"Error al intentar aceptar la donacion. Detalle: \"{ex.Message}\"");
            }
        }
    }
}