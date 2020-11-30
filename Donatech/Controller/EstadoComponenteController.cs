using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class EstadoComponenteController
    {

        public List<Estado> recuperarEstadosComponente()
        {
            List<Estado> lsEstados = new List<Estado>();

            lsEstados.Add(new Estado(0, " -- Ninguno -- ", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(1, "Nuevo", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(2, "Usado", DateTime.Today, DateTime.Today, null, null));

            return lsEstados;

        }

    }

}