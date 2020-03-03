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
            decimal dConvercion = _dTiempos / 30;
            if (formatoTiempo != null && dConvercion >= 12)
            {
                Tiempos = formatoTiempo.ObtenerFormatoTiempo(dConvercion);
            }
            else
            {
                dConvercion = Math.Truncate(dConvercion);
                Tiempos = dConvercion.ToString() + " Mes"+(dConvercion>1?"es":"");
            }

            return Tiempos;
        }

        public void Siguiente(IFormatoTiempo _formatoTiempo)
        {
            this.formatoTiempo = _formatoTiempo;
        }
    }
}
