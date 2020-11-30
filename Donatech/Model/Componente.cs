using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class Componente
    {

        private int idComponente;
        private Publicacion publicacionComponente;
        private Estado estadoComponente;
        private string descripcionComponente;
        private Tipo tipoUsoComponente;
        private string ubicacionComponente;
        private string dirCalleComponente;
        private string dirNumeroComponente;
        private string dirInfoAdicionalComponente;
        private Comuna dirComunaComponente;
        private DateTime fechaCreacionComponente;
        private DateTime fechaModificacionComponente;
        private Usuario creadoPorComponente;
        private Usuario modificadoPorComponente;

        // Constructores

        public Componente(int idComponente, Publicacion publicacionComponente, Estado estadoComponente, string descripcionComponente, Tipo tipoUsoComponente, string ubicacionComponente, string dirCalleComponente, string dirNumeroComponente, string dirInfoAdicionalComponente, Comuna dirComunaComponente, DateTime fechaCreacionComponente, DateTime fechaModificacionComponente, Usuario creadoPorComponente, Usuario modificadoPorComponente)
        {
            this.idComponente = idComponente;
            this.publicacionComponente = publicacionComponente;
            this.estadoComponente = estadoComponente;
            this.descripcionComponente = descripcionComponente;
            this.tipoUsoComponente = tipoUsoComponente;
            this.ubicacionComponente = ubicacionComponente;
            this.dirCalleComponente = dirCalleComponente;
            this.dirNumeroComponente = dirNumeroComponente;
            this.dirInfoAdicionalComponente = dirInfoAdicionalComponente;
            this.dirComunaComponente = dirComunaComponente;
            this.fechaCreacionComponente = fechaCreacionComponente;
            this.fechaModificacionComponente = fechaModificacionComponente;
            this.creadoPorComponente = creadoPorComponente;
            this.modificadoPorComponente = modificadoPorComponente;
        }

        public Componente()
        {
        }

        // Propiedades

        public int IdComponente { get => idComponente; set => idComponente = value; }
        public Publicacion PublicacionComponente { get => publicacionComponente; set => publicacionComponente = value; }
        public Estado EstadoComponente { get => estadoComponente; set => estadoComponente = value; }
        public string DescripcionComponente { get => descripcionComponente; set => descripcionComponente = value; }
        public Tipo TipoUsoComponente { get => tipoUsoComponente; set => tipoUsoComponente = value; }
        public string UbicacionComponente { get => ubicacionComponente; set => ubicacionComponente = value; }
        public string DirCalleComponente { get => dirCalleComponente; set => dirCalleComponente = value; }
        public string DirNumeroComponente { get => dirNumeroComponente; set => dirNumeroComponente = value; }
        public string DirInfoAdicionalComponente { get => dirInfoAdicionalComponente; set => dirInfoAdicionalComponente = value; }
        public Comuna DirComunaComponente { get => dirComunaComponente; set => dirComunaComponente = value; }
        public DateTime FechaCreacionComponente { get => fechaCreacionComponente; set => fechaCreacionComponente = value; }
        public DateTime FechaModificacionComponente { get => fechaModificacionComponente; set => fechaModificacionComponente = value; }
        public Usuario CreadoPorComponente { get => creadoPorComponente; set => creadoPorComponente = value; }
        public Usuario ModificadoPorComponente { get => modificadoPorComponente; set => modificadoPorComponente = value; }

    }

}