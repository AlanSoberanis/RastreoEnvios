using System;
using System.Collections.Generic;
using System.Text;

namespace BuenasPracticas.Interfaces
{
    public interface IBitacora
    {
        void CrearEstructura();
        void GenerarRegistro(string cMensajeEnvio);

    }
}
