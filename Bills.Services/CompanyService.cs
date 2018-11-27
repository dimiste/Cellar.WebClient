using Cellar.Data;
using Cellar.Data.Models;
using Cellar.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bills.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IBillsSystemContext billsSystemContext;
        private readonly EfRepository<Company> context;

        public CompanyService(IBillsSystemContext billsSystemContext, EfRepository<Company> context)
        {
            this.billsSystemContext = billsSystemContext;
            this.context = context;
        }

        public Company GetCompanyByName(string companyName)
        {
            return this.context.All.FirstOrDefault(c => c.Name == companyName);

            return this.billsSystemContext.Companies.FirstOrDefault(c => c.Name == companyName);
        }

        public IEnumerable<string> GetAllNamesCompany()
        {
            return this.context.All.ToList().Select(c => c.Name);

            return this.billsSystemContext.Companies.ToList().Select(c => c.Name);
        }

        public IQueryable<Company> GetAllCompanies()
        {
            return this.context.All;

            return billsSystemContext.Companies;
        }

        public Company FindCompanyById(int id)
        {
            var company = this.context.DbSet.Find(id);
            //var company = billsSystemContext.Companies.Find(id);

            return company;
        }

        public void RemoveCompany(Company company)
        {
            this.context.Delete(company);

            //billsSystemContext.Companies.Remove(company);
        }

        public IQueryable<Company> GetCompanyByIdUser(string idUser)
        {
            return this.context.DbSet.Where(c => c.IdUser == idUser);

            return this.billsSystemContext
                .Companies
                .Where(c => c.IdUser == idUser);
        }

        public void CreateCompanyForSpecificUser(Control control, string idUser)
        {
            var companyBase = (TextBox)control.FindControl("company");
            Company company = new Company();
            company.Name = companyBase.Text;
            company.IdUser = idUser;

            this.context.Add(company);
            this.context.SaveChanges();

            //this.billsSystemContext.Companies.Add(company);
            //this.billsSystemContext.SaveChanges();
        }

        public void UpdateByIdCompany(Page page, int idToUpdateItem)
        {
            Company item = null;

            // Cargar el elemento aquí, por ejemplo item = MyDataLayer.Find(id);
            item = this.FindCompanyById(idToUpdateItem);

            if (item == null)
            {
                // No se encontró el elemento
                page.ModelState.AddModelError("", String.Format("No se encontró el elemento con id. {0}", idToUpdateItem));
                return;
            }
            page.TryUpdateModel(item);
            if (page.ModelState.IsValid)
            {
                // Guarde los cambios aquí, por ejemplo MyDataLayer.SaveChanges();
                this.context.SaveChanges();
                //this.billsSystemContext.SaveChanges();
            }
        }
    }
}
