using BuenasPracticas.Interfaces;
using System;

namespace BuenasPracticas.clases
{
    public class Anios : IFormatoTiempo
    {
        private IFormatoTiempo formatoTiempo;

        public string ObtenerFormatoTiempo(decimal _dTiempos)
        {
            string Tiempos = string.Empty;
            decimal dConvercion = ((((_dTiempos / 60) / 24)) /30) /12;
            if (formatoTiempo != null && dConvercion ==-1)
            {
                Tiempos = formatoTiempo.ObtenerFormatoTiempo(_dTiempos);
            }
            else
            {
                dConvercion = Math.Truncate(dConvercion);
                Tiempos = dConvercion.ToString() + " Año" + (dConvercion > 1 ? "s" : "");
            }

            return Tiempos;
        }

        public string ObtenerTipoTiempo(decimal _dTiempos)
        {
            string Tiempos = string.Empty;
            decimal dConvercion = ((((_dTiempos / 60) / 24)) / 30) / 12;
            if (formatoTiempo != null && dConvercion == -1)
            {
                Tiempos = formatoTiempo.ObtenerTipoTiempo(_dTiempos);
            }
            else
            {
                Tiempos = "Años";
            }

            return Tiempos;
        }

        public void Siguiente(IFormatoTiempo _formatoTiempo)
        {
            this.formatoTiempo = _formatoTiempo;
        }
    }
}
