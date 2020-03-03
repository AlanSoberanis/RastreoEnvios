using BuenasPracticas.clases;
using BuenasPracticas.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EnviosUTest
{
    [TestClass]
    public class MinutosUTest 
    {
        [TestMethod]
        public void ObtenerFormatoTiempo_CincuentaMinutos_CincuentaMinutos()
        {

            var Sut = new Minutos();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("8 Horas");
            Sut.Siguiente(DOC_Horas.Object);
            string Resultado = Sut.ObtenerFormatoTiempo(50M);
            Assert.AreEqual("50 Minutos", Resultado);

        }
        [TestMethod]
        public void ObtenerFormatoTiempo_QuinientosMinutos_OchoHoras()
        {
            var Sut = new Minutos();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("8 Horas");
            Sut.Siguiente(DOC_Horas.Object);
            string Resultado = Sut.ObtenerFormatoTiempo(500M);
            Assert.AreEqual("8 Horas", Resultado);

        }
        [TestMethod]
        public void Siguiente_InvocandoHoras_UnaVez()
        {
            int contador = 0;
            var Sut = new Minutos();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("8 Horas").Callback(() => contador++);
            Sut.Siguiente(DOC_Horas.Object);
            Sut.ObtenerFormatoTiempo(500M);
            Assert.AreEqual(1, contador);
            
        }
        [TestMethod]
        public void Siguiente_InvocandoHoras_CeroVez()
        {
            int contador = 0;
            var Sut = new Minutos();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("8 Horas").Callback(() => contador++);
            Sut.ObtenerFormatoTiempo(500M);
            Assert.AreEqual(0, contador);

        }
    }
}
