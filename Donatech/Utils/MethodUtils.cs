using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace Donatech.Utils
{
    public class MethodUtils
    {
        public static bool ValidateEmail(string email)
        {
            try
            {
                _ = new MailAddress(email).Address;
                return true;
            }
            catch 
            {
                return false;
            }
        }

		/// <summary>
		/// Metodo de validación de rut con digito verificador
		/// dentro de la cadena
		/// </summary>
		/// <param name="rut">string</param>
		/// <returns>booleano</returns>
		public static bool ValidaRut(string rut)
		{
			rut = rut.Replace(".", "").ToUpper();
			Regex expresion = new Regex("^([0-9]+-[0-9K])$");
			string dv = rut.Substring(rut.Length - 1, 1);
			if (!expresion.IsMatch(rut))
			{
				return false;
			}
			char[] charCorte = { '-' };
			string[] rutTemp = rut.Split(charCorte);
			if (dv != Digito(int.Parse(rutTemp[0])))
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// método que calcula el digito verificador a partir
		/// de la mantisa del rut
		/// </summary>
		/// <param name="rut"></param>
		/// <returns></returns>
		private static string Digito(int rut)
		{
			int suma = 0;
			int multiplicador = 1;
			while (rut != 0)
			{
				multiplicador++;
				if (multiplicador == 8)
					multiplicador = 2;
				suma += (rut % 10) * multiplicador;
				rut = rut / 10;
			}
			suma = 11 - (suma % 11);
			if (suma == 11)
			{
				return "0";
			}
			if (suma == 10)
			{
				return "K";
			}

			return suma.ToString();
		}
	}
}