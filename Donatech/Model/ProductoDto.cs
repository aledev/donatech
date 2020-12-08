using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech.Model
{
    [Serializable]
    public class ProductoDto
    {
        public int Id { get; set; }
        public int IdTipo { get; set; }
        public TipoProductoDto TipoProducto { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string ImagenBase64 { get; set; }
        public byte[] Imagen { get; set; }
        public string ImagenMimeType { get; set; }
        public int IdOferente { get; set; }
        public UsuarioDto Oferente { get; set; }
        public int? IdDemandante { get; set; }
        public UsuarioDto Demandante { get; set; }
        public System.DateTime FchPublicacion { get; set; }
        public Nullable<System.DateTime> FchFinalizacion { get; set; }
        public bool Enabled { get; set; }
        public string UrlContacto { get; set; }
        public int Index { get; set; }
        public string CardDeckHeaderHtml { get; set; }
        public string CardDeckFooterHtml { get; set; }
    }
}