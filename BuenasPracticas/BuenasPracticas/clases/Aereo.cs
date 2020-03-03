using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;

namespace BuenasPracticas.clases
{
    public class Aereo : ITransporte
    {
        private readonly decimal dDistancia;
        private readonly DateTime dtFechaEnvio;

        readonly decimal Velocidad = 600M;
        readonly decimal General = 10M;
        readonly decimal distanciaEscala = 1000M;
        readonly decimal CostoEscala = 200M;
        readonly decimal dtiempoEscala =6M;

        public Aereo(decimal dDistancia, DateTime dtFechaEnvio,ConfiguracionAereo configuraciones)
        {
            this.dDistancia = dDistancia;
            this.dtFechaEnvio = dtFechaEnvio;
        }

        public decimal ObtenerCostoEnvio()
        {
            return (dDistancia*ObtenerCostoxDistancia())+ObtenerRecargo();
        }

        public decimal ObtenerCostoxDistancia()
        {
            return General;
        }

        public DateTime ObtenerFechaEnvio()
        {
            return dtFechaEnvio;
        }

        public decimal ObtenerRecargo()
        {
            decimal Escalas = Math.Truncate(dDistancia / distanciaEscala);
            return CostoEscala * Escalas;
        }

        public decimal ObtenerTiempoEntregaMinutos()
        {
            decimal Escalas = Math.Truncate(dDistancia / distanciaEscala);
            Escalas = Escalas * dtiempoEscala;
            decimal Envio = dDistancia / Velocidad;
            decimal Horas = Escalas + Envio;
            return Math.Truncate((Horas*60)*100)/100;
        }

        public decimal ObtenerVelocidad()
        {
            return Velocidad;
        }
    }
}