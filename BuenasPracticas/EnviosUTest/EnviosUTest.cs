using BuenasPracticas.clases;
using BuenasPracticas.DTO;
using BuenasPracticas.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EnviosUTest
{
    [TestClass]
    public class EnviosUTest
    {
        [TestMethod]
        public void ObtenerCostos_FedexTerrestreMesPar_TresMilQuinientos()
        {

            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaqueteria = "Fedex";
            Doc_Solicitudes.cTransporte = "Terrestre";
            Doc_Solicitudes.dDistancia = 250;

            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();

            Doc_Paquete.Setup(x => x.ObtenerUtilidad()).Returns(.40M);
            Doc_Transporte.Setup(x => x.ObtenerCostoEnvio()).Returns(2500M);

            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);
            decimal Respuesta = SUT.ObtenerCostos();

            Assert.AreEqual(3500M, Respuesta);
        }
        [TestMethod]
        public void ObtenerCostos_FedexTerrestreMesInpar_TresMilQuinientos()
        {

            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaqueteria = "Fedex";
            Doc_Solicitudes.cTransporte = "Terrestre";
            Doc_Solicitudes.dDistancia = 250;

            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();

            Doc_Paquete.Setup(x => x.ObtenerUtilidad()).Returns(.30M);
            Doc_Transporte.Setup(x => x.ObtenerCostoEnvio()).Returns(2500M);

            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);
            decimal Respuesta = SUT.ObtenerCostos();

            Assert.AreEqual(3250M, Respuesta);
        }

        [TestMethod]
        public void ProcesarEnvios()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);

            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cOrigen = "Merida,Motul";
            Doc_Solicitudes.cDestino = "Merida,Motul";
            Doc_Solicitudes.cPaqueteria = "Estafeta";
            Doc_Solicitudes.cTransporte = "Terrestre";
            Doc_Solicitudes.dDistancia = 80;
            Doc_Solicitudes.dtFechaEnvio = DateTime.ParseExact("23/01/2020 12:00", "dd/MM/yyyy HH:mm", culture);
            Doc_Solicitudes.dtFechaActual= DateTime.ParseExact("23/01/2020 14:00", "dd/MM/yyyy HH:mm", culture);

            string Respuesta = string.Format("Tu paquete salió de {0} y llegó a {1} " +
              "hace {2} y tuvo un costo de ${3}" +
              "(Cualquier reclamación con {4}).", "Merida,Motul",
              "Merida,Motul",
             "1 Hora", 1160.00M, "Estafeta");


            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();

            Doc_Paquete.Setup(x => x.ObtenerUtilidad()).Returns(.45M);
            Doc_Transporte.Setup(x => x.ObtenerCostoEnvio()).Returns(800M);
            Doc_Transporte.Setup(x => x.ObtenerTiempoEntregaMinutos()).Returns(60M);
            Doc_Paquete.Setup(x => x.ObtenerTiempoRepartoMinutos()).Returns(5M);
            Doc_FormatoTiempo.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("1 Hora");
            Doc_Paquete.Setup(x => x.ObtenerPaqueteria()).Returns("Estafeta");


            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);
            string Mensaje = SUT.ProcesarEnvios();

            Assert.AreEqual(Respuesta, Mensaje);
        }

        [TestMethod]
        public void EstatusEnvio_EnCamino_CambiaColorAmarillo()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);

            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.dtFechaEntrega = DateTime.ParseExact("06/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);
            Doc_Solicitudes.dtFechaActual = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Color = ConsoleColor.Yellow;

            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();

            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);
            SUT.EstatusEnvio();

            Assert.AreEqual(Color, Console.ForegroundColor);
        }

        [TestMethod]
        public void EstatusEnvio_Entregado_CambiaColorVerde()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);

            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.dtFechaEntrega = DateTime.ParseExact("11/04/2020 12:00", "dd/MM/yyyy HH:mm", culture);
            Doc_Solicitudes.dtFechaActual = DateTime.ParseExact("06/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Color = ConsoleColor.Green;

            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();

            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);
            SUT.EstatusEnvio();

            Assert.AreEqual(Color, Console.ForegroundColor);
        }


        [TestMethod]
        public void AsignarSiguiente_ValidaExistencia_ObtieneSiguiente()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);

            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cOrigen = "Merida,Motul";
            Doc_Solicitudes.cDestino = "Merida,Motul";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Fedex";
            Doc_Solicitudes.cTransporte = "Terrestre";
            Doc_Solicitudes.dDistancia = 250;
            Doc_Solicitudes.dtFechaEntrega = DateTime.ParseExact("11/04/2020 12:00", "dd/MM/yyyy HH:mm", culture);
            Doc_Solicitudes.dtFechaActual = DateTime.ParseExact("06/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();

            var Sut = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);
            var DOC_Envios = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);

            Sut.AsignarSiguiente(DOC_Envios);
            Assert.IsInstanceOfType(Sut.Siguiente, typeof(Envios));

        }

        [TestMethod]
        public void GenerarMensaje_Entregado_Mensaje()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cOrigen = "Merida,Motul";
            Doc_Solicitudes.cDestino = "Merida,Motul";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Fedex";


            string Respuesta = string.Format("Tu paquete salió de {0} y llegó a {1} " +
               "hace {2} y tuvo un costo de ${3}" +
               "(Cualquier reclamación con {4}).", "México" + "," + "Merida",
               "México" + "," + "Merida",
              "10 Horas", 480.00M, "Fedex");


            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();
            var Doc_Mensaje = new Mock<IMensajesColor>();
            Doc_Mensaje.Setup(x => x.ImprimirMensajeEnvio()).Returns(Respuesta);
            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);
            SUT.Mensaje = Doc_Mensaje.Object;
            var Mensajes = SUT.GenerarMensaje();

            Assert.AreEqual(Respuesta, Mensajes);
        }

        [TestMethod]
        public void GenerarMensaje_EnCamino_Mensaje()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cOrigen = "Merida,Motul";
            Doc_Solicitudes.cDestino = "Merida,Motul";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Fedex";


            string Respuesta = string.Format("Tu paquete ha salido de {0} y llegará a {1} " +
               "dentro de {2} y tendrá un costo de ${3}" +
               "(Cualquier reclamación con {4}).", "México" + "," + "Merida",
              "México" + "," + "Merida",
             "10 Horas", 480.00M, "Fedex");


            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();
            var Doc_Mensaje = new Mock<IMensajesColor>();
            Doc_Mensaje.Setup(x => x.ImprimirMensajeEnvio()).Returns(Respuesta);

            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);
            SUT.Mensaje = Doc_Mensaje.Object;
            var Mensajes = SUT.GenerarMensaje();

            Assert.AreEqual(Respuesta, Mensajes);
        }

        [TestMethod]
        public void BuscarOtrasOpciones_UnicoExistente_RegresaunRegistro()
        {
            Dictionary<string, decimal> LstPares = new Dictionary<string, decimal>();

            var Doc_Solicitudes = new SolicitudEnvio();
            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();
            var Doc_Mensaje = new Mock<IMensajesColor>();

            Doc_Paquete.Setup(x => x.ObtenerPaqueteria()).Returns("");
            Doc_Transporte.Setup(x => x.ObtenerCostoEnvio()).Returns(2000M);
            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);
            SUT.BuscarOtrasOpciones(ref LstPares);

            Assert.AreEqual(1, LstPares.Count);
            
        }
        [TestMethod]
        public void BuscarOtrasOpciones_ExisteOtraOpcion_RegresaDosRegistros()
        {
            Dictionary<string, decimal> LstPares = new Dictionary<string, decimal>();
            IFormatProvider culture = new CultureInfo("ES-MX", true);

            var Doc_Solicitudes = new SolicitudEnvio();
            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();
            var Doc_TransporteExtra = new Mock<ITransporte>();
            var Doc_PaqueteExtra = new Mock<IPaqueteria>();
            Doc_Paquete.Setup(x => x.ObtenerPaqueteria()).Returns("Fedex");
            Doc_Transporte.Setup(x => x.ObtenerCostoEnvio()).Returns(2000M);
            Doc_PaqueteExtra.Setup(x => x.ObtenerPaqueteria()).Returns("DHL");
            Doc_TransporteExtra.Setup(x => x.ObtenerCostoEnvio()).Returns(1000M);


            var DOC_Envios = new Envios(Doc_PaqueteExtra.Object, Doc_TransporteExtra.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);

           
            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);
            SUT.Siguiente = DOC_Envios;
            SUT.BuscarOtrasOpciones(ref LstPares);

            Assert.AreEqual(2, LstPares.Count);

        }
        [TestMethod]
        public void GenerarMensajeMejorOpcion_Opcionencontrada_MensajeFedexSeiscientos()
        {
           
            var Doc_Solicitudes = new SolicitudEnvio();
            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();
            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);
          string Resultado= SUT.GenerarMensajeMejorOpcion("Fedex", 600);
            Assert.AreEqual("Si hubieras pedido en Fedex te hubiera costado 600 más barato.", Resultado);

        }

        [TestMethod]
        public void ObtenerFechaentrega_DosMarzoOchoPMMasSetentaMinutos_DosMarzoNuevePMDiezminutos()
        {
            
            var Doc_Solicitudes = new SolicitudEnvio();
            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();
            IFormatProvider culture = new CultureInfo("ES-MX", true);

            Doc_Solicitudes.dtFechaEnvio = DateTime.ParseExact("02/03/2020 20:00", "dd/MM/yyyy HH:mm", culture);

            Doc_Transporte.Setup(x => x.ObtenerTiempoEntregaMinutos()).Returns(50M);
            Doc_Paquete.Setup(x => x.ObtenerTiempoRepartoMinutos()).Returns(20M);

            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);

           var Resultado= SUT.ObtenerFechaentrega();

            Assert.AreEqual(DateTime.ParseExact("02/03/2020 21:10", "dd/MM/yyyy HH:mm", culture), Resultado);
        }

        [TestMethod]
        public void ObtenerTiempoEnvio_DosMarzoOchoPMMasSetentaMinutos_DifereciadeUnaHora()
        {

            var Doc_Solicitudes = new SolicitudEnvio();
            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();
            IFormatProvider culture = new CultureInfo("ES-MX", true);

            Doc_Solicitudes.dtFechaEnvio = DateTime.ParseExact("02/03/2020 20:00", "dd/MM/yyyy HH:mm", culture);
            Doc_Solicitudes.dtFechaEntrega = DateTime.ParseExact("02/03/2020 21:10", "dd/MM/yyyy HH:mm", culture);
            Doc_Solicitudes.dtFechaActual = DateTime.ParseExact("02/03/2020 22:10", "dd/MM/yyyy HH:mm", culture);

            Doc_Transporte.Setup(x => x.ObtenerTiempoEntregaMinutos()).Returns(50M);
            Doc_Paquete.Setup(x => x.ObtenerTiempoRepartoMinutos()).Returns(20M);
            Doc_FormatoTiempo.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("1 Hora");

            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);

            var Resultado = SUT.ObtenerTiempoEnvio();

            Assert.AreEqual("1 Hora", Resultado);

        }

        [TestMethod]
        public void SeleccionarOpcion_DHLMilDoscientos_FedexSeiscientos()
        {

            Dictionary<string, decimal> LstOpciones = new Dictionary<string, decimal>() { { "Fedex", 600 }, { "DHL", 1200 } };
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.dCostosEnvio = 1200;
            Doc_Solicitudes.cPaqueteria = "DHL";

            var Doc_Transporte = new Mock<ITransporte>();
            var Doc_Paquete = new Mock<IPaqueteria>();
            var Doc_FormatoTiempo = new Mock<IFormatoTiempo>();
            var SUT = new Envios(Doc_Paquete.Object, Doc_Transporte.Object, Doc_FormatoTiempo.Object, Doc_Solicitudes);

           var Result= SUT.SeleccionarOpcion(ref LstOpciones);

            Assert.AreEqual("\r\nSi hubieras pedido en Fedex te hubiera costado 600 más barato.", Result);
        }
    }
}
