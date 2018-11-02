using Bills.MVP.Commun;
using Bills.MVP.ListaFacturas;
using Bills.Services;
using Cellar.Data;
using Cellar.Data.Models;

using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;

using WebFormsMvp.Web;
using System.Web;

namespace Bills.MVP.InsertarEmpresa
{
    public class InsertarFacturaPresenter : PresenterCommun<IInsertarFacturaView>
    {
        public InsertarFacturaPresenter(IInsertarFacturaView view, IBillsSystemContext billsSystemContext, IBillService billService, ICompanyService companyService)
            : base(view, billsSystemContext, billService, companyService)
        {
            this.View.OnSubmitProcess += View_OnSubmitProcess;
            this.View.OnServerValidation += View_OnServerValidation;

        }


        private void View_OnServerValidation(object sender, GetContextEventArgs e)
        {
            var sen = sender as MvpPage;
            var control = sen.Master.FindControl("ContentPlaceHolder1") as Control;
            var idUser = e.Context.User.Identity.GetUserId();
            var result = this.companyService.GetCompanyByIdUser(idUser).ToList().Select(c => c.Name);
            var companyBase = (HtmlInputText)control.FindControl("company");
            var monthBase = (HtmlSelect)control.FindControl("month");
            var requiredFielValidatorCompany = (RequiredFieldValidator)control.FindControl("RequiredFieldValidatorCompany");
            var RequiredFieldValidator1 = (RequiredFieldValidator)control.FindControl("RequiredFieldValidator1");

            if (!result.Contains(companyBase.Value))
            {
                requiredFielValidatorCompany.Text = "Primero debes insertar la empresa deseada a través de 'Insertar Empresa'";
                requiredFielValidatorCompany.IsValid = false;
            }

            if (string.IsNullOrEmpty(monthBase.Value))
            {
                RequiredFieldValidator1.IsValid = false;
            }
        }

        private void View_OnSubmitProcess(object sender, GetContextEventArgs e)
        {
            var sen = sender as MvpPage;
            var control = sen.Master.FindControl("ContentPlaceHolder1") as Control;
            HttpContext context = e.Context;

            this.billService.CreateBillFromForm(context, control);
        }
    }
}
