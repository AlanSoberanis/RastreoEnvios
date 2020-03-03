using BuenasPracticas.clases;
using BuenasPracticas.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace EnviosUTest
{
    [TestClass]
   public class MensajeUTest 
    {

        [TestMethod]
       public void AsignarColores_Entregado_Verde()
        {
            var Doc_Solicitudes = new SolicitudEnvio();
            Doc_Solicitudes.cOrigen = "Merida,Motul";
            Doc_Solicitudes.cDestino = "Merida,Motul";
            Doc_Solicitudes.cTiempo = "10 Horas";
            Doc_Solicitudes.dCostosEnvio = 480.00M;
            Doc_Solicitudes.cPaqueteria = "Fedex";
            var Color = ConsoleColor.Green;

            var SUT = new Mensaje(Doc_Solicitudes);
            Assert.AreEqual(Color, Console.ForegroundColor);

        }

        [TestMethod]
        public void ImprimirMensajeEnvio_Entregado_MensajeEntrega()
        {
            var Doc_Solicitudes =new SolicitudEnvio();
            Doc_Solicitudes.cOrigen="México,Merida";
            Doc_Solicitudes.cDestino="México,Merida";
            Doc_Solicitudes.cTiempo="10 Horas";
            Doc_Solicitudes.dCostosEnvio=480.00M;
            Doc_Solicitudes.cPaqueteria="Fedex";

            var SUT = new Mensaje(Doc_Solicitudes);

            string Respuesta= string.Format("Tu paquete salió de {0} y llegó a {1} " +
               "hace {2} y tuvo un costo de ${3}" +
               "(Cualquier reclamación con {4}).", "México" + "," + "Merida",
               "México" + "," + "Merida",
              "10 Horas", 480.00M, "Fedex");


            Assert.AreEqual(Respuesta, SUT.ImprimirMensajeEnvio());

        }
    }
}