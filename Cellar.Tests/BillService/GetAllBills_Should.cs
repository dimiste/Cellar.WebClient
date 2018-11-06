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
    public class GetAllBills_Should : MockedBase
    {
        [Test]
        public void ReturnAllBills()
        {
            // Arrange
            var contextMock = this.ContextMock;
            var companyServiceMock = this.CompanyServiceMocked;

            var bills = this.Bills;

            var billSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bills);

            contextMock.Setup(b => b.Bills).Returns(billSetMock.Object);

            Bills.Services.BillService billService = new Bills.Services.BillService(contextMock.Object, companyServiceMock.Object);

            // Act
            var result = billService.GetAllBills();

            // Assert
            contextMock.Verify(b => b.Bills, Times.Once);
            CollectionAssert.AreEquivalent(result, bills);
        }
    }
}
