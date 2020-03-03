using BuenasPracticas.clases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace EnviosUTest
{
    [TestClass]
    public class DHLUTest
    {

        [TestMethod]
        public void ObtenerTiempoRepartoMinutos_CalculoTerrestre_SetecientosVeinte()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new DHL("Terrestre", DateTime.ParseExact("02/03/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerTiempoRepartoMinutos();
            Assert.AreEqual(720, Resultado);
        }

        [TestMethod]
        public void ObtenerTiempoRepartoMinutos_CalculoMaritimo_MilDocientos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new DHL("Marítimo", DateTime.ParseExact("02/03/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerTiempoRepartoMinutos();
            Assert.AreEqual(1200, Resultado);
        }

        [TestMethod]
        public void ObtenerTiempoRepartoMinutos_CalculoAereo_CientoOchenta()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new DHL("Aéreo", DateTime.ParseExact("02/03/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerTiempoRepartoMinutos();
            Assert.AreEqual(180, Resultado);
        }

        [TestMethod]
        public void ObtenerUtilidad_PrimerSemestre_PuntoCinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new DHL("", DateTime.ParseExact("02/03/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerUtilidad();
            Assert.AreEqual(.50M, Resultado);
        }

        [TestMethod]
        public void ObtenerUtilidad_SegundoSemestre_PuntoTres()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new DHL("", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerUtilidad();
            Assert.AreEqual(.30M, Resultado);
        }

        [TestMethod]
        public void ValidarTransporte_Terrestre_true()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new DHL("Terrestre", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            bool Resultado = Sut.ValidarTransporte();
            Assert.IsTrue(Resultado);
        }
        [TestMethod]
        public void ValidarTransporte_Aereo_true()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new DHL("Aéreo", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));
            bool Resultado = Sut.ValidarTransporte();
            Assert.IsTrue(Resultado);
        }
        [TestMethod]
        public void ValidarTransporte_Maritimo_true()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new DHL("Marítimo", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));
            bool Resultado = Sut.ValidarTransporte();
            Assert.IsTrue(Resultado);
        }
        [TestMethod]
        public void ValidarTransporte_NoAsignado_false()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new DHL("Submarino", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));
            bool Resultado = Sut.ValidarTransporte();
            Assert.IsFalse(Resultado);
        }

        [TestMethod]
        public void MostrarValidaciontransporte_NoAsignado_MuestraError()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new DHL("Submarino", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));
            string Resultado = Sut.MostrarValidaciontransporte();
            Assert.AreEqual("DHL no ofrece el servicio de transporte Submarino, te recomendamos cotizar en otra empresa.", Resultado);
        }



        [TestMethod]
       public void ObtenerPaqueteria_General_DevuelveDHL()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new DHL("", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture));
            string Resultado = Sut.ObtenerPaqueteria();
            Assert.AreEqual("DHL", Resultado);
        }
    }
}
