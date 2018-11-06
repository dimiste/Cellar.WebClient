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

namespace Cellar.Tests.CompanyService
{
    [TestFixture]
    public class GetAllCompanies_Should : MockedBase
    {
        [Test]
        public void ReturnAllCompanies() 
        {
            // Arragne
            var contextMock = this.ContextMock;

            var companies = this.Companies;

            var companySetMock = new Mock<IDbSet<Company>>();
            companySetMock.As<IQueryable<Company>>().Setup(m => m.Provider).Returns(companies.AsQueryable().Provider);
            companySetMock.As<IQueryable<Company>>().Setup(m => m.Expression).Returns(companies.AsQueryable().Expression);
            companySetMock.As<IQueryable<Company>>().Setup(m => m.ElementType).Returns(companies.AsQueryable().ElementType);
            companySetMock.As<IQueryable<Company>>().Setup(m => m.GetEnumerator()).Returns(companies.AsQueryable().GetEnumerator());

            contextMock.Setup(c => c.Companies).Returns(companySetMock.Object);

            ICompanyService companyService = new Bills.Services.CompanyService(contextMock.Object);

            // Act
            var result = companyService.GetAllCompanies();

            // Assert
            contextMock.Verify(c => c.Companies, Times.Once);
            CollectionAssert.AreEquivalent(companies, result.ToList());
        }
    }
}
