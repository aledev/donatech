using Donatech.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Donatech
{
    public class LoginController
    {
        private readonly login view;
        private Model.DbContext.DonatechEntities dbContext = null;
        public LoginController(login view)
        {
            this.view = view;
        }

        public string ValidarUsuario(string emailUsuario, string passUsuario)
        {
            try
            {
                using (this.dbContext = new Model.DbContext.DonatechEntities())
                {
                    var usuarioDb = this.dbContext.Usuario.FirstOrDefault(u => u.Email == emailUsuario &&
                                                                             u.Password == passUsuario &&
                                                                             u.Enabled);

                    if (usuarioDb == null) {
                        return "00-UsuarioNoEncontrado";
                    }

                    var usuario = new Usuario
                    {
                        IdRol = usuarioDb.IdRol,
                        Email = usuarioDb.Email,
                        Apellidos = usuarioDb.Apellidos,
                        Direccion = usuarioDb.Direccion,
                        Id = usuarioDb.Id,
                        Nombre = usuarioDb.Nombre,
                        IdComuna = usuarioDb.IdComuna,
                        Run = usuarioDb.Run,
                        Enabled = usuarioDb.Enabled
                    };

                    view.Session[Constantes.SESSION_USER] = usuario;
                    FormsAuthentication.SetAuthCookie(emailUsuario, false);
                    return $"{(usuario.IdRol == (int)TipoUsuarioEnum.Oferente ? "01OF" : "01DE")}-UsuarioValido";
                }
            }
            catch(Exception ex)
            {
                return $"00-Error:{ex.Message}";
            }
        }
    }
}