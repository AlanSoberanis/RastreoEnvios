using BuenasPracticas.clases;
using BuenasPracticas.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EnviosUTest
{
    [TestClass]
    public class HorasUTest 
    {

        [TestMethod]
        public void ObtenerFormatoTiempo_MildoscientosMinutos_VeinteHoras()
        {

            var Sut = new Horas();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("0 Dias");
            Sut.Siguiente(DOC_Horas.Object);
            string Resultado = Sut.ObtenerFormatoTiempo(1200M);
            Assert.AreEqual("20 Horas", Resultado);

        }
        [TestMethod]
        public void ObtenerFormatoTiempo_SieteMilDoscientoCincuentaMinutos_CincoDias()
        {
            var Sut = new Horas();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Returns("5 Dias");
            Sut.Siguiente(DOC_Horas.Object);
            string Resultado = Sut.ObtenerFormatoTiempo(7250M);
            Assert.AreEqual("5 Dias", Resultado);

        }

        [TestMethod]
        public void Siguiente_InvocandoHoras_UnaVez()
        {
            int contador = 0;
            var Sut = new Horas();
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
            var Sut = new Horas();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Callback(() => contador++);
            Sut.ObtenerFormatoTiempo(500M);
            Assert.AreEqual(0, contador);

        }
    }
}
