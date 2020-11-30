using Donatech.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech.Controller
{
    public class MisPublicacionesController
    {
        private readonly misPublicaciones view;
        private Model.DbContext.DonatechEntities dbContext;

        public MisPublicacionesController(misPublicaciones view)
        {
            this.view = view;
        }

        public void CargarMisPublicaciones()
        {
            try
            {

            }
            catch
            {

            }
        }
    }
}