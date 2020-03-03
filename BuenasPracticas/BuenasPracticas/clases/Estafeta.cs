using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuenasPracticas.clases
{
    public class Estafeta : IPaqueteria
    {

        readonly string cTransporte;
        readonly string cEmpresa;
        readonly DateTime dtFechaEnvio;
        public Estafeta(string _cTransporte,DateTime _dtFechaEnvio)
        {
            cTransporte = _cTransporte;
            cEmpresa = "Estafeta";
            dtFechaEnvio = _dtFechaEnvio;
        }

        private List<Temporadas> _Ganancias =new List<Temporadas>();
        private List<string> _Transportes=new List<string>();
        private readonly decimal dReparto=5;

        private List<Temporadas> Ganancias
        { get {
                if (_Ganancias.Count == 0)
                { _Ganancias = new List<Temporadas>()
            {
                new Temporadas() { dtInicio=new DateTime(2020,12,01),dtfin= new DateTime(2020,12,31),dValor= .10M },
                new Temporadas() { dtInicio=new DateTime(2020,02,14),dtfin= new DateTime(2020,02,14),dValor=.50M },
                 new Temporadas() { dtInicio=new DateTime(2020,01,01),dtfin= new DateTime(2020,02,13),dValor= .45M },
                new Temporadas() { dtInicio=new DateTime(2020,02,15),dtfin= new DateTime(2020,12,31),dValor=.45M }
            };
                }
                return _Ganancias; }
        }

        public List<string> Transportes
        { get
            {
                if (_Transportes.Count == 0)
                {
                    _Transportes = new List<string> { { "Marítimo" }, { "Terrestre" } };
                }
                return _Transportes; }
            }

        public decimal ObtenerTiempoRepartoMinutos()
        {
            return dReparto;
        }

        public decimal ObtenerUtilidad()
        {
            var Ganancia = Ganancias.FirstOrDefault(x => x.dtInicio.Date <= dtFechaEnvio.Date && (x.dtfin.Date >= dtFechaEnvio.Date));
            return Ganancia!=null?Ganancia.dValor:0M;
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
