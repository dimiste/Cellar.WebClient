using Bills.MVP.Commun;
using Bills.MVP.ListaFacturas;
using Bills.Services;
using Cellar.Data;
using Cellar.Data.Models;

using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;

using WebFormsMvp.Web;

namespace Bills.MVP.InsertarEmpresa
{
    public class InsertarEmpresaPresenter : PresenterCommun<IInsertarEmpresaView>
    {

        public InsertarEmpresaPresenter(IInsertarEmpresaView view, IBillsSystemContext billsSystemContext, IBillService billService, ICompanyService companyService)
            : base(view, billsSystemContext, billService, companyService)
        {
            this.View.OnInsertCompany += View_OnInsertCompany;
            this.View.OnServerValidation += View_OnServerValidation;
        }

        private void View_OnServerValidation(object sender, GetContextEventArgs e)
        {
            var sen = sender as MvpPage;
            var control = sen.Master.FindControl("ContentPlaceHolder1") as Control;
            var companyBase = (TextBox)control.FindControl("company");
            var idUser = e.Context.User.Identity.GetUserId();
            var result = this.companyService.GetCompanyByIdUser(idUser).ToList().Select(c => c.Name);

            var requiredFielValidatorCompany = (RequiredFieldValidator)control.FindControl("RequiredFieldValidatorCompany");

            if (result.Contains(companyBase.Text))
            {
                requiredFielValidatorCompany.Text = "No repitas empresa";
                requiredFielValidatorCompany.IsValid = false;
            }

        }

        private void View_OnInsertCompany(object sender, GetContextEventArgs e)
        {
            var sen = sender as MvpPage;
            var control = sen.Master.FindControl("ContentPlaceHolder1") as Control;
            var idUser = e.Context.User.Identity.GetUserId();

            this.companyService.CreateCompanyForSpecificUser(control, idUser);

        }
    }
}
