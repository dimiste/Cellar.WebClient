using Bills.Services;
using Cellar.Data;
using Cellar.Data.Models;
using Cellar.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Tests.BillService
{
    [TestFixture]
    public class RemoveBill_Should : MockedBase<Bill>
    {
        [Test]
        public void RemoveSpecificBill_WhenBillExist()
        {
            // Arrange
            var contextMock = this.Context;
            var companyServiceMock = this.CompanyServiceMocked;

            var expectedId = 2;
            var bills = this.Bills;

            var billSetMock = QueryableDbSetMock.GetQueryableMockDbSetFromArray(bills);

            contextMock.Setup(c => c.DbSet).Returns(billSetMock.Object);

            billSetMock.Setup(b => b.Remove(It.IsAny<Bill>())).Callback<Bill>((entity) => bills.Remove(entity));
            //contextMock.Setup(c => c.Bills.Remove(It.IsAny<Bill>())).Callback<Bill>((entity) => bills.Remove(entity));

            Bills.Services.BillService billService = new Bills.Services.BillService(companyServiceMock.Object, contextMock.Object);

            Bill bill = billSetMock.Object.First();

            // Act
            billService.RemoveBill(bill);

            // Assert
            Assert.AreEqual(billSetMock.Object.First().Id, expectedId);
        }

    }
}
