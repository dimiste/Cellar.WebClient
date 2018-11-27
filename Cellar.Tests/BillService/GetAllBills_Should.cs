using Cellar.Data;
using Cellar.Data.Models;
using Cellar.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bills.Services;

namespace Cellar.Tests.BillService
{
    [TestFixture]
    public class GetAllBills_Should : MockedBase<Bill>
    {
        [Test]
        public void ReturnAllBills()
        {
            // Arrange
            var contextMock = this.Context;
            var companyServiceMock = this.CompanyServiceMocked;

            var bills = this.Bills;

            var billSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bills);

            contextMock.Setup(b => b.DbSet).Returns(billSetMock.Object);

            Bills.Services.BillService billService = new Bills.Services.BillService(companyServiceMock.Object, contextMock.Object);

            // Act
            var result = billService.GetAllBills();

            // Assert
            contextMock.Verify(b => b.DbSet, Times.Once);
            CollectionAssert.AreEquivalent(result, bills);
        }
    }
}
