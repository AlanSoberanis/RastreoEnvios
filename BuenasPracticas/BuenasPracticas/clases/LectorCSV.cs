using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BuenasPracticas.clases
{
    public class LectorCSV:IAdaptadorPaquetes
    {
        private IFormatProvider culture;

        public LectorCSV(IFormatProvider _culture)
        {
            culture = _culture;
        }

        public void ObtenerPaquetes(ref List<SolicitudEnvio> _lstEnvios)
        {
           decimal dDistancia = 0;
            string cFechaPedido = string.Empty;

            StreamReader reader = new StreamReader(File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "../../Envios.csv"), Encoding.GetEncoding("windows-1254"), true);

            while (!reader.EndOfStream)
            {
                var cEnvios = reader.ReadLine().Split(',');
                SolicitudEnvio solicitud = new SolicitudEnvio();
                dDistancia = 0;
                solicitud.cPaqueteria = cEnvios[1];
                solicitud.cTransporte = cEnvios[2];
                cFechaPedido = cEnvios[3];
                solicitud.dtFechaEnvio = DateTime.Parse(cFechaPedido, culture);
                solicitud.cOrigen = cEnvios[4] + "," + cEnvios[5];
                solicitud.cDestino = cEnvios[6] + "," + cEnvios[7];
                solicitud.dtFechaActual = DateTime.Now;
                if (!decimal.TryParse(cEnvios[0], out dDistancia))
                    dDistancia = 0;

                solicitud.dDistancia = dDistancia;

                _lstEnvios.Add(solicitud);
            }
        }
    }
}
