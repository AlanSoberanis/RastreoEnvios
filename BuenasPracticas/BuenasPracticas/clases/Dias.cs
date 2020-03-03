using BuenasPracticas.Interfaces;
using System;

namespace BuenasPracticas.clases
{
   public class Dias : IFormatoTiempo
    {
        private IFormatoTiempo formatoTiempo;

        public string ObtenerFormatoTiempo(decimal _dTiempos)
        {

            string Tiempos = string.Empty;
            decimal dConvercion = (_dTiempos/60) / 24;
            if(formatoTiempo!=null && dConvercion>=7)
            {
                Tiempos = formatoTiempo.ObtenerFormatoTiempo(_dTiempos);
            }
            else
            {
                dConvercion = Math.Truncate(dConvercion);
                Tiempos = dConvercion.ToString() + " Día" + (dConvercion > 1 ? "s" : "");
            }

            return Tiempos;
            
            
        }

        public string ObtenerTipoTiempo(decimal _dTiempos)
        {
            string Tiempos = string.Empty;
            decimal dConvercion = (_dTiempos / 60) / 24;
            if (formatoTiempo != null && dConvercion >= 7)
            {
                Tiempos = formatoTiempo.ObtenerTipoTiempo(_dTiempos);
            }
            else
            {
                Tiempos = "Días";
            }

            return Tiempos;
        }

        public void Siguiente(IFormatoTiempo _formatoTiempo)
        {
            this.formatoTiempo = _formatoTiempo;
        }
    }
}
