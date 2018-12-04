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
    public class GetBillsByIdUser_Should : MockedBase<Bill>
    {
        [Test]
        public void ReturnBills_WhenIdUserIsValid()
        {
            // Arrange
            var contextMock = this.Context;
            var companyServiceMock = this.CompanyServiceMocked;

            var idUser = "idUser02";
            var bills = this.Bills;

            var billSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bills);

            var expectedResult = bills.Where(b => b.IdUser == idUser);
            

            contextMock.Setup(c => c.DbSet).Returns(billSetMock.Object);

            Bills.Services.BillService billService = new Bills.Services.BillService(companyServiceMock.Object, contextMock.Object);

            // Act
            //var result = billService.GetBillsByIdUser(idUser);

            //// Assert
            //contextMock.Verify(b => b.DbSet, Times.Once);
            //CollectionAssert.IsNotEmpty(expectedResult);
            //CollectionAssert.IsNotEmpty(result);
            //CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [Test]
        public void ReturnDifferentBills_WhenIdUserIsNotValid()
        {
            // Arrange
            var contextMock = this.Context;
            var companyServiceMock = this.CompanyServiceMocked;

            var idUser = "23";
            var bills = this.Bills;

            var billSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bills);

            var expectedResult = bills.Where(b => b.IdUser == "idUser03");


            contextMock.Setup(c => c.DbSet).Returns(billSetMock.Object);

            Bills.Services.BillService billService = new Bills.Services.BillService(companyServiceMock.Object, contextMock.Object);

            // Act
            //var result = billService.GetBillsByIdUser(idUser);

            //// Assert
            //contextMock.Verify(b => b.DbSet, Times.Once);
            //CollectionAssert.IsNotEmpty(expectedResult);
            //CollectionAssert.IsEmpty(result);
            //CollectionAssert.AreNotEquivalent(expectedResult, result);

        }

        [Test]
        public void ReturnEmpty_WhenIdUserIsNotValid()
        {
            // Arrange
            var contextMock = this.Context;
            var companyServiceMock = this.CompanyServiceMocked;

            var idUser = "23";
            var bills = this.Bills;

            var billSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bills);

            contextMock.Setup(c => c.DbSet).Returns(billSetMock.Object);

            Bills.Services.BillService billService = new Bills.Services.BillService(companyServiceMock.Object, contextMock.Object);

            // Act
            //var result = billService.GetBillsByIdUser(idUser);

            //// Assert
            //contextMock.Verify(b => b.DbSet, Times.Once);
            //Assert.IsEmpty(result);
        }
    }
}
