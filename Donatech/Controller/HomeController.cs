using Donatech.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech.Controller
{
    public class HomeController
    {
        private readonly home view;
        private Model.DbContext.DonatechEntities dbContext;

        public HomeController(home view)
        {
            this.view = view;
        }

        public async void CargarListaPublicaciones()
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
        }
    }
}