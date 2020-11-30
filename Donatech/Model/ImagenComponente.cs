using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class ImagenComponente
    {

        private int idImagenComponente;
        private Componente componenteImagenComponente;
        private byte[] cuerpoImagenComponente;
        private DateTime fechaCreacionImagenComponente;
        private DateTime fechaModificacionImagenComponente;
        private Usuario creadoPorImagenComponente;
        private Usuario modificadoPorImagenComponente;

        // Propiedades

        public int IdImagenComponente { get => idImagenComponente; set => idImagenComponente = value; }
        public Componente ComponenteImagenComponente { get => componenteImagenComponente; set => componenteImagenComponente = value; }
        public byte[] CuerpoImagenComponente { get => cuerpoImagenComponente; set => cuerpoImagenComponente = value; }
        public DateTime FechaCreacionImagenComponente { get => fechaCreacionImagenComponente; set => fechaCreacionImagenComponente = value; }
        public DateTime FechaModificacionImagenComponente { get => fechaModificacionImagenComponente; set => fechaModificacionImagenComponente = value; }
        public Usuario CreadoPorImagenComponente { get => creadoPorImagenComponente; set => creadoPorImagenComponente = value; }
        public Usuario ModificadoPorImagenComponente { get => modificadoPorImagenComponente; set => modificadoPorImagenComponente = value; }

        // Constructores

        public ImagenComponente(int idImagenComponente, Componente componenteImagenComponente, byte[] cuerpoImagenComponente, DateTime fechaCreacionImagenComponente, DateTime fechaModificacionImagenComponente, Usuario creadoPorImagenComponente, Usuario modificadoPorImagenComponente)
        {
            this.idImagenComponente = idImagenComponente;
            this.componenteImagenComponente = componenteImagenComponente;
            this.cuerpoImagenComponente = cuerpoImagenComponente;
            this.fechaCreacionImagenComponente = fechaCreacionImagenComponente;
            this.fechaModificacionImagenComponente = fechaModificacionImagenComponente;
            this.creadoPorImagenComponente = creadoPorImagenComponente;
            this.modificadoPorImagenComponente = modificadoPorImagenComponente;
        }

        public ImagenComponente()
        {
        }

    }

}