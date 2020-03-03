using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuenasPracticas.clases
{
    public class Fedex : IPaqueteria
    {

        readonly string cTransporte;
        readonly string cEmpresa;
        readonly DateTime dtFechaEnvio;
        public Fedex(string _cTransporte,DateTime _dtFechaEnvio, ConfiguracionFedex configuraciones)
        {
            cTransporte = _cTransporte;
            cEmpresa = "Fedex";
            dtFechaEnvio = _dtFechaEnvio;
        }

        private Dictionary<int, decimal> _Ganancias=new Dictionary<int, decimal>();
        private List<string> _Transportes=new List<string>();
       

        private Dictionary<int, decimal> Ganancias
        { get {
                if (_Ganancias.Count == 0)
                { _Ganancias = new Dictionary<int, decimal>() { { 1, .3M } ,
                    { 2, .4M } ,
                    { 3, .3M } ,
                    { 4, .4M } ,
                    { 5, .3M } ,
                    { 6, .4M } ,
                    { 7, .3M } ,
                    { 8, .4M } ,
                    { 9, .3M } ,
                    { 10, .4M } ,
                    { 11, .3M } ,
                    { 12, .4M } }; }
                return _Ganancias; }
        }

        private List<string> Transportes
        { get
            {
                if (_Transportes.Count == 0)
                {
                    _Transportes = new List<string> { { "Marítimo" }, { "Terrestre" }, { "Aéreo" } };
                }
                return _Transportes; }
            }

        public Dictionary<string, decimal> LstRepartos = new Dictionary<string, decimal>() {
            {"Marítimo",21M },
            { "Terrestre",10M },
            { "Aéreo",0M }
        };


        public decimal ObtenerTiempoRepartoMinutos()
        {
            var Repartos = LstRepartos.FirstOrDefault(x=>x.Key==cTransporte);
            return Repartos.Key != "" ? Repartos.Value *60: 0M;
        }

        public decimal ObtenerUtilidad()
        {
            int iMonth = dtFechaEnvio.Month;
            var Ganancia = Ganancias.FirstOrDefault(x => x.Key==iMonth);
            return Ganancia.Key!=0? Ganancia.Value : 0M;
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
