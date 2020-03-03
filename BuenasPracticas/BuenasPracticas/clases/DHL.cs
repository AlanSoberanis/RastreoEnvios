using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuenasPracticas.clases
{
    public class DHL : IPaqueteria
    {

        readonly string cTransporte;
        readonly string cEmpresa;
        readonly DateTime dtFechaEnvio;

        public DHL(string _cTransporte, DateTime _dtFechaEnvio, ConfiguracionDHL configuraciones)
        {
            cTransporte = _cTransporte;
            cEmpresa = "DHL";
            dtFechaEnvio = _dtFechaEnvio;
        }

        private List<Temporadas> _Ganancias =new List<Temporadas>();
        private List<string> _Transportes=new List<string>();
        Dictionary<string, decimal> _lstRepartos = new Dictionary<string, decimal>();

        private List<Temporadas> Ganancias
        { get {
                if (_Ganancias.Count == 0)
                { _Ganancias = new List<Temporadas>()
            {
                new Temporadas() { dtInicio=new DateTime(2020,01,01),dtfin= new DateTime(2020,06,30),dValor=.50M  },
                new Temporadas() { dtInicio=new DateTime(2020,07,01),dtfin= new DateTime(2020,12,31),dValor= .30M }
            };
                }
                return _Ganancias; }
        }

        private List<string> Transportes
        {
            get
            {
                if (_Transportes.Count == 0)
                {
                    _Transportes = new List<string> { { "Marítimo" }, { "Terrestre" }, { "Aéreo" } };
                }
                return _Transportes;
            }
        }

        private Dictionary<string, decimal> LstRepartos
        {
            get
            {
                if (!_lstRepartos.Any())
                {
                    _lstRepartos = new Dictionary<string, decimal>() {
                    {"Marítimo",20 },
                    { "Terrestre",12 },
                    { "Aéreo",3 }};
                }
                return _lstRepartos;
            }
        }


        public decimal ObtenerTiempoRepartoMinutos()
        {
            var Repartos = LstRepartos.FirstOrDefault(x => x.Key == cTransporte);
            return Repartos.Key != "" ? Repartos.Value*60 : 0M;
        }

        public decimal ObtenerUtilidad()
        {
            var Ganancia = Ganancias.FirstOrDefault(x => x.dtInicio.Date <= dtFechaEnvio.Date && (x.dtfin.Date >= dtFechaEnvio.Date));
            return Ganancia != null ? Ganancia.dValor : 0M;
        }

        public bool ValidarTransporte()
        {
            return Transportes.Contains(cTransporte);
        }

        public string MostrarValidaciontransporte()
        {
            return string.Format("{0} no ofrece el servicio de transporte {1}, te recomendamos cotizar en otra empresa.", cEmpresa, cTransporte);
        }

        public string ObtenerPaqueteria()
        {
            return cEmpresa;
        }
        
    }
}
