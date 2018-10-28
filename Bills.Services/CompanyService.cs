using Cellar.Data;
using Cellar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bills.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IBillsSystemContext billsSystemContext;

        public CompanyService(IBillsSystemContext billsSystemContext)
        {
            this.billsSystemContext = billsSystemContext;
        }

        public Company GetCompanyByName(string companyName)
        {
            return this.billsSystemContext.Companies.FirstOrDefault(c => c.Name == companyName);
        }

        public IEnumerable<string> GetAllNamesCompany()
        {
            return this.billsSystemContext.Companies.ToList().Select(c => c.Name);
        }

        public IQueryable<Company> GetAllCompanies()
        {
            return billsSystemContext.Companies;
        }

        public Company FindCompanyById(int id)
        {
            var company = billsSystemContext.Companies.Find(id);

            return company;
        }

        public void RemoveCompany(Company company)
        {
            billsSystemContext.Companies.Remove(company);
        }
    }
}
