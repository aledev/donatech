using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class Password
    {

        private int idPassword;
        private Usuario usuarioPassword;
        private string actualPassword;
        private string anteriorPassword;
        private Tipo tipoPassword;
        private Estado estadoPassword;
        private DateTime fechaCreacionPassword;
        private DateTime fechaModificacionPassword;
        private Usuario creadoPorPassword;
        private Usuario modificadoPorPassword;

        // Constructores

        public Password(int idPassword, Usuario usuarioPassword, string actualPassword, string anteriorPassword, Tipo tipoPassword, Estado estadoPassword, DateTime fechaCreacionPassword, DateTime fechaModificacionPassword, Usuario creadoPorPassword, Usuario modificadoPorPassword)
        {
            this.idPassword = idPassword;
            this.usuarioPassword = usuarioPassword;
            this.actualPassword = actualPassword;
            this.anteriorPassword = anteriorPassword;
            this.tipoPassword = tipoPassword;
            this.estadoPassword = estadoPassword;
            this.fechaCreacionPassword = fechaCreacionPassword;
            this.fechaModificacionPassword = fechaModificacionPassword;
            this.creadoPorPassword = creadoPorPassword;
            this.modificadoPorPassword = modificadoPorPassword;
        }

        public Password()
        {
        }

        // Propiedades

        public int IdPassword { get => idPassword; set => idPassword = value; }
        public Usuario UsuarioPassword { get => usuarioPassword; set => usuarioPassword = value; }
        public string ActualPassword { get => actualPassword; set => actualPassword = value; }
        public string AnteriorPassword { get => anteriorPassword; set => anteriorPassword = value; }
        public Tipo TipoPassword { get => tipoPassword; set => tipoPassword = value; }
        public Estado EstadoPassword { get => estadoPassword; set => estadoPassword = value; }
        public DateTime FechaCreacionPassword { get => fechaCreacionPassword; set => fechaCreacionPassword = value; }
        public DateTime FechaModificacionPassword { get => fechaModificacionPassword; set => fechaModificacionPassword = value; }
        public Usuario CreadoPorPassword { get => creadoPorPassword; set => creadoPorPassword = value; }
        public Usuario ModificadoPorPassword { get => modificadoPorPassword; set => modificadoPorPassword = value; }
    }

}