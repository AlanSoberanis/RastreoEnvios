using BuenasPracticas.clases;
using BuenasPracticas.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnviosUTest
{
    [TestClass]
    public class MensajeEnCaminoUTest 
    {

        [TestMethod]
        public void AsignarColores()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaísOrigen = "México";
            Doc_Solicitudes.cCiudadOrigen = "Merida";
            Doc_Solicitudes.cPaísDestino = "México";
            Doc_Solicitudes.cCiudadDestino = "Merida";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Fedex";
            var Color = ConsoleColor.Yellow;

            var SUT = new MensajeEnCamino(Doc_Solicitudes);
            Assert.AreEqual(Color, Console.ForegroundColor);

        }

        [TestMethod]
        public void ImprimirMensajeEnvio()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cPaísOrigen = "México";
            Doc_Solicitudes.cCiudadOrigen = "Merida";
            Doc_Solicitudes.cPaísDestino = "México";
            Doc_Solicitudes.cCiudadDestino = "Merida";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Fedex";

            var SUT = new MensajeEnCamino(Doc_Solicitudes);

            string Respuesta = string.Format("Tu paquete ha salido de {0} y llegará a {1} " +
                "dentro de {2} y tendrá un costo de ${3}" +
                "(Cualquier reclamación con {4}).", "México" + "," + "Merida",
               "México" + "," + "Merida",
              "10 Horas", 480.00M, "Fedex");


            Assert.AreEqual(Respuesta, SUT.ImprimirMensajeEnvio());

        }
    }
}