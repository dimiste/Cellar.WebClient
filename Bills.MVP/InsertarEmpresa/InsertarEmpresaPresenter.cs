using Bills.MVP.Commun;
using Bills.Services;
using Cellar.Data;
using Cellar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace Bills.MVP.InsertarEmpresa
{
    public class InsertarEmpresaPresenter : PresenterCommun<IInsertarEmpresaView>
    {

        public InsertarEmpresaPresenter(IInsertarEmpresaView view, IBillsSystemContext billsSystemContext, IBillService billService, ICompanyService companyService)
            : base(view, billsSystemContext, billService, companyService)
        {
            this.View.OnInsertCompany += View_OnInsertCompany;
        }

        private void View_OnInsertCompany(object sender, GetCompanyEventArgs e)
        {
            Company company = new Company();
            company.Name = e.Company.Text;
            this.billsSystemContext.Companies.Add(company);
            this.billsSystemContext.SaveChanges();

        }
    }
}
