using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class EstadoSolicitudController
    {

        public List<Estado> recuperarEstadosSolicitud()
        {

            List<Estado> lsEstados = new List<Estado>();

            // Lista temporal de estados solicitudes
            lsEstados.Add(new Estado(0, " -- Ninguno -- ", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(1, "Emitida", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(2, "Revisión", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(3, "Aprobada", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(4, "Rechazada", DateTime.Today, DateTime.Today, null, null));

            return lsEstados;

        }

    }

}