using BuenasPracticas.clases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace EnviosUTest
{
    [TestClass]
    public class TerrestreUTest
    {
       
        [TestMethod]
        public void ObtenerCostoxDistancia_Cuarenta_Quince()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Terrestre(40, FechaEnvio);

            decimal Resultado = Sut.ObtenerCostoxDistancia();
            Assert.AreEqual(15, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoxDistancia_Noventa_Diez()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Terrestre(90, FechaEnvio);


            decimal Resultado = Sut.ObtenerCostoxDistancia();
            Assert.AreEqual(10, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoxDistancia_DoscientosCincuenta_Ocho()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Terrestre(250, FechaEnvio);

            decimal Resultado = Sut.ObtenerCostoxDistancia();
            Assert.AreEqual(8, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoxDistancia_Quinientos_Sietes()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Terrestre(500, FechaEnvio);


            decimal Resultado = Sut.ObtenerCostoxDistancia();
            Assert.AreEqual(7, Resultado);
        }


        [TestMethod]
        public void ObtenerCostoEnvio_Cuarenta_Seiscientos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Terrestre(40, FechaEnvio);

            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(600, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_Noventa_Novecientos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Terrestre(90, FechaEnvio);


            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(900, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_DoscientosCincuenta_DosMil()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Terrestre(250, FechaEnvio);


            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(2000, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_Quinientos_TresMilQuinientos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Terrestre(500, FechaEnvio);


            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(3500, Resultado);
        }

        
        [TestMethod]
        public void ObtenerFechaEnvio_General_FechaEnviada()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Terrestre(8000, FechaEnvio);

            DateTime Resultado = Sut.ObtenerFechaEnvio();
            Assert.AreEqual(FechaEnvio, Resultado);
        }

        [TestMethod]
        public void ObtenerRecargo_General_Cero()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Terrestre(8000, DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(0, Resultado);
        }

        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_OchocientosPrimavera_SeisMilNovecientosSesenta()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Terrestre(8000, DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(6960, Resultado);
        }
        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_OchocientosVerano_SieteMilCuatrocientosCuarenta()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Terrestre(8000, DateTime.ParseExact("02/08/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(7440, Resultado);
        }
        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_OchocientosOtonio_sieteMilDocientos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Terrestre(8000, DateTime.ParseExact("02/11/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(7200, Resultado);
        }
        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_OchocientosInvierno_SieteMilNovecientosVeinte()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Terrestre(8000, DateTime.ParseExact("02/01/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(7920, Resultado);
        }

        [TestMethod]
        public void ObtenerVelocidad_Ochenta_Ochenta()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Terrestre(8000, DateTime.ParseExact("02/03/2020 12:00", "dd/MM/yyyy HH:mm", culture));

            decimal Resultado = Sut.ObtenerVelocidad();
            Assert.AreEqual(80, Resultado);
        }
    }
}