using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class Estado
    {

        private int idEstado;
        private string descripcionEstado;
        private DateTime fechaCreacionEstado;
        private DateTime fechaModificacionEstado;
        private Usuario creadoPorEstado;
        private Usuario modificadoPorEstado;

        // Propiedades
        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string DescripcionEstado { get => descripcionEstado; set => descripcionEstado = value; }
        public DateTime FechaCreacionEstado { get => fechaCreacionEstado; set => fechaCreacionEstado = value; }
        public DateTime FechaModificacionEstado { get => fechaModificacionEstado; set => fechaModificacionEstado = value; }
        public Usuario CreadoPorEstado { get => creadoPorEstado; set => creadoPorEstado = value; }
        public Usuario ModificadoPorEstado { get => modificadoPorEstado; set => modificadoPorEstado = value; }

        // Constructores
        public Estado(int idEstado, string descripcionEstado, DateTime fechaCreacionEstado, DateTime fechaModificacionEstado, Usuario creadoPorEstado, Usuario modificadoPorEstado)
        {
            this.idEstado = idEstado;
            this.descripcionEstado = descripcionEstado;
            this.fechaCreacionEstado = fechaCreacionEstado;
            this.fechaModificacionEstado = fechaModificacionEstado;
            this.creadoPorEstado = creadoPorEstado;
            this.modificadoPorEstado = modificadoPorEstado;
        }

        public Estado()
        {
        }

    }

}