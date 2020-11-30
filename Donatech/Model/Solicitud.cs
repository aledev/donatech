using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class Solicitud
    {

        private int idSolicitud;
        private Publicacion publicacionSolicitud;
        private DateTime fechaSolicitud;
        private Estado estadoSolicitud;
        private Usuario solicitanteSolicitud;
        private Beneficiario beneficiarioSolicitud;
        private DateTime fechaCreacionSolicitud;
        private DateTime fechaModificacionSolicitud;
        private Usuario creadoPorSolicitud;
        private Usuario modificadoPorSolicitud;

        // Constructores

        public Solicitud(int idSolicitud, Publicacion publicacionSolicitud, DateTime fechaSolicitud, Estado estadoSolicitud, Usuario solicitanteSolicitud, Beneficiario beneficiarioSolicitud, DateTime fechaCreacionSolicitud, DateTime fechaModificacionSolicitud, Usuario creadoPorSolicitud, Usuario modificadoPorSolicitud)
        {
            this.idSolicitud = idSolicitud;
            this.publicacionSolicitud = publicacionSolicitud;
            this.fechaSolicitud = fechaSolicitud;
            this.estadoSolicitud = estadoSolicitud;
            this.solicitanteSolicitud = solicitanteSolicitud;
            this.beneficiarioSolicitud = beneficiarioSolicitud;
            this.fechaCreacionSolicitud = fechaCreacionSolicitud;
            this.fechaModificacionSolicitud = fechaModificacionSolicitud;
            this.creadoPorSolicitud = creadoPorSolicitud;
            this.modificadoPorSolicitud = modificadoPorSolicitud;
        }

        public Solicitud()
        {
        }

        // Propiedades

        public int IdSolicitud { get => idSolicitud; set => idSolicitud = value; }
        public Publicacion PublicacionSolicitud { get => publicacionSolicitud; set => publicacionSolicitud = value; }
        public DateTime FechaSolicitud { get => fechaSolicitud; set => fechaSolicitud = value; }
        public Estado EstadoSolicitud { get => estadoSolicitud; set => estadoSolicitud = value; }
        public Usuario SolicitanteSolicitud { get => solicitanteSolicitud; set => solicitanteSolicitud = value; }
        public Beneficiario BeneficiarioSolicitud { get => beneficiarioSolicitud; set => beneficiarioSolicitud = value; }
        public DateTime FechaCreacionSolicitud { get => fechaCreacionSolicitud; set => fechaCreacionSolicitud = value; }
        public DateTime FechaModificacionSolicitud { get => fechaModificacionSolicitud; set => fechaModificacionSolicitud = value; }
        public Usuario CreadoPorSolicitud { get => creadoPorSolicitud; set => creadoPorSolicitud = value; }
        public Usuario ModificadoPorSolicitud { get => modificadoPorSolicitud; set => modificadoPorSolicitud = value; }

    }

}