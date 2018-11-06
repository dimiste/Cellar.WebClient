using Cellar.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Tests
{
    [TestFixture]
    public class SumBills_Should
    {
        
        [Test]
        public void ReturnValuesPropertiesCorrect_WhenSetPropertiesAreCorrect()
        {
            var sumBills = new SumBills();
            var mes = "01";
            var exento = 1.0;
            var baseSuperReducido = 2.0;
            var baseReducido = 3.0;
            var baseNormal = 4.0;
            var ivaSuperRedudico = 5.0;
            var ivaReducido = 6.0;
            var ivaNormal = 7.0;
            var baseTotal = 8.0;
            var ivaTotal = 9.0;
            var importeTotal = 10.0;


            sumBills.Mes = mes;
            sumBills.Exento = exento;
            sumBills.BaseSuperReducido = baseSuperReducido;
            sumBills.BaseReducido = baseReducido;
            sumBills.BaseNormal = baseNormal;
            sumBills.IVASuperReducido = ivaSuperRedudico;
            sumBills.IVAReducido = ivaReducido;
            sumBills.IVANormal = ivaNormal;
            sumBills.BaseTotal = baseTotal;
            sumBills.IVATotal = ivaTotal;
            sumBills.ImporteTotal = importeTotal;

            var expectedMes = mes;
            var expectedExento = exento;
            var expectedSuperReducido = baseSuperReducido;
            var expectedReducido = baseReducido;
            var expectedNormal = baseNormal;
            var expectedIvaSuperReducido = ivaSuperRedudico;
            var expectedIvaReducido = ivaReducido;
            var expectedIvaNormal = ivaNormal;
            var expectedBaseTotal = baseTotal;
            var expectedIvaTotal = ivaTotal;
            var expectedImporteTotal = importeTotal;

            Assert.AreEqual(expectedMes, sumBills.Mes);
            Assert.AreEqual(expectedExento, sumBills.Exento);
            Assert.AreEqual(expectedSuperReducido, sumBills.BaseSuperReducido);
            Assert.AreEqual(expectedReducido, sumBills.BaseReducido);
            Assert.AreEqual(expectedNormal, sumBills.BaseNormal);
            Assert.AreEqual(expectedIvaSuperReducido, sumBills.IVASuperReducido);
            Assert.AreEqual(expectedIvaReducido, sumBills.IVAReducido);
            Assert.AreEqual(expectedIvaNormal, sumBills.IVANormal);
            Assert.AreEqual(expectedBaseTotal, sumBills.BaseTotal);
            Assert.AreEqual(expectedIvaTotal, sumBills.IVATotal);
            Assert.AreEqual(expectedImporteTotal, sumBills.ImporteTotal);
        }
    }
}
