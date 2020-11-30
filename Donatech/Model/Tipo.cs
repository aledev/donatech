using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    [Serializable]
    public class Tipo
    {

        private int idTipo;
        private string descripcionTipo;
        private DateTime fechaCreacionTipo;
        private DateTime fechaModificacionTipo;
        private Usuario creadoPorTipo;
        private Usuario modificadoPorTipo;

        // Constructores

        public Tipo(int idTipo, string descripcionTipo, DateTime fechaCreacionTipo, DateTime fechaModificacionTipo, Usuario creadoPorTipo, Usuario modificadoPorTipo)
        {
            this.idTipo = idTipo;
            this.descripcionTipo = descripcionTipo;
            this.fechaCreacionTipo = fechaCreacionTipo;
            this.fechaModificacionTipo = fechaModificacionTipo;
            this.creadoPorTipo = creadoPorTipo;
            this.modificadoPorTipo = modificadoPorTipo;
        }

        public Tipo()
        {
        }

        // Propiedades

        public int IdTipo { get => idTipo; set => idTipo = value; }
        public string DescripcionTipo { get => descripcionTipo; set => descripcionTipo = value; }
        public DateTime FechaCreacionTipo { get => fechaCreacionTipo; set => fechaCreacionTipo = value; }
        public DateTime FechaModificacionTipo { get => fechaModificacionTipo; set => fechaModificacionTipo = value; }
        public Usuario CreadoPorTipo { get => creadoPorTipo; set => creadoPorTipo = value; }
        public Usuario ModificadoPorTipo { get => modificadoPorTipo; set => modificadoPorTipo = value; }
    }

}