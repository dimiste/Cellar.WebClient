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
            IBill bill = new Bill();
            var company = new Mock<Company>();
            var date = new DateTime(2018, 03, 28);
            var id = 1;
            var exento = 5;
            var base4 = 10;
            var base10 = 20;
            var base21 = 30;
            var mounth = "January";
            var idUser = "IdUser";
            var scanned = "scanned";

            // Act
            bill.Id = id;
            bill.Exento = exento;
            bill.Base4 = base4;
            bill.Base10 = base10;
            bill.Base21 = base21;
            bill.Month = mounth;
            bill.IdUser = idUser;
            bill.BillScanned = scanned;
            bill.Company = company.Object;
            bill.Date = date;

            var idExpected = id;
            var exentoExpected = exento;
            var base4Expected = base4;
            var base10Expected = base10;
            var base21Expected = base21;
            var monthExpected = mounth;
            var idUserExpected = idUser;
            var billScannedExpected = scanned;
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
            Assert.AreEqual(date, bill.Date);
        }

    }

}
