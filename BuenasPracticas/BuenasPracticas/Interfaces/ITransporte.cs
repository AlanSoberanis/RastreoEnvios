using System;
using System.Collections.Generic;
using System.Text;

namespace BuenasPracticas.Interfaces
{
    public interface ITransporte
    {
        decimal ObtenerCostoxDistancia();
        decimal ObtenerVelocidad();
        decimal ObtenerCostoEnvio();
        decimal ObtenerTiempoEntregaMinutos();
        decimal ObtenerRecargo();
        DateTime ObtenerFechaEnvio();
    }
}
