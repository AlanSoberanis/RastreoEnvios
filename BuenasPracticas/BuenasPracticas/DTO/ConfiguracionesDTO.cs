using System;
using System.Collections.Generic;
using System.Text;

namespace BuenasPracticas.DTO
{
   public class ConfiguracionesDTO
    {
        public ConfiguracionMaritimo ConfiguracionMaritimo { get; set; }
        public ConfiguracionTerrestre ConfiguracionTerrestre { get; set; }
        public ConfiguracionAereo ConfiguracionAereo { get; set; }
        public ConfiguracionEstafeta ConfiguracionEstafeta { get; set; }
        public ConfiguracionFedex ConfiguracionFedex { get; set; }
        public ConfiguracionDHL ConfiguracionDHL { get; set; }
    }
}
