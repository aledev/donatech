using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    [Serializable]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Run { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int IdComuna { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public bool Enabled { get; set; }
    }
}