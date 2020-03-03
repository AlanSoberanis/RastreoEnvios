using System;

namespace BuenasPracticas.DTO
{
    public class SolicitudEnvio
    {
        public string cTransporte { get; set; }
        public string cTiempo { get; set; }
        public DateTime dtFechaActual { get; set; }
        public DateTime dtFechaEnvio { get; set; }
        public DateTime dtFechaEntrega { get; set; }
        public decimal dDistancia { get; set; }
        public string cOrigen { get; set; }
        public string cDestino { get; set; }
        public decimal dCostosEnvio { get; set; }
        public string cPaqueteria { get;  set; }
        public string cTipotiempo { get; set; }
    }
}