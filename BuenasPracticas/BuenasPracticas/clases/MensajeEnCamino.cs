using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;

namespace BuenasPracticas.clases
{
    public class MensajeEnCamino : IMensajesColor
    {
        public MensajeEnCamino(SolicitudEnvio solicitudEnvio)
        {
            SolicitudEnvio = solicitudEnvio;
            AsignarColores();
        }

        protected SolicitudEnvio SolicitudEnvio { get; set; }
        public void AsignarColores()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        

        public string ImprimirMensajeEnvio()
        {
            return string.Format("Tu paquete ha salido de {0} y llegará a {1} " +
                "dentro de {2} y tendrá un costo de ${3}" +
                "(Cualquier reclamación con {4}).",SolicitudEnvio.cOrigen ,
               SolicitudEnvio.cDestino,
               SolicitudEnvio.cTiempo, SolicitudEnvio.dCostosEnvio, SolicitudEnvio.cPaqueteria);
        }
        
    }
}