using BuenasPracticas.clases;
using BuenasPracticas.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnviosUTest
{
    [TestClass]
   public class ErrorMensajeUTest
    {
        [TestMethod]
        public void AsignarColores_Error_Rojo()
        {
            var Color= ConsoleColor.Red; 
            var SUT=new ErrorMensaje();
            Assert.AreEqual(Color,Console.ForegroundColor);
            
        }

        [TestMethod]
        public void ImprimirMensajeEnvio_Error_MensjaeError()
        {
            var SUT = new ErrorMensaje();
            string Respuesta = "{0}";
            Assert.AreEqual(Respuesta, SUT.ImprimirMensajeEnvio());

        }
    }
}