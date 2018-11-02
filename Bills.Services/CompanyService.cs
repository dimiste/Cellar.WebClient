using Cellar.Data;
using Cellar.Data.Models;
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

        public IQueryable<Company> GetCompanyByIdUser(string idUser)
        {
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
            this.billsSystemContext.Companies.Add(company);
            this.billsSystemContext.SaveChanges();
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
                this.billsSystemContext.SaveChanges();
            }
        }
    }
}
