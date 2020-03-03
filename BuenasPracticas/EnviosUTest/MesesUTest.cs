using BuenasPracticas.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BuenasPracticas.clases;

namespace EnviosUTest
{
    [TestClass]
   public class MesesUTest 
    {
        [TestMethod]
        public void ObtenerFormatoTiempo_CincuentaDias_()
        {
            var Sut = new Meses();
             string Resultado = Sut.ObtenerFormatoTiempo(50M);
            Assert.AreEqual("1 Mes", Resultado);

        }

        [TestMethod]
        public void Siguiente_InvocandoHoras_CeroVez()
        {
            int contador = 0;
            var Sut = new Meses();
            var DOC_Horas = new Mock<IFormatoTiempo>();
            DOC_Horas.Setup(x => x.ObtenerFormatoTiempo(It.IsAny<decimal>())).Callback(() => contador++);
            Sut.ObtenerFormatoTiempo(50M);
            Assert.AreEqual(0, contador);

        }
    }
}
