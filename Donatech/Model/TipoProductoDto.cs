using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech.Model
{
    [Serializable]
    public class TipoProductoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}