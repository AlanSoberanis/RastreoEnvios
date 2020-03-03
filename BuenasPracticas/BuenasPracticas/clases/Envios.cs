using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuenasPracticas.clases
{
    public class Envios : IEnviosPaquetes
    {
        protected IPaqueteria Paqueteria;
        protected ITransporte Transporte;
        public IFormatoTiempo FormatoTiempo;
        protected SolicitudEnvio solicitudEnvio;
        public IEnviosPaquetes Siguiente;
        private Dictionary<string, decimal> LstOpciones;
        public IMensajesColor Mensaje;
        private string cMensajeEnvio = string.Empty;

        readonly string cPaqueteria;

        public Envios(IPaqueteria _Paqueteria, ITransporte _Transporte, IFormatoTiempo _FormatoTiempo,
        SolicitudEnvio _solicitudEnvio)
        {
            solicitudEnvio = _solicitudEnvio;
            Paqueteria = _Paqueteria;
            cPaqueteria = solicitudEnvio.cPaqueteria;
            FormatoTiempo = _FormatoTiempo;

            this.LstOpciones = new Dictionary<string, decimal>();
            this.Transporte = _Transporte;
        }

        public decimal ObtenerCostos()
        {
            return Math.Round(Transporte.ObtenerCostoEnvio() * (1+Paqueteria.ObtenerUtilidad()), 2);
        }


        public string ProcesarEnvios()
        {
            try
            {
                solicitudEnvio.dCostosEnvio = ObtenerCostos();
                solicitudEnvio.dtFechaEntrega=ObtenerFechaentrega();
                solicitudEnvio.cTiempo=ObtenerTiempoEnvio();
                EstatusEnvio();
                cMensajeEnvio = GenerarMensaje();
                BuscarOtrasOpciones(ref LstOpciones);
                cMensajeEnvio += SeleccionarOpcion(ref LstOpciones);
                return cMensajeEnvio;
            }
            catch (Exception ex)
            {
                Mensaje = new ErrorMensaje();
                throw new Exception(string.Format(Mensaje.ImprimirMensajeEnvio(), ex.Message));
            }
        }

        public void EstatusEnvio()
        {
            if (solicitudEnvio.dtFechaEntrega < solicitudEnvio.dtFechaActual)
            {
                Mensaje = new Mensaje(solicitudEnvio);
            }
            else
            {
                Mensaje = new MensajeEnCamino(solicitudEnvio);
            }
        }

        public void AsignarSiguiente(IEnviosPaquetes _Siguiente)
        {
            this.Siguiente = _Siguiente;
        }

        public string GenerarMensaje()
        {
            return Mensaje.ImprimirMensajeEnvio();
        }


        public void BuscarOtrasOpciones(ref Dictionary<string, decimal> _LstCalculos)
        {
            if (Siguiente != null)
                Siguiente.BuscarOtrasOpciones(ref _LstCalculos);

            _LstCalculos.Add(Paqueteria.ObtenerPaqueteria(), ObtenerCostos());
        }

        public string GenerarMensajeMejorOpcion(string _cPaqueteria, decimal _dCosto)
        {
            return string.Format("Si hubieras pedido en {0} te hubiera costado {1} más barato.", _cPaqueteria, _dCosto);
        }

        public DateTime ObtenerFechaentrega()
        {
            decimal HorasEntrega = Transporte.ObtenerTiempoEntregaMinutos();
            decimal HorasReparto = Paqueteria.ObtenerTiempoRepartoMinutos();
            DateTime dtEntrega = solicitudEnvio.dtFechaEnvio;

            double minutos = double.Parse((Math.Truncate((HorasReparto + HorasEntrega) * 100) / 100).ToString());
            return dtEntrega.AddMinutes(minutos);
        }

        public string ObtenerTiempoEnvio()
        {
            TimeSpan Tiempo = new TimeSpan();
            if (solicitudEnvio.dtFechaEntrega < solicitudEnvio.dtFechaActual)
            {
                Tiempo = solicitudEnvio.dtFechaActual.Subtract(solicitudEnvio.dtFechaEntrega);
            }
            else
            {
                Tiempo = solicitudEnvio.dtFechaEntrega.Subtract(solicitudEnvio.dtFechaActual);
            }

            return FormatoTiempo.ObtenerFormatoTiempo(decimal.Parse(Tiempo.TotalMinutes.ToString()));
        }

        public string SeleccionarOpcion(ref Dictionary<string, decimal> _lstOpciones)
        {
            string cAdicional = string.Empty;
            KeyValuePair<string, decimal> par = _lstOpciones.OrderBy(x => x.Value).FirstOrDefault();
            if (par.Key != cPaqueteria)
            {
                cAdicional= "\r\n" +   GenerarMensajeMejorOpcion(par.Key, solicitudEnvio.dCostosEnvio - par.Value);
            }
            return cAdicional;
        }
    }
}
