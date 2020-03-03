using BuenasPracticas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuenasPracticas.clases
{
    public class Semanas : IFormatoTiempo
    {
        private IFormatoTiempo formatoTiempo;

        public string ObtenerFormatoTiempo(decimal _dTiempos)
        {

            string Tiempos = string.Empty;
            decimal dConvercion = ((_dTiempos / 60) / 24)/7;
            if (formatoTiempo != null && dConvercion >= 4)
            {
                Tiempos = formatoTiempo.ObtenerFormatoTiempo(_dTiempos);
            }
            else
            {
                dConvercion = Math.Truncate(dConvercion);
                Tiempos = dConvercion.ToString() + " Semana" + (dConvercion > 1 ? "s" : "");
            }

            return Tiempos;

        }

        public string ObtenerTipoTiempo(decimal _dTiempos)
        {

            string Tiempos = string.Empty;
            decimal dConvercion = ((_dTiempos / 60) / 24) / 7;
            if (formatoTiempo != null && dConvercion >= 4)
            {
                Tiempos = formatoTiempo.ObtenerTipoTiempo(_dTiempos);
            }
            else
            {
                Tiempos = "Semanas";
            }

            return Tiempos;
        }

        public void Siguiente(IFormatoTiempo _formatoTiempo)
        {
            this.formatoTiempo = _formatoTiempo;
        }
    }
}
