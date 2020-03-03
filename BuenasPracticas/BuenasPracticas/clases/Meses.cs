using BuenasPracticas.Interfaces;
using System;

namespace BuenasPracticas.clases
{
   public class Meses : IFormatoTiempo
    {
        private IFormatoTiempo formatoTiempo;

        public string ObtenerFormatoTiempo(decimal _dTiempos)
        {
            string Tiempos = string.Empty;
            decimal dConvercion = (((_dTiempos / 60) / 24)) / 30;
            if (formatoTiempo != null && dConvercion >= 2)
            {
                Tiempos = formatoTiempo.ObtenerFormatoTiempo(_dTiempos);
            }
            else
            {
                dConvercion = Math.Truncate(dConvercion);
                Tiempos = dConvercion.ToString() + " Mes"+(dConvercion>1?"es":"");
            }

            return Tiempos;
        }

        public string ObtenerTipoTiempo(decimal _dTiempos)
        {
            string Tiempos = string.Empty;
            decimal dConvercion = (((_dTiempos / 60) / 24)) / 30;
            if (formatoTiempo != null && dConvercion >= 2)
            {
                Tiempos = formatoTiempo.ObtenerTipoTiempo(_dTiempos);
            }
            else
            {
                Tiempos ="Meses";
            }

            return Tiempos;
        }

        public void Siguiente(IFormatoTiempo _formatoTiempo)
        {
            this.formatoTiempo = _formatoTiempo;
        }
    }
}
