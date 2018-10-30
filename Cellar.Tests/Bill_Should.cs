using Cellar.Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Tests
{
    [TestFixture]
    public class Bill_Should
    {

        [Test]
        public void ReturnValuesPropertiesCorrect_WhenSetPropertiesAreCorrect()
        {
            // Arrange
            Bill bill = new Bill();
            var company = new Mock<Company>();

            // Act
            bill.Id = 1;
            bill.Exento = 5;
            bill.Base4 = 10;
            bill.Base10 = 20;
            bill.Base21 = 30;
            bill.Month = "January";
            bill.IdUser = "IdUser";
            bill.BillScanned = "scanned";
            bill.Company = company.Object;

            var idExpected = 1;
            var exentoExpected = 5;
            var base4Expected = 10;
            var base10Expected = 20;
            var base21Expected = 30;
            var monthExpected = "January";
            var idUserExpected = "IdUser";
            var billScannedExpected = "scanned";
            var IVA4Expected = 10 * 0.04;
            var IVA10Expected = 20 * 0.10;
            var IVA21Expected = 30 * 0.21;
            var totalBillExpected = bill.Exento + bill.Base4 + bill.Base10 + bill.Base21 + bill.IVA4 + bill.IVA10 + bill.IVA21;

            // Assert
            Assert.AreEqual(idExpected, bill.Id);
            Assert.AreEqual(exentoExpected, bill.Exento);
            Assert.AreEqual(base4Expected, bill.Base4);
            Assert.AreEqual(base10Expected, bill.Base10);
            Assert.AreEqual(base21Expected, bill.Base21);
            Assert.AreEqual(monthExpected, bill.Month);
            Assert.AreEqual(idUserExpected, bill.IdUser);
            Assert.AreEqual(billScannedExpected, bill.BillScanned);
            Assert.AreSame(company.Object, bill.Company);
            Assert.AreEqual(IVA4Expected, bill.IVA4);
            Assert.AreEqual(IVA10Expected, bill.IVA10);
            Assert.AreEqual(IVA21Expected, bill.IVA21);
            Assert.AreEqual(totalBillExpected, bill.TotalBill);
        }
    }

}
