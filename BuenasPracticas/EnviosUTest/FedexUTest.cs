using BuenasPracticas.clases;
using BuenasPracticas.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace EnviosUTest
{
    [TestClass]
  public  class FedexUTest
    {

        [TestMethod]
        public void ObtenerTiempoRepartoMinutos_Maritimo_MildocientosSesenta()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Fedex("Marítimo", DateTime.ParseExact("02/03/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerTiempoRepartoMinutos();
            Assert.AreEqual(1260, Resultado);
        }
        public void ObtenerTiempoRepartoMinutos_Aereo_Cero()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Fedex("Aéreo", DateTime.ParseExact("02/03/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerTiempoRepartoMinutos();
            Assert.AreEqual(0, Resultado);
        }

        [TestMethod]
        public void ObtenerTiempoRepartoMinutos_Terrestre_Seiscientos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Fedex("Terrestre", DateTime.ParseExact("02/03/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerTiempoRepartoMinutos();
            Assert.AreEqual(600, Resultado);
        }

        [TestMethod]
        public void ObtenerUtilidad_Par_PuntoCuatro()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Fedex("", DateTime.ParseExact("02/04/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerUtilidad();
            Assert.AreEqual(.40M, Resultado);
        }

        [TestMethod]
        public void ObtenerUtilidad_Impar_PuntoTres()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Fedex("", DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerUtilidad();
            Assert.AreEqual(.30M, Resultado);
        }
        

        [TestMethod]
        public void ValidarTransporte_Terrestre_true()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Fedex("Terrestre", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            bool Resultado = Sut.ValidarTransporte();
            Assert.IsTrue(Resultado);
        }

        [TestMethod]
        public void ValidarTransporte_Aereo_true()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Fedex("Aéreo", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));
            bool Resultado = Sut.ValidarTransporte();
            Assert.IsTrue(Resultado);
        }
        [TestMethod]
        public void ValidarTransporte_Maritimo_true()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Fedex("Marítimo", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));
            bool Resultado = Sut.ValidarTransporte();
            Assert.IsTrue(Resultado);
        }
        [TestMethod]
        public void ValidarTransporte_NoAsignado_false()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Fedex("Submarino", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));
            bool Resultado = Sut.ValidarTransporte();
            Assert.IsFalse(Resultado);
        }

        [TestMethod]
        public void MostrarValidaciontransporte_NoAsignado_MuestraError()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Fedex("Submarino", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));
            string Resultado = Sut.MostrarValidaciontransporte();
            Assert.AreEqual("Fedex no ofrece el servicio de transporte Submarino, te recomendamos cotizar en otra empresa.", Resultado);
        }



        [TestMethod]
        public void ObtenerPaqueteria_General_DevuelveFedex()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Fedex("", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));
            string Resultado = Sut.ObtenerPaqueteria();
            Assert.AreEqual("Fedex", Resultado);
        }
    }
}
