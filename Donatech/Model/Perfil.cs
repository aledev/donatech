using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class Perfil
    {

        private int idPerfil;
        private string nombrePerfil;
        private DateTime fechaCreacionPerfil;
        private DateTime fechaModificacionPerfil;
        private Usuario creadoPorPerfil;
        private Usuario modificadoPorPerfil;

        // Constructores

        public Perfil(int idPerfil, string nombrePerfil, DateTime fechaCreacionPerfil, DateTime fechaModificacionPerfil, Usuario creadoPorPerfil, Usuario modificadoPorPerfil)
        {
            this.idPerfil = idPerfil;
            this.nombrePerfil = nombrePerfil;
            this.fechaCreacionPerfil = fechaCreacionPerfil;
            this.fechaModificacionPerfil = fechaModificacionPerfil;
            this.creadoPorPerfil = creadoPorPerfil;
            this.modificadoPorPerfil = modificadoPorPerfil;
        }

        public Perfil()
        {
        }


        // Propiedades

        public int IdPerfil { get => idPerfil; set => idPerfil = value; }
        public string NombrePerfil { get => nombrePerfil; set => nombrePerfil = value; }
        public DateTime FechaCreacionPerfil { get => fechaCreacionPerfil; set => fechaCreacionPerfil = value; }
        public DateTime FechaModificacionPerfil { get => fechaModificacionPerfil; set => fechaModificacionPerfil = value; }
        public Usuario CreadoPorPerfil { get => creadoPorPerfil; set => creadoPorPerfil = value; }
        public Usuario ModificadoPorPerfil { get => modificadoPorPerfil; set => modificadoPorPerfil = value; }
    }

}