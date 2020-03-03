using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuenasPracticas.clases
{
    public class Maritimo : ITransporte
    {
        private readonly decimal dDistancia;
        private readonly DateTime dtFechaEnvio;
        readonly decimal Velocidad = 46M;

        List<Temporadas> _lsttemporadasCosto = new List<Temporadas>();
        List<Temporadas> LsttemporadasCosto
        {
            get
            {
                if (_lsttemporadasCosto.Count == 0)
                {
                    _lsttemporadasCosto = new List<Temporadas>()
                    {
                        new Temporadas() { dtInicio = new DateTime(2019, 12, 21),dtfin = new DateTime(2020, 3, 19),dValor = 0.23M },
                new Temporadas() { dtInicio = new DateTime(2020, 3, 1),dtfin = new DateTime(2020, 6, 20),dValor = 0 },
                new Temporadas() { dtInicio = new DateTime(2020, 6, 21),dtfin = new DateTime(2020, 9, 20),dValor = 0.10M  },
                new Temporadas() { dtInicio = new DateTime(2020, 9, 21),dtfin = new DateTime(2020, 12, 20),dValor = 0.15M },
                new Temporadas() { dtInicio = new DateTime(2020, 12, 21),dtfin = new DateTime(2021, 3, 20),dValor = 0.23M }};
                }
                return _lsttemporadasCosto;
            }
        }
        List<Temporadas> _lsttemporadasVelocidad = new List<Temporadas>();
        List<Temporadas> LsttemporadasVelocidad
        {
            get
            {
                if (_lsttemporadasVelocidad.Count == 0)
                {
                    _lsttemporadasVelocidad = new List<Temporadas>()
                    {
                new Temporadas() { dtInicio = new DateTime(2019, 12, 21),dtfin = new DateTime(2020, 3, 19),dValor = -0.30M },
                new Temporadas() { dtInicio = new DateTime(2020, 3, 1),dtfin = new DateTime(2020, 6, 20),dValor = 0 },
                new Temporadas() { dtInicio = new DateTime(2020, 6, 21),dtfin = new DateTime(2020, 9, 20),dValor = -0.10M  },
                new Temporadas() { dtInicio = new DateTime(2020, 9, 21),dtfin = new DateTime(2020, 12, 20),dValor = 0.15M },
                new Temporadas() { dtInicio = new DateTime(2020, 12, 21),dtfin = new DateTime(2021, 3, 20),dValor = -0.30M }            };
                }
                return _lsttemporadasVelocidad;
            }
        }

        List<Distancia> _LstDistancia = new List<Distancia>();
        List<Distancia> LstDistancia
        {
            get
            {
                if (_LstDistancia.Count == 0)
                {
                    _LstDistancia = new List<Distancia>()
                    {
                new Distancia(){ dMinimo=1,dMaximo=100,dCosto=1 },
                new Distancia(){ dMinimo=101,dMaximo=1000,dCosto=.5M },
                new Distancia(){ dMinimo=1001,dMaximo=null,dCosto=.3M }
            };
                }
                return _LstDistancia;
            }
        }


        public Maritimo(decimal dDistancia, DateTime dtFechaEnvio, ConfiguracionMaritimo configuraciones)
        {
            this.dDistancia = dDistancia;
            this.dtFechaEnvio = dtFechaEnvio;
            //LstDistancia = configuraciones.Distancias;
        }

        public decimal ObtenerCostoEnvio()
        {
            return (dDistancia * ObtenerCostoxDistancia()) + ObtenerRecargo();
        }

        public decimal ObtenerCostoxDistancia()
        {
            decimal dCosto = LstDistancia.FirstOrDefault(x => x.dMinimo <= dDistancia && ((x.dMaximo == null) || x.dMaximo >= dDistancia)).dCosto;
            return dCosto;
        }

        public DateTime ObtenerFechaEnvio()
        {
            return dtFechaEnvio;
        }

        public decimal ObtenerRecargo()
        {
            var Costo = LsttemporadasCosto.FirstOrDefault(x => x.dtInicio.Date <= dtFechaEnvio.Date && ( x.dtfin.Date >= dtFechaEnvio.Date));

            decimal dCosto=Costo != null ? Costo.dValor : 0M;

            return (dDistancia * ObtenerCostoxDistancia()) * dCosto;

        }

        public decimal ObtenerTiempoEntregaMinutos()
        {
            var VelocidadT = LsttemporadasVelocidad.FirstOrDefault(x => x.dtInicio.Date <= dtFechaEnvio && (x.dtfin.Date >= dtFechaEnvio.Date));
            decimal dAjusteVelocidad = VelocidadT != null ? VelocidadT.dValor : 1M;
            decimal dVelocidad = ObtenerVelocidad();
            dVelocidad += (dAjusteVelocidad * dVelocidad);
            decimal Horas = (dDistancia / dVelocidad);
            return Math.Truncate((Horas*60)*100)/100;
        }

        public decimal ObtenerVelocidad()
        {
            return Velocidad;
        }
    }
}