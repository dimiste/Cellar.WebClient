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
    public class GetBillsByIdUser_Should
    {
        [Test]
        public void ReturnBills_WhenIdUserIsValid()
        {
            // Arrange
            var contextMock = new Mock<IBillsSystemContext>();

            var idUser = "23";
            IQueryable<Bill> bills = new List<Bill>() { new Bill() { Id = 1, IdUser = idUser }, new Bill() { Id = 2, IdUser = idUser }, new Bill() { Id = 3, IdUser = "4"} }.AsQueryable();

            var billSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bills);

            var expectedResult = bills.Where(b => b.IdUser == idUser);
            

            contextMock.Setup(c => c.Bills).Returns(billSetMock);

            Bills.Services.BillService billService = new Bills.Services.BillService(contextMock.Object);

            // Act
            var result = billService.GetBillsByIdUser(idUser);

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, result);

        }
    }
}
