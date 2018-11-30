using Bills.Services;
using Cellar.Data;
using Cellar.Data.Models;
using Cellar.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Tests.Mocks
{
    public class MockedBase<T> where T : class
    {
        internal Mock<IEfRepository<T>> Context => new Mock<IEfRepository<T>>();

        internal Mock<IBillsSystemContext> ContextMock => new Mock<IBillsSystemContext>();

        internal Mock<ICompanyService> CompanyServiceMocked => new Mock<ICompanyService>();

        internal Mock<IBillService> BillServiceMocked => new Mock<IBillService>();

        internal IList<Bill> Bills => new List<Bill>()
        {
            new Bill() { Id = 1, IdUser = "idUser01" },
            new Bill() { Id = 2, IdUser = "idUser02" },
            new Bill() { Id = 3, IdUser = "idUser03" }
        };

        internal IList<Company> Companies => new List<Company>()
        {
            new Company() { Id = 1, IdUser = "idUser01", Name = "Company01" },
            new Company() { Id = 2, IdUser = "idUser02", Name = "Company02" },
            new Company() { Id = 3, IdUser = "idUser03", Name = "Company03" }
        };
    }
}
