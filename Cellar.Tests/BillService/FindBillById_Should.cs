﻿using Bills.Services;
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

namespace Cellar.Tests.BillService
{
    [TestFixture]
    public class FindBillById_Should : MockedBase<Bill>
    {

        [Test]
        public void ReturnSpecificBill_WhenIdIsValid()
        {
            // Arrange
            var contextMock = this.Context;
            var companyServiceMock = this.CompanyServiceMocked;

            var expectedId = 2;
            var bills = this.Bills;

            var billSetMock = QueryableDbSetMock.GetQueryableMockDbSet(bills);

            contextMock.Setup(c => c.DbSet).Returns(billSetMock.Object);

            Bills.Services.BillService billService = new Bills.Services.BillService(companyServiceMock.Object, contextMock.Object);

            contextMock.Setup(b => b.DbSet.Find(It.IsAny<object[]>())).Returns<object[]>(ids => billSetMock.Object.Where(d => d.Id == (int)ids[0]).First());

            // Act
            var result = billService.FindBillById(expectedId);

            Assert.AreEqual(expectedId, result.Id);
            contextMock.Verify(b => b.DbSet.Find(expectedId), Times.Once);

        }

        
    }
}
