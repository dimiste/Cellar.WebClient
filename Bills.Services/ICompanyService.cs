using System.Collections.Generic;
using System.Linq;
using Cellar.Data.Models;

namespace Bills.Services
{
    public interface ICompanyService
    {
        IEnumerable<string> GetAllNamesCompany();

        Company GetCompanyByName(string companyName);

        IQueryable<Company> GetAllCompanies();

        Company FindCompanyById(int id);

        void RemoveCompany(Company company);
    }
}