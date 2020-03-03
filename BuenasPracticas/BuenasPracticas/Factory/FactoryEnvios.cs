using BuenasPracticas.clases;
using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using System;
using System.Collections.Generic;

namespace BuenasPracticas.Factory
{
    public class FactoryEnvios
    {

        readonly IPaqueteria Paqueteria;
        readonly ITransporte Transporte;
        readonly List<IPaqueteria> PaqueteriaCompetencia;
        readonly IFormatoTiempo Tiempos;
        readonly IMensajesColor Mensajes;
        readonly SolicitudEnvio SolicitudEnvio;

        public FactoryEnvios(SolicitudEnvio _solicitudEnvio, ConfiguracionesDTO _configuraciones)
        {
            SolicitudEnvio = _solicitudEnvio;
            PaqueteriaCompetencia = new List<IPaqueteria>();
            Tiempos = crearformatosTiempo();
            Mensajes = new ErrorMensaje();

            switch (SolicitudEnvio.cPaqueteria)
            {
                case "Fedex":
                    Paqueteria = new Fedex(SolicitudEnvio.cTransporte, SolicitudEnvio.dtFechaEnvio,_configuraciones.ConfiguracionFedex);
                    PaqueteriaCompetencia.Add(new DHL(SolicitudEnvio.cTransporte, SolicitudEnvio.dtFechaEnvio, _configuraciones.ConfiguracionDHL));
                    PaqueteriaCompetencia.Add(new Estafeta(SolicitudEnvio.cTransporte, SolicitudEnvio.dtFechaEnvio, _configuraciones.ConfiguracionEstafeta));
                    break;

                case "DHL":
                    Paqueteria = new DHL(SolicitudEnvio.cTransporte, SolicitudEnvio.dtFechaEnvio, _configuraciones.ConfiguracionDHL);
                    PaqueteriaCompetencia.Add(new Fedex(SolicitudEnvio.cTransporte, SolicitudEnvio.dtFechaEnvio, _configuraciones.ConfiguracionFedex));
                    PaqueteriaCompetencia.Add(new Estafeta(SolicitudEnvio.cTransporte, SolicitudEnvio.dtFechaEnvio, _configuraciones.ConfiguracionEstafeta));

                    break;

                case "Estafeta":
                    Paqueteria = new Estafeta(SolicitudEnvio.cTransporte, SolicitudEnvio.dtFechaEnvio,_configuraciones.ConfiguracionEstafeta);
                    PaqueteriaCompetencia.Add(new Fedex(SolicitudEnvio.cTransporte, SolicitudEnvio.dtFechaEnvio, _configuraciones.ConfiguracionFedex));
                    PaqueteriaCompetencia.Add(new DHL(SolicitudEnvio.cTransporte, SolicitudEnvio.dtFechaEnvio, _configuraciones.ConfiguracionDHL));

                    break;
                default:
                    throw new Exception(string.Format(Mensajes.ImprimirMensajeEnvio(), MostrarValidacionPaqueteria()));
                    break;
            }

            if (!Paqueteria.ValidarTransporte())
            {
                throw new Exception(string.Format(Mensajes.ImprimirMensajeEnvio(), MostrarValidaciontransporte()));
            }

                switch (SolicitudEnvio.cTransporte)
            {
                case "Marítimo":
                    Transporte = new Maritimo(SolicitudEnvio.dDistancia, SolicitudEnvio.dtFechaEnvio,_configuraciones.ConfiguracionMaritimo);
                    break;

                case "Terrestre":
                    Transporte = new Terrestre(SolicitudEnvio.dDistancia, SolicitudEnvio.dtFechaEnvio, _configuraciones.ConfiguracionTerrestre);
                    break;

                case "Aéreo":
                    Transporte = new Aereo(SolicitudEnvio.dDistancia, SolicitudEnvio.dtFechaEnvio, _configuraciones.ConfiguracionAereo);
                    break;
                default:
                    throw new Exception(string.Format(Mensajes.ImprimirMensajeEnvio() , MostrarValidaciontransporte()));
                    break;
            }

        }


        private IFormatoTiempo crearformatosTiempo()
        {
            Minutos FormatoMinutos = new Minutos();
            Horas FormatoHoras = new Horas();
            Dias FormatoDias = new Dias();
            Semanas FormatoSemanas = new Semanas();
            Meses FormatoMeses = new Meses();
            Bimestres FormatoBimenstres = new Bimestres();
            Anios FormatoAnios = new Anios();
            
            FormatoBimenstres.Siguiente(FormatoAnios);
            FormatoMeses.Siguiente(FormatoBimenstres);
            FormatoSemanas.Siguiente(FormatoMeses);
            FormatoDias.Siguiente(FormatoSemanas);
            FormatoHoras.Siguiente(FormatoDias);
            FormatoMinutos.Siguiente(FormatoHoras);

            return FormatoMinutos;
        }

        public IEnviosPaquetes CrearEnvio()
        {
            

            Envios envios = new Envios(Paqueteria, Transporte, Tiempos, SolicitudEnvio);

            IEnviosPaquetes Envioanterior = envios;
            foreach (IPaqueteria Paquete in PaqueteriaCompetencia)
            {

                if (Paquete.ValidarTransporte())
                {
                    IEnviosPaquetes Nuevocompetidor = new Envios(Paquete, Transporte, Tiempos, SolicitudEnvio);
                    Envioanterior.AsignarSiguiente(Nuevocompetidor);
                    Envioanterior = Nuevocompetidor;
                }
            }
            return envios;
        }




        private string MostrarValidacionPaqueteria()
        {
            return string.Format("La Paquetería: {0} no se encuentra registrada en nuestra red de distribución.", SolicitudEnvio.cPaqueteria);

        }

        private bool Validartransporte()
        {
            return Paqueteria.ValidarTransporte();
        }

        private string MostrarValidaciontransporte()
        {
            return Paqueteria.MostrarValidaciontransporte();
        }
        
    }

}
