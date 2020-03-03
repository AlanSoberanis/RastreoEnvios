using BuenasPracticas.clases;
using BuenasPracticas.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace EnviosUTest
{
    [TestClass]
   public class EstafetaUTest
    {
        ConfiguracionEstafeta configuraciones = new ConfiguracionEstafeta();

        [TestMethod]
        public void ObtenerTiempoRepartoMinutos_CalculoGeneral_Cinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);

            var Sut = new Estafeta("", DateTime.ParseExact("02/03/2020 12:00", "dd/MM/yyyy HH:mm", culture), configuraciones);

            decimal Resultado = Sut.ObtenerTiempoRepartoMinutos();
            Assert.AreEqual(5, Resultado);
        }
        


        [TestMethod]
        public void ObtenerUtilidad_CatorceFebrero_PuntoCinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Estafeta("", DateTime.ParseExact("14/02/2020 12:00", "dd/MM/yyyy HH:mm", culture), configuraciones);

            decimal Resultado = Sut.ObtenerUtilidad();
            Assert.AreEqual(.50M, Resultado);
        }

        [TestMethod]
        public void ObtenerUtilidad_Diciembre_PuntoUno()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Estafeta("", DateTime.ParseExact("02/12/2020 12:00", "dd/MM/yyyy HH:mm", culture), configuraciones);

            decimal Resultado = Sut.ObtenerUtilidad();
            Assert.AreEqual(.10M, Resultado);
        }

        [TestMethod]
        public void ObtenerUtilidad_General_PuntoCuarentaycinco()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Estafeta("", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture), configuraciones);

            decimal Resultado = Sut.ObtenerUtilidad();
            Assert.AreEqual(.45M, Resultado);
        }
        
        [TestMethod]
        public void ValidarTransporte_Terrestre_true()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Estafeta("Terrestre", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture), configuraciones);

            bool Resultado = Sut.ValidarTransporte();
            Assert.IsTrue(Resultado);
        }
        [TestMethod]
        public void ValidarTransporte_Aereo_false()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Estafeta("Aéreo", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture), configuraciones);
            bool Resultado = Sut.ValidarTransporte();
            Assert.IsFalse(Resultado);
        }
        [TestMethod]
        public void ValidarTransporte_Maritimo_true()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Estafeta("Marítimo", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture), configuraciones);
            bool Resultado = Sut.ValidarTransporte();
            Assert.IsTrue(Resultado);
        }


        [TestMethod]
        public void MostrarValidaciontransporte_Aereo_MuestraError()
        {

            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Estafeta("Aéreo", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture), configuraciones);
            string Resultado = Sut.MostrarValidaciontransporte();
            Assert.AreEqual("Estafeta no ofrece el servicio de transporte Aéreo, te recomendamos cotizar en otra empresa.", Resultado);
        }



        [TestMethod]
        public void ObtenerPaqueteria_General_DevuelveEstafeta()
        {
            IFormatProvider culture = new CultureInfo("ES-MX", true);
            var Sut = new Estafeta("", DateTime.ParseExact("02/09/2020 12:00", "dd/MM/yyyy HH:mm", culture), configuraciones);
            string Resultado = Sut.ObtenerPaqueteria();
            Assert.AreEqual("Estafeta", Resultado);
        }

    }
}