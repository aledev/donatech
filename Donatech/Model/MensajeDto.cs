using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech.Model
{
    public class MensajeDto
    {
        public long Id { get; set; }
        public int IdEmisor { get; set; }
        public UsuarioDto DatosEmisor { get; set; }
        public int IdReceptor { get; set; }
        public UsuarioDto DatosReceptor { get; set; }
        public System.DateTime FchEnvio { get; set; }
        public string Mensaje { get; set; }
        public int IdProducto { get; set; }
        public bool Enabled { get; set; }
        public bool SesionEmisor { get; set; }
    }
}