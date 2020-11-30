using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class EstadoPublicacionController
    {

        public List<Estado> recuperarEstadosPublicacion()
        {

            List<Estado> lsEstados = new List<Estado>();

            // Lista temporal de estados publicación
            lsEstados.Add(new Estado(0," -- Niguno -- ",DateTime.Today,DateTime.Today,null,null));
            lsEstados.Add(new Estado(1, "Borrador", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(2, "Revisión", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(3, "Publicada", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(4, "Retirada", DateTime.Today, DateTime.Today, null, null));
            lsEstados.Add(new Estado(5, "Eliminada", DateTime.Today, DateTime.Today, null, null));

            return lsEstados;

        }

    }

}