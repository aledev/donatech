using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech.Utils
{
    public class Constantes
    {
        public const string SESSION_USER = "UsuarioSession";

        public static List<string> ListaEstadoProductos => new List<string>
        {
            "Nuevo", 
            "Usado"
        };
    }

    public enum TipoUsuarioEnum
    {
        Oferente = 1,
        Demandante = 2
    }

    public enum AlertMessageTypeEnum
    {
        Info,
        Danger
    }
}