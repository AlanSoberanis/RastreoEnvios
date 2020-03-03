using BuenasPracticas.clases;
using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuenasPracticas.Factory
{
    public class AdaptadorLectura
    {
        IFormatProvider culture;

        string Comando;

        public  AdaptadorLectura(string _Comando, IFormatProvider _culture)
        {
            culture = _culture;
            Comando = _Comando;
        }

        public void ObtenerPaquetes(ref List<SolicitudEnvio> _lstEnvios)
        {
            IAdaptadorPaquetes paquete;
            switch (Comando)
            {
                case "-f JSON":
                     paquete = new LectorJSON(culture);
                    break;
                case "-f CSV":
                     paquete = new LectorJSON(culture);
                    break;
                default:
                    throw new Exception(string.Format("El Comando {0} no se puede reconoce como un comando valido.", Comando));
                    break;
            }

            paquete.ObtenerPaquetes(ref _lstEnvios);
        }
    }
}
