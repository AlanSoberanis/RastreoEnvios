using System;
using System.Collections.Generic;

namespace BuenasPracticas.clases
{
    public interface IEnviosPaquetes
    {
        void BuscarOtrasOpciones(ref Dictionary<string, decimal> lstCalculos);
        decimal ObtenerCostos();
        string ProcesarEnvios();
        void EstatusEnvio();
        string GenerarMensaje();
        void AsignarSiguiente(IEnviosPaquetes _Siguiente);
        string GenerarMensajeMejorOpcion(string _cPaqueteria, decimal _dCosto);
        DateTime ObtenerFechaentrega();
        string ObtenerTiempoEnvio();
        string SeleccionarOpcion(ref Dictionary<string, decimal> lstCalculos);
    }
}