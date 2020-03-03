using BuenasPracticas.clases;
using BuenasPracticas.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace EnviosUTest
{
    [TestClass]
   public class MaritimoUTest 
    {
        ConfiguracionMaritimo configuraciones = new ConfiguracionMaritimo();

        [TestMethod]
        public void ObtenerCostoxDistancia_Cuarenta_Uno()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerCostoxDistancia();
            Assert.AreEqual(1, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoxDistancia_Quinientos_PuntoCinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerCostoxDistancia();
            Assert.AreEqual(.50M, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoxDistancia_MilDosientos_PuntoTres()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerCostoxDistancia();
            Assert.AreEqual(.30M, Resultado);
        }


        [TestMethod]
        public void ObtenerCostoEnvio_CuarentaPrimavera_Cuarenta()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(40M, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_QuinientosPrimavera_DoscientosCincuenta()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(250M, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_MilDosientosPrimavera_TrescientosSesenta()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(360M, Resultado);
        }


        [TestMethod]
        public void ObtenerCostoEnvio_CuarentaVerano_CuarentayCuatro()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/07/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(44M, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_QuinientosVerano_DoscientosSetentayCinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/07/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(275M, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_MilDosientosVerano_TrescientosNoventayseis()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/07/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);
            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(396M, Resultado);
        }

        [TestMethod]
        public void ObtenerCostoEnvio_CuarentaOtonio_Cuarentayseis()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/11/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(46M, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_QuinientosOtonio_DoscientosOchentaySietePuntoCinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/11/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(287.50M, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_MilDosientosOtonio_CuatrocientosCatorce()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/11/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);
            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(414M, Resultado);
        }

        [TestMethod]
        public void ObtenerCostoEnvio_CuarentaInvierno_CuarentayNuevePuntoDos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/01/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(49.20M, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_QuinientosInvierno_TrescientosSietePuntoCinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/01/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(307.50M, Resultado);
        }
        [TestMethod]
        public void ObtenerCostoEnvio_MilDosientosInvierno_CuatrocientosCuarentayDosPuntoOcho()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/01/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);
            decimal Resultado = Sut.ObtenerCostoEnvio();
            Assert.AreEqual(442.80M, Resultado);
        }

        [TestMethod]
        public void ObtenerFechaEnvio_General_FechaEnviada()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);

            DateTime Resultado = Sut.ObtenerFechaEnvio();
            Assert.AreEqual(FechaEnvio, Resultado);
        }

        
        [TestMethod]
        public void ObtenerRecargo_CuarentaPrimavera_cero()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(0M, Resultado);
        }
        [TestMethod]
        public void ObtenerRecargo_QuinientosPrimavera_Cero()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(0M, Resultado);
        }
        [TestMethod]
        public void ObtenerRecargo_MilDosientosPrimavera_Cero()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(0M, Resultado);
        }


        [TestMethod]
        public void ObtenerRecargo_CuarentaVerano_Cuatro()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/07/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(4M, Resultado);
        }
        [TestMethod]
        public void ObtenerRecargo_QuinientosVerano_VeintiCinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/07/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(25M, Resultado);
        }
        [TestMethod]
        public void ObtenerRecargo_MilDosientosVerano_TreintaySeis()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/07/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);
            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(36M, Resultado);
        }

        [TestMethod]
        public void ObtenerRecargo_CuarentaOtonio_seis()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/11/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(6M, Resultado);
        }
        [TestMethod]
        public void ObtenerRecargo_QuinientosOtonio_TreintaySietePuntoCinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/11/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(37.50M, Resultado);
        }
        [TestMethod]
        public void ObtenerRecargo_MilDosientosOtonio_CincuentayCuatro()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/11/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);
            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(54M, Resultado);
        }

        [TestMethod]
        public void ObtenerRecargo_CuarentaInvierno_NuevePuntoDos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/01/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(9.20M, Resultado);
        }
        [TestMethod]
        public void ObtenerRecargo_QuinientosInvierno_CincuentaySietePuntoCinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/01/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(57.50M, Resultado);
        }
        [TestMethod]
        public void ObtenerRecargo_MilDosientosInvierno_OchentayDosPuntoOcho()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/01/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);
            decimal Resultado = Sut.ObtenerRecargo();
            Assert.AreEqual(82.80M, Resultado);
        }

        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_CuarentaPrimavera_CincuentayDosPuntoDiesciciete()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(52.17M, Resultado);
        }
        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_QuinientosPrimavera_SeiscientosCincuentayDosPuntoDiecisiete()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(652.17M, Resultado);
        }
        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_MilDosientosPrimavera_MilQuinientosSesentayCincoPuntoVeintiuno()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/05/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(1565.21M, Resultado);
        }


        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_CuarentaVerano_CincuentaySietePuntoNoventaySiete()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/07/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(57.97M, Resultado);
        }
        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_QuinientosVerano__SetecientosVeinticuatroPuntoSesentayTres()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/07/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(724.63M, Resultado);
        }
        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_MilDosientosVerano_MilSetecientosTreintayNuevePuntotrece()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/07/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);
            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(1739.13M, Resultado);
        }

        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_CuarentaOtonio_CuarentayCincoPuntoTreintaySeis()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/11/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(45.36M, Resultado);
        }
        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_QuinientosOtonio_QuinientosSesentaysietePuntoUno()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/11/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(567.10M, Resultado);
        }
        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_MilDosientosOtonio_MiltrescientosSesentayUnoPuntoCeroCinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/11/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);
            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(1361.05M, Resultado);
        }

        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_CuarentaInvierno_SetentayCuatroPuntoCincuentayTres()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/01/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(40, FechaEnvio, configuraciones);

            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(74.53M, Resultado);
        }
        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_QuinientosInvierno_NovecientoTreintayUnoPuntoSesentaySiete()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/01/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(500, FechaEnvio, configuraciones);


            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(931.67M, Resultado);
        }
        [TestMethod]
        public void ObtenerTiempoEntregaMinutos_MilDosientosInvierno_DosMilDoscientosTreintaySeisPuntoCeroDos()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            DateTime FechaEnvio = DateTime.ParseExact("02/01/2020 12:00", "dd/MM/yyyy HH:mm", culture);

            var Sut = new Maritimo(1200, FechaEnvio, configuraciones);
            decimal Resultado = Sut.ObtenerTiempoEntregaMinutos();
            Assert.AreEqual(2236.02M, Resultado);
        }

        [TestMethod]
        public void ObtenerVelocidad_CuarentaySeis_CuarentaySeis()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Maritimo(800, DateTime.ParseExact("02/03/2020 12:00", "dd/MM/yyyy HH:mm", culture), configuraciones);

            decimal Resultado = Sut.ObtenerVelocidad();
            Assert.AreEqual(46, Resultado);
        }
    }
}