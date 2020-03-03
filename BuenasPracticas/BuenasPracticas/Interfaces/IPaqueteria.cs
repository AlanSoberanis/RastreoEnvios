using System;
using System.Collections.Generic;
using System.Text;

namespace BuenasPracticas.Interfaces
{
   public interface IPaqueteria
    {
        bool ValidarTransporte();
        decimal ObtenerUtilidad();
        decimal ObtenerTiempoRepartoMinutos();
        string ObtenerPaqueteria();
        string MostrarValidaciontransporte();
    }
}
