using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;

namespace BuenasPracticas.clases
{
    public class Mensaje : IMensajesColor
    {
      
            public Mensaje(SolicitudEnvio solicitudEnvio)
        {
            SolicitudEnvio = solicitudEnvio;
            AsignarColores();
        }

        protected SolicitudEnvio SolicitudEnvio { get; set; }


        public void AsignarColores()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public string ImprimirMensajeEnvio()
        {
            return string.Format("Tu paquete salió de {0} y llegó a {1} " +
               "hace {2} y tuvo un costo de ${3}" +
               "(Cualquier reclamación con {4}).",SolicitudEnvio.cOrigen,
               SolicitudEnvio.cDestino,
              SolicitudEnvio.cTiempo ,SolicitudEnvio.dCostosEnvio,SolicitudEnvio.cPaqueteria);
        }

    }
}