using BuenasPracticas.clases;
using BuenasPracticas.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EnviosUTest
{
    [TestClass]
   public class DiasUTest 
    {

        [TestMethod]
        public void ObtenerFormatoTiempo_SesentaHoras_Dias()
        {

            var Sut = new Dias();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("0 Meses");
            Sut.Siguiente(DOC_Horas.Object);
            string Resultado = Sut.ObtenerFormatoTiempo(60M);
            Assert.AreEqual("2 Días", Resultado);

        }
        [TestMethod]
        public void ObtenerFormatoTiempo_SetecientosVeintiCincoHoras_UnMes()
        {
            var Sut = new Dias();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("1 Mes");
            Sut.Siguiente(DOC_Horas.Object);
            string Resultado = Sut.ObtenerFormatoTiempo(725M);
            Assert.AreEqual("1 Mes", Resultado);

        }

        [TestMethod]
        public void Siguiente_InvocandoHoras_UnaVez()
        {
            int contador = 0;
            var Sut = new Dias();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Callback(() => contador++);
            Sut.Siguiente(DOC_Horas.Object);
            Sut.ObtenerFormatoTiempo(2500M);
            Assert.AreEqual(1, contador);

        }
        [TestMethod]
        public void Siguiente_InvocandoHoras_CeroVez()
        {
            int contador = 0;
            var Sut = new Dias();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Callback(() => contador++);
            Sut.ObtenerFormatoTiempo(500M);
            Assert.AreEqual(0, contador);

        }
    }
}
