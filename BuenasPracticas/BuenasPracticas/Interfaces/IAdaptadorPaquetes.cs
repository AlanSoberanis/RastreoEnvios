using BuenasPracticas.DTO;
using System.Collections.Generic;

namespace BuenasPracticas.Interfaces
{
    public interface IAdaptadorPaquetes
    {
        void ObtenerPaquetes(ref List<SolicitudEnvio> _lstEnvios);
    }
}
