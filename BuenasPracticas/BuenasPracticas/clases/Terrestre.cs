using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuenasPracticas.clases
{
    public class Terrestre : ITransporte
    {
        private decimal dDistancia;
        private DateTime dtEnvio;
        decimal Velocidad = 80M;

        List<Temporadas> _lsttemporadas = new List<Temporadas>();
        List<Temporadas> Lsttemporadas
        {
            get
            {
                if (_lsttemporadas.Count == 0)
                {
                    _lsttemporadas = new List<Temporadas>()
                    {
                        new Temporadas() { dtInicio=new DateTime(2020,01,01),dtfin= new DateTime(2020,03,20),dValor=8 },
                        new Temporadas() { dtInicio=new DateTime(2020,03,21),dtfin= new DateTime(2020,06,20),dValor= 4 },
                        new Temporadas() { dtInicio=new DateTime(2020,06,21),dtfin= new DateTime(2020,09,20),dValor=6  },
                        new Temporadas() {  dtInicio=new DateTime(2020,09,21),dtfin= new DateTime(2020,12,20),dValor=5 },
                        new Temporadas() { dtInicio=new DateTime(2020,12,21),dtfin= new DateTime(2020,12,31),dValor=8 }
                    };
                }
                return _lsttemporadas;
            }
        }

        List<Distancia> _LstDistancia = new List<Distancia>();
        private DateTime dtFechaEnvio;
        private ConfiguracionTerrestre configuracionTerrestre;

        List<Distancia> LstDistancia
        {
            get
            {
                if (_LstDistancia.Count == 0)
                {
                    _LstDistancia = new List<Distancia>()
                    {
                        new Distancia(){ dMinimo=1,dMaximo=50,dCosto=15 },
                        new Distancia(){ dMinimo=51,dMaximo=200,dCosto=10 },
                        new Distancia(){ dMinimo=201,dMaximo=300,dCosto=8 },
                        new Distancia(){ dMinimo=301,dMaximo=null,dCosto=7 }
                    };
                }
                return _LstDistancia;
            }
        }

        public Terrestre(decimal _dDistancia, DateTime  _dtEnvio, Configuraciones configuraciones)
        {
            
            this.dDistancia = _dDistancia;
            this.dtEnvio = _dtEnvio;
        }

        public Terrestre(decimal dDistancia, DateTime dtFechaEnvio, ConfiguracionTerrestre configuracionTerrestre)
        {
            this.dDistancia = dDistancia;
            this.dtFechaEnvio = dtFechaEnvio;
            this.configuracionTerrestre = configuracionTerrestre;
        }

        public decimal ObtenerCostoxDistancia()
        {
            var Costo=LstDistancia.FirstOrDefault(x=>x.dMinimo<=dDistancia && ((x.dMaximo == null) || x.dMaximo >= dDistancia));
            return Costo!=null? Costo.dCosto : 0M;
        }

        public decimal ObtenerCostoEnvio()
        {
            return (dDistancia * ObtenerCostoxDistancia()) + ObtenerRecargo();
        }

        public DateTime ObtenerFechaEnvio()
        {
            return dtEnvio;
        }

        public decimal ObtenerRecargo()
        {
            decimal Adicional=0;
            return Adicional;
        }

        public decimal ObtenerTiempoEntregaMinutos()
        {
            var Tiempo = Lsttemporadas.FirstOrDefault(x => x.dtInicio.Date <= dtEnvio.Date && (x.dtfin.Date >= dtEnvio.Date));
            decimal dTiempoTransporte = dDistancia / ObtenerVelocidad();
            decimal dDias = Math.Truncate(dTiempoTransporte/24);
            decimal dTimepoAdicional= (Tiempo != null ? Tiempo.dValor : 0M)*dDias;
            
            return (dTiempoTransporte + dTimepoAdicional)*60;
        }

        public decimal ObtenerVelocidad()
        {
            return Velocidad;
        }
    }
}