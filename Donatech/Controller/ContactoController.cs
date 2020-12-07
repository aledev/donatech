using Donatech.Model;
using Donatech.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Donatech.Model.DbContext;

namespace Donatech.Controller
{
    public class ContactoController
    {
        private readonly contacto view;
        private DonatechEntities dbContext;

        public ContactoController(contacto view)
        {
            this.view = view;
        }

        public async Task<(UsuarioDto Result, string Message)> ObtenerDatosContacto(int idUsuario)
        {
            try
            {
                using (dbContext = new DonatechEntities())
                {
                    var infoDonante = await Task.FromResult(
                        dbContext.Usuario.Include("Comuna").Where(u => u.Id == idUsuario)
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
                        }).FirstOrDefault());

                    return (infoDonante, "Usuario encontrado satisfactoriamente.");
                }
            }
            catch (Exception ex)
            {
                return (null, $"Error al intentar obtener el usuario. Detalle: \"{ex.Message}\"");
            }
        }

        public async Task<(List<MensajeDto> Mensajes, string Message)> ObtenerMensajes(int usuarioSession, int idProducto)
        {
            try
            {
                using (dbContext = new DonatechEntities())
                {
                    var mensajes = await dbContext.Mensaje.Include("Usuario")
                        .Where(m => m.IdProducto == idProducto)
                        .Select(m =>
                        new MensajeDto
                        {
                            Id = m.Id,
                            FchEnvio = m.FchEnvio,
                            IdEmisor = m.IdEmisor,
                            IdProducto = m.IdProducto,
                            Enabled = m.Enabled,
                            IdReceptor = m.IdReceptor,
                            Mensaje = m.Mensaje1,
                            DatosEmisor = new UsuarioDto
                            {
                                Nombre = m.Usuario.Nombre,
                                Apellidos = m.Usuario.Apellidos
                            },
                            DatosReceptor = new UsuarioDto
                            {
                                Nombre = m.Usuario1.Nombre,
                                Apellidos = m.Usuario1.Apellidos
                            }
                        })
                        .OrderBy(m => m.FchEnvio)
                        .ToListAsync();

                    foreach(var mensaje in mensajes)
                    {
                        mensaje.SesionEmisor = mensaje.IdEmisor == usuarioSession;
                        mensaje.DatosEmisor.Iniciales = (mensaje.DatosEmisor.Nombre[0] + "" + mensaje.DatosEmisor.Apellidos[0]).ToUpper();
                        mensaje.DatosReceptor.Iniciales = (mensaje.DatosReceptor.Nombre[0] + "" + mensaje.DatosReceptor.Apellidos[0]).ToUpper();
                    }

                    return (mensajes, "Mensajes encontrados satisfactoriamente.");
                }
            }
            catch (Exception ex)
            {
                return (null, $"Error al obtener los mensajes. Detalle: \"{ex.Message}\"");
            }
        }

        public async Task<(bool Result, string Message)> InsertarMensaje(MensajeDto mensaje)
        {
            try
            {
                using (dbContext = new DonatechEntities())
                {
                    dbContext.Mensaje.Add(new Mensaje
                    {
                        FchEnvio = mensaje.FchEnvio,
                        IdEmisor = mensaje.IdEmisor,
                        IdProducto = mensaje.IdProducto,
                        IdReceptor = mensaje.IdReceptor,
                        Mensaje1 = mensaje.Mensaje,
                        Enabled = true
                    });

                    var dbResult = await dbContext.SaveChangesAsync();
                    return dbResult > 0 ?
                        (true, "Mensaje insertado satisfactoriamente") :
                        (false, "Error al intentar registrar el mensaje. Por favor, intentelo nuevamente");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error al intentar registrar el usuario. Detalle: \"{ex.Message}\"");
            }
        }
    }
}