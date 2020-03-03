using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BuenasPracticas.clases
{
    public class LectorJSON:IAdaptadorPaquetes
    {
        private IFormatProvider culture;

        public LectorJSON(IFormatProvider _culture)
        {
            culture = _culture;
        }

        public void ObtenerPaquetes(ref List<SolicitudEnvio> _lstEnvios)
        {
            decimal dDistancia = 0;
            string cFechaPedido = string.Empty;
            StreamReader reader = new StreamReader(File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "../../Pedidos.json"));


            var cEnvios = reader.ReadToEnd();
            JObject parsed = JObject.Parse(cEnvios);
            var JSonPedidos = parsed["Pedidos"];

            foreach (var Envio in JSonPedidos)
            {
                SolicitudEnvio solicitud = new SolicitudEnvio();
                dDistancia = 0;
                solicitud.cPaqueteria = Envio["Empresa"].ToString();
                solicitud.cTransporte = Envio["MedioTrans"].ToString();
                cFechaPedido = Envio["FechaPedido"].ToString().Replace("-", "/");
                solicitud.dtFechaEnvio = DateTime.Parse(cFechaPedido, culture);
                solicitud.cOrigen = Envio["Procedencia"].ToString();
                solicitud.cDestino = Envio["Destino"].ToString();
                solicitud.dtFechaActual = DateTime.Now;
                if (!decimal.TryParse(Envio["Dist_KM"].ToString(), out dDistancia))
                    dDistancia = 0;

                solicitud.dDistancia = dDistancia;
                _lstEnvios.Add(solicitud);

            }
        }
    }
}
