using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatech
{
    public class Beneficiario
    {

        private int idBeneficiario;
        private string nombreBeneficiario;
        private Tipo tipoBeneficiario;
        private string razonSocialBeneficiario;
        private string giroBeneficiario;
        private string telefonoBeneficiario;
        private string emailBeneficiario;
        private string dirCalleBeneficiario;
        private string dirNumeroBeneficiario;
        private string dirInfoAdicionalBeneficiario;
        private Comuna dirComunaBeneficiario;
        private DateTime fechaCreacionBeneficiario;
        private DateTime fechaModificacionBeneficiario;
        private Usuario creadoPorBeneficiario;
        private Usuario modificadoPorBeneficiario;

        // Constructores

        public Beneficiario(int idBeneficiario, string nombreBeneficiario, Tipo tipoBeneficiario, string razonSocialBeneficiario, string giroBeneficiario, string telefonoBeneficiario, string emailBeneficiario, string dirCalleBeneficiario, string dirNumeroBeneficiario, string dirInfoAdicionalBeneficiario, Comuna dirComunaBeneficiario, DateTime fechaCreacionBeneficiario, DateTime fechaModificacionBeneficiario, Usuario creadoPorBeneficiario, Usuario modificadoPorBeneficiario)
        {
            this.idBeneficiario = idBeneficiario;
            this.nombreBeneficiario = nombreBeneficiario;
            this.tipoBeneficiario = tipoBeneficiario;
            this.razonSocialBeneficiario = razonSocialBeneficiario;
            this.giroBeneficiario = giroBeneficiario;
            this.telefonoBeneficiario = telefonoBeneficiario;
            this.emailBeneficiario = emailBeneficiario;
            this.dirCalleBeneficiario = dirCalleBeneficiario;
            this.dirNumeroBeneficiario = dirNumeroBeneficiario;
            this.dirInfoAdicionalBeneficiario = dirInfoAdicionalBeneficiario;
            this.dirComunaBeneficiario = dirComunaBeneficiario;
            this.fechaCreacionBeneficiario = fechaCreacionBeneficiario;
            this.fechaModificacionBeneficiario = fechaModificacionBeneficiario;
            this.creadoPorBeneficiario = creadoPorBeneficiario;
            this.modificadoPorBeneficiario = modificadoPorBeneficiario;
        }

        public Beneficiario()
        {
        } 

        // Propiedades

        public int IdBeneficiario { get => idBeneficiario; set => idBeneficiario = value; }
        public string NombreBeneficiario { get => nombreBeneficiario; set => nombreBeneficiario = value; }
        public Tipo TipoBeneficiario { get => tipoBeneficiario; set => tipoBeneficiario = value; }
        public string RazonSocialBeneficiario { get => razonSocialBeneficiario; set => razonSocialBeneficiario = value; }
        public string GiroBeneficiario { get => giroBeneficiario; set => giroBeneficiario = value; }
        public string TelefonoBeneficiario { get => telefonoBeneficiario; set => telefonoBeneficiario = value; }
        public string EmailBeneficiario { get => emailBeneficiario; set => emailBeneficiario = value; }
        public string DirCalleBeneficiario { get => dirCalleBeneficiario; set => dirCalleBeneficiario = value; }
        public string DirNumeroBeneficiario { get => dirNumeroBeneficiario; set => dirNumeroBeneficiario = value; }
        public string DirInfoAdicionalBeneficiario { get => dirInfoAdicionalBeneficiario; set => dirInfoAdicionalBeneficiario = value; }
        public Comuna DirComunaBeneficiario { get => dirComunaBeneficiario; set => dirComunaBeneficiario = value; }
        public DateTime FechaCreacionBeneficiario { get => fechaCreacionBeneficiario; set => fechaCreacionBeneficiario = value; }
        public DateTime FechaModificacionBeneficiario { get => fechaModificacionBeneficiario; set => fechaModificacionBeneficiario = value; }
        public Usuario CreadoPorBeneficiario { get => creadoPorBeneficiario; set => creadoPorBeneficiario = value; }
        public Usuario ModificadoPorBeneficiario { get => modificadoPorBeneficiario; set => modificadoPorBeneficiario = value; }

    }

}