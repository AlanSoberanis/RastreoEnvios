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
            Doc_Solicitudes.cOrigen = "Merida,Motul";
            Doc_Solicitudes.cDestino = "Merida,Motul";
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
            Doc_Solicitudes.cOrigen = "Merida,Motul";
            Doc_Solicitudes.cDestino = "Merida,Motul";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Fedex";

            var SUT = new MensajeEnCamino(Doc_Solicitudes);

            string Respuesta = string.Format("Tu paquete ha salido de {0} y llegará a {1} " +
                "dentro de {2} y tendrá un costo de ${3}" +
                "(Cualquier reclamación con {4}).", "Merida,Motul",
               "Merida,Motul",
              "10 Horas", 480.00M, "Fedex");


            Assert.AreEqual(Respuesta, SUT.ImprimirMensajeEnvio());

        }
    }
}