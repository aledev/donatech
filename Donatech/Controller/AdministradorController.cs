using Donatech.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class AdministradorController
    {
        private readonly frmAdminUsuarios view;
        private List<Usuario> lstUsuarios
        {
            get
            {
                if (view.Session["lstUsuarios"] == null)
                {
                    view.Session["lstUsuarios"] = new List<Usuario>
                    {
                        new Usuario{ Run = "1-9", Nombre = "Usuario", Apellidos = "Test1", Email = "usertest1@aol.com" },
                        new Usuario{ Run = "2-7", Nombre = "Usuario", Apellidos = "Test2", Email = "usertest2@aol.com" }
                    };
                }

                return (List<Usuario>)view.Session["lstUsuarios"];
            }
            set
            {
                view.Session["lstUsuarios"] = value;
            }
        }

        public AdministradorController(frmAdminUsuarios view)
        {
            this.view = view;
        }

        public void CargarListaUsuarios()
        {
            view.lstUsuarios.DataSource = this.lstUsuarios;
            view.lstUsuarios.DataBind();
        }

        public void AgregarUsuario(string rut, string nombre, string apellido, string email)
        {
            this.lstUsuarios.Add(new Usuario
            {
                Run = rut,
                Nombre = nombre,
                Apellidos = apellido,
                Email = email
            });
        }
    }
}