using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Cellar.Data.Models;

namespace Bills.Services
{
    public interface ICompanyService
    {
        Company GetCompanyByName(string companyName);

        IQueryable<Company> GetAllCompanies();

        Company FindCompanyById(int id);

        IQueryable<Company> GetCompanyByIdUser(string idUser);

        void CreateCompanyForSpecificUser(Control control, string idUser);

        void UpdateByIdCompany(Page page, int idToUpdateItem);
    }
}