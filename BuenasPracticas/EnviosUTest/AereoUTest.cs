using BuenasPracticas.clases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace EnviosUTest
{
    [TestClass]
    public class AereoUTest
    {
        [TestMethod]
        public void ObtenerCostoxDistancia_CuatroMil_Diez()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Aereo(4000, FechaEnvio);

            decimal Resultado = Sut.ObtenerCostoxDistancia();
            Assert.AreEqual(10, Resultado);
        }

        [TestMethod]
        public void ObtenerCostoEnvio_CuatroMil_CuarentaMilOchocientos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Aereo(4000, FechaEnvio);
            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(40800, Resultado);
        }


        [TestMethod]
        public void ObtenerFechaEnvio_General_FechaEnviada()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);
            var Sut = new Aereo(4000, FechaEnvio);
            DateTime Resultado = Sut.ObtenerFechaEnvio();
            Assert.AreEqual(FechaEnvio, Resultado);
        }

        [TestMethod]
        public void ObtenerRecargo_CuatroMil_Ochocientos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Aereo(4000, DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(800, Resultado);
        }


        [TestMethod]
        void ObtenerTiempoEntregaMinutos_CuatroMil()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Aereo(4000, DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(0, Resultado);
        }


        [TestMethod]
        public void ObtenerVelocidad_Seiscientos_Seiscientos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Aereo(4000, DateTime.ParseExact("02/03/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerVelocidad();
            Assert.AreEqual(600, Resultado);
        }
    }
}