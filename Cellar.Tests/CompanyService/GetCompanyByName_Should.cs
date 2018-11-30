using Bills.Services;
using Cellar.Data.Models;
using Cellar.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Tests.CompanyService
{
    [TestFixture]
    public class GetCompanyByName_Should : MockedBase<Company>
    {
        [Test]
        public void ReturnSpeficifName_WhenTheNameIsValid()
        {
            var contextMocked = this.Context;
            var companies = this.Companies;
            var companyName = "Company03";
            var companiesSetMock = QueryableDbSetMock.GetQueryableMockDbSetFromArray(companies);

            contextMocked.Setup(b => b.All).Returns(companiesSetMock.Object);

            var companyService = new Bills.Services.CompanyService(contextMocked.Object);

            var expectedResult = companies.FirstOrDefault(c => c.Name == companyName);
            var result = companyService.GetCompanyByName(companyName);

            Assert.AreSame(expectedResult, result);
        }

        

    }
}
