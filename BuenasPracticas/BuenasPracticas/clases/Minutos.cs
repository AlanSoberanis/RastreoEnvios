using BuenasPracticas.Interfaces;
using System;

namespace BuenasPracticas.clases
{
    public class Minutos : IFormatoTiempo
    {
        private IFormatoTiempo formatoTiempo;

        public string ObtenerFormatoTiempo(decimal _dTiempos)
        {
            string Tiempos = string.Empty;

            decimal dConvercion = _dTiempos;
            
            if (formatoTiempo != null && dConvercion >= 60)
            {
                Tiempos = formatoTiempo.ObtenerFormatoTiempo(dConvercion);
            }
            else
            {
                dConvercion = Math.Truncate(dConvercion);
                Tiempos = dConvercion.ToString() + " Minuto" + (dConvercion > 1 ? "s" : "");
            }

            return Tiempos;


        }

        public void Siguiente(IFormatoTiempo _formatoTiempo)
        {
            this.formatoTiempo = _formatoTiempo;
        }
    }
}
