using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class EstadoUsuarioController
    {

        public List<Estado> recuperarEstadosUsuario()
        {
            List<Estado> lsEstados = new List<Estado>();

            // Lista temporal de estados usaurios
            lsEstados.Add(new Estado(0, " -- Ninguno -- ", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(1, "Activo", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(2, "Validación", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(3, "Suspendido", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(4, "Inactivo", DateTime.Today, DateTime.Today, null, null));

            return lsEstados;
        }

    }

}