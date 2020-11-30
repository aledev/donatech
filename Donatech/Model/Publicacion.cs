using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class Publicacion
    {

        private int idPublicacion;
        private Usuario usuarioPublicacion;
        private Estado estadoPublicacion;
        private Tipo tipoPublicacion;
        private DateTime fechaPublicacion;
        private DateTime fechaCreacionPublicacion;
        private DateTime fechaModificacionPublicacion;
        private Usuario creadoPorPublicacion;
        private Usuario modificadoPorPublicacion;

        // Constructores

        public Publicacion(int idPublicacion, Usuario usuarioPublicacion, Estado estadoPublicacion, Tipo tipoPublicacion, DateTime fechaPublicacion, DateTime fechaCreacionPublicacion, DateTime fechaModificacionPublicacion, Usuario creadoPorPublicacion, Usuario modificadoPorPublicacion)
        {
            this.idPublicacion = idPublicacion;
            this.usuarioPublicacion = usuarioPublicacion;
            this.estadoPublicacion = estadoPublicacion;
            this.tipoPublicacion = tipoPublicacion;
            this.fechaPublicacion = fechaPublicacion;
            this.fechaCreacionPublicacion = fechaCreacionPublicacion;
            this.fechaModificacionPublicacion = fechaModificacionPublicacion;
            this.creadoPorPublicacion = creadoPorPublicacion;
            this.modificadoPorPublicacion = modificadoPorPublicacion;
        }

        public Publicacion()
        {
        }

        // Propiedades

        public int IdPublicacion { get => idPublicacion; set => idPublicacion = value; }
        public Usuario UsuarioPublicacion { get => usuarioPublicacion; set => usuarioPublicacion = value; }
        public Estado EstadoPublicacion { get => estadoPublicacion; set => estadoPublicacion = value; }
        public Tipo TipoPublicacion { get => tipoPublicacion; set => tipoPublicacion = value; }
        public DateTime FechaPublicacion { get => fechaPublicacion; set => fechaPublicacion = value; }
        public DateTime FechaCreacionPublicacion { get => fechaCreacionPublicacion; set => fechaCreacionPublicacion = value; }
        public DateTime FechaModificacionPublicacion { get => fechaModificacionPublicacion; set => fechaModificacionPublicacion = value; }
        public Usuario CreadoPorPublicacion { get => creadoPorPublicacion; set => creadoPorPublicacion = value; }
        public Usuario ModificadoPorPublicacion { get => modificadoPorPublicacion; set => modificadoPorPublicacion = value; }

    }

}