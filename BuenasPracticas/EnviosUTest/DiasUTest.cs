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
        public void ObtenerFormatoTiempo_SesentaHoras_DosDias()
        {

            var Sut = new Dias();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("0 Meses");
            Sut.Siguiente(DOC_Horas.Object);
            string Resultado = Sut.ObtenerFormatoTiempo(3600M);
            Assert.AreEqual("2 Días", Resultado);

        }
        [TestMethod]
        public void ObtenerFormatoTiempo_SetecientosVeintiCincoHoras_UnMes()
        {
            var Sut = new Dias();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("1 Mes");
            Sut.Siguiente(DOC_Horas.Object);
            string Resultado = Sut.ObtenerFormatoTiempo(43500M);
            Assert.AreEqual("1 Mes", Resultado);

        }

        [TestMethod]
        public void Siguiente_InvocandoMeses_UnaVez()
        {
            int contador = 0;
            var Sut = new Dias();
            var DOC_Meses = new Mock<IFormatoTiempo>();
            DOC_Meses.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Callback(() => contador++);
            Sut.Siguiente(DOC_Meses.Object);
            Sut.ObtenerFormatoTiempo(72000M);
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
