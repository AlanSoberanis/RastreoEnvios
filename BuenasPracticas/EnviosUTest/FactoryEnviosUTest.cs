using BuenasPracticas.clases;
using BuenasPracticas.DTO;
using BuenasPracticas.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnviosUTest
{
    [TestClass]
    public  class FactoryEnviosUTest
    {
        [TestMethod]
        public void FactoryEnvios_FedezTerrestre_ExceptionPaqueteriaNoRegistrada()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaqueteria = "Fedez";
            Doc_Solicitudes.cTransporte = "Terrestre";

            var SUT = Assert.ThrowsException<Exception>(() => new FactoryEnvios(Doc_Solicitudes));
            Assert.AreEqual("La Paquetería: Fedez no se encuentra registrada en nuestra red de distribución.", SUT.Message);
        }

        [TestMethod]
        public void FactoryEnvios_FedexSubmarino_ExceptionTransporteNoRegistrada()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaqueteria = "Fedex";
            Doc_Solicitudes.cTransporte = "Submarino";
            var SUT= Assert.ThrowsException<Exception>(() => new FactoryEnvios(Doc_Solicitudes));
            Assert.AreEqual("Fedex no ofrece el servicio de transporte Submarino, te recomendamos cotizar en otra empresa.", SUT.Message);

        }


        [TestMethod]
        public void CrearEnvio_FedexTerrestre_NoException()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaísOrigen = "México";
            Doc_Solicitudes.cCiudadOrigen = "Merida";
            Doc_Solicitudes.cPaísDestino = "México";
            Doc_Solicitudes.cCiudadDestino = "Merida";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Fedex";
            Doc_Solicitudes.cTransporte = "Terrestre";

            var SUT = new FactoryEnvios(Doc_Solicitudes);
            var Respuesta=SUT.CrearEnvio();
            
            Assert.IsInstanceOfType(Respuesta,typeof(Envios));


        }

        [TestMethod]
        public void CrearEnvio_FedexMarino_NoException()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaísOrigen = "México";
            Doc_Solicitudes.cCiudadOrigen = "Merida";
            Doc_Solicitudes.cPaísDestino = "México";
            Doc_Solicitudes.cCiudadDestino = "Merida";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Fedex";
            Doc_Solicitudes.cTransporte = "Marítimo";

            var SUT = new FactoryEnvios(Doc_Solicitudes);
            var Respuesta = SUT.CrearEnvio();

            Assert.IsInstanceOfType(Respuesta, typeof(Envios));
        }
        [TestMethod]
        public void CrearEnvio_FedexAereo_NoException()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaísOrigen = "México";
            Doc_Solicitudes.cCiudadOrigen = "Merida";
            Doc_Solicitudes.cPaísDestino = "México";
            Doc_Solicitudes.cCiudadDestino = "Merida";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Fedex";
            Doc_Solicitudes.cTransporte = "Aéreo";

            var SUT = new FactoryEnvios(Doc_Solicitudes);
            var Respuesta = SUT.CrearEnvio();

            Assert.IsInstanceOfType(Respuesta, typeof(Envios));
        }

        [TestMethod]
        public void CrearEnvio_DHLTerrestre_NoException()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaísOrigen = "México";
            Doc_Solicitudes.cCiudadOrigen = "Merida";
            Doc_Solicitudes.cPaísDestino = "México";
            Doc_Solicitudes.cCiudadDestino = "Merida";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "DHL";
            Doc_Solicitudes.cTransporte = "Terrestre";

            var SUT = new FactoryEnvios(Doc_Solicitudes);
            var Respuesta = SUT.CrearEnvio();

            Assert.IsInstanceOfType(Respuesta, typeof(Envios));
        }

        [TestMethod]
        public void CrearEnvio_DHLMarino_NoException()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaísOrigen = "México";
            Doc_Solicitudes.cCiudadOrigen = "Merida";
            Doc_Solicitudes.cPaísDestino = "México";
            Doc_Solicitudes.cCiudadDestino = "Merida";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "DHL";
            Doc_Solicitudes.cTransporte = "Marítimo";

            var SUT = new FactoryEnvios(Doc_Solicitudes);
            var Respuesta = SUT.CrearEnvio();

            Assert.IsInstanceOfType(Respuesta, typeof(Envios));
        }

        [TestMethod]
        public void CrearEnvio_DHLAereo_NoException()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaísOrigen = "México";
            Doc_Solicitudes.cCiudadOrigen = "Merida";
            Doc_Solicitudes.cPaísDestino = "México";
            Doc_Solicitudes.cCiudadDestino = "Merida";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "DHL";
            Doc_Solicitudes.cTransporte = "Aéreo";

            var SUT = new FactoryEnvios(Doc_Solicitudes);
            var Respuesta = SUT.CrearEnvio();

            Assert.IsInstanceOfType(Respuesta, typeof(Envios));
        }


        [TestMethod]
        public void CrearEnvio_EstafetaTerrestre_NoException()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaísOrigen = "México";
            Doc_Solicitudes.cCiudadOrigen = "Merida";
            Doc_Solicitudes.cPaísDestino = "México";
            Doc_Solicitudes.cCiudadDestino = "Merida";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Estafeta";
            Doc_Solicitudes.cTransporte = "Terrestre";

            var SUT = new FactoryEnvios(Doc_Solicitudes);
            var Respuesta = SUT.CrearEnvio();

            Assert.IsInstanceOfType(Respuesta, typeof(Envios));
        }

        [TestMethod]
        public void CrearEnvio_EstafetaMarino_NoException()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaísOrigen = "México";
            Doc_Solicitudes.cCiudadOrigen = "Merida";
            Doc_Solicitudes.cPaísDestino = "México";
            Doc_Solicitudes.cCiudadDestino = "Merida";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Estafeta";
            Doc_Solicitudes.cTransporte = "Marítimo";

            var SUT = new FactoryEnvios(Doc_Solicitudes);
            var Respuesta = SUT.CrearEnvio();

            Assert.IsInstanceOfType(Respuesta, typeof(Envios));
        }

    }
}
