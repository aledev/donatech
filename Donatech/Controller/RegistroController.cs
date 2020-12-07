using Donatech.Model.DbContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using System.Web.UI.WebControls;
using Donatech.Utils;

namespace Donatech
{
    public class RegistroController
    {
        private readonly Donatech.registroperfil view;
        private DonatechEntities dbContext;

        public RegistroController(registroperfil view)
        {
            this.view = view;
        }

        public async Task CargarListaComunas()
        {
            try
            {
                using (dbContext = new DonatechEntities())
                {
                    var lstComunasDb = await dbContext.Comuna.OrderBy(c => c.Nombre).ToListAsync();
                    var lstComunas = lstComunasDb.Select(c => new ComunaDto
                    {
                        Id = c.Id,
                        Nombre = c.Nombre
                    }).ToList();

                    view.ddlComuna.DataSource = lstComunas;
                    view.ddlComuna.DataValueField = "Id";
                    view.ddlComuna.DataTextField = "Nombre";
                    view.ddlComuna.DataBind();
                }
            }
            catch 
            {
                var lstComunas = new List<ComunaDto>
                {
                    new ComunaDto{ Id = 0, Nombre = "[Error al cargar la lista]" }
                };

                view.ddlComuna.DataSource = lstComunas;
                view.ddlComuna.DataValueField = "Id";
                view.ddlComuna.DataTextField = "Nombre";
                view.ddlComuna.DataBind();
            }

            await Task.FromResult(0);
        }

        public async Task CargarListaTiposUsuario()
        {
            view.ddlTipoUsuario.Items.Clear();
            view.ddlTipoUsuario.Items.AddRange(new ListItem[] 
            {
                new ListItem 
                {
                    Selected = true,
                    Text = "Oferente",
                    Value = ((int)TipoUsuarioEnum.Oferente).ToString()
                },
                new ListItem
                {
                    Text = "Demandante",
                    Value = ((int)TipoUsuarioEnum.Demandante).ToString()
                }
            });

            await Task.FromResult(0);
        }

        public async Task<(bool Result, string Message)> RegistrarUsuario(UsuarioDto usuario)
        {
            try
            {
                using (dbContext = new DonatechEntities())
                {
                    if(await dbContext.Usuario.FirstOrDefaultAsync(u => u.Run == usuario.Run) != null)
                    {
                        return (false, "El Run ingresado ya se encuentra registrado");
                    }
                    if(await dbContext.Usuario.FirstOrDefaultAsync(u => u.Email == usuario.Email) != null)
                    {
                        return (false, "El Email ingresado ya se encuentra registrado");
                    }

                    dbContext.Usuario.Add(new Model.DbContext.Usuario
                    {
                        Apellidos = usuario.Apellidos,
                        Direccion = usuario.Direccion,
                        Email = usuario.Email,
                        IdComuna = usuario.IdComuna,
                        IdRol = usuario.IdRol,
                        Nombre = usuario.Nombre,
                        Password = usuario.Password,
                        Run = usuario.Run,
                        Celular = usuario.Celular,
                        Enabled = true
                    });

                    var dbResult = await dbContext.SaveChangesAsync();
                    return dbResult > 0 ? 
                        (true, "Usuario registrado correctamente") :
                        (false, "Error al intentar registrar el usuario. Por favor, intentelo nuevamente");
                }
            }
            catch(Exception ex)
            {
                return (false, $"Error al intentar registrar el usuario. Detalle: \"{ex.Message}\"");
            }
        }
    }
}