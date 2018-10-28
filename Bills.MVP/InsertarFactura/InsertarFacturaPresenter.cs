using Bills.MVP.Commun;
using Bills.Services;
using Cellar.Data;
using Cellar.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormsMvp;

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

        private void View_OnServerValidation(object sender, GetControlEventArgs e)
        {
            var result = this.companyService.GetAllNamesCompany();
            var companyBase = (HtmlInputText)e.Control.FindControl("company");
            var monthBase = (HtmlSelect)e.Control.FindControl("month");
            var requiredFielValidatorCompany = (RequiredFieldValidator)e.Control.FindControl("RequiredFieldValidatorCompany");
            var RequiredFieldValidator1 = (RequiredFieldValidator)e.Control.FindControl("RequiredFieldValidator1");

            if (!result.Contains(companyBase.Value))
            {
                requiredFielValidatorCompany.IsValid = false;
            }

            if (string.IsNullOrEmpty(monthBase.Value))
            {
                RequiredFieldValidator1.IsValid = false;
            }
        }

        private void View_OnSubmitProcess(object sender, GetContextAndControlEventArgs e)
        {
            int lastIdBill = 0;

            Bill bill = new Bill();
            //var month = (TextBox)e.Control.FindControl("month");
            var month = (HtmlSelect)e.Control.FindControl("month");
            var year = DateTime.Now.Year.ToString();
            bill.Month = year + month.Value;

            var idUser = e.Context.User.Identity.GetUserId();

            bill.IdUser = idUser;

            if (billService.GetAllBills().Count > 0)
            {
                lastIdBill = billService.GetLastOrDefaultIdBill();
            }

            var companyBase = (HtmlInputText)e.Control.FindControl("company");
            var company = this.companyService.GetCompanyByName(companyBase.Value);
            bill.Company = company;

            var exentoBase = (HtmlInputText)e.Control.FindControl("exento");
            if (string.IsNullOrEmpty(exentoBase.Value))
            {
                bill.Exento = 0;
            }
            else
            {
                bill.Exento = double.Parse(exentoBase.Value);
            }

            var base4Base = (HtmlInputText)e.Control.FindControl("base4");
            if (string.IsNullOrEmpty(base4Base.Value))
            {
                bill.Base4 = 0;
            }
            else
            {
                bill.Base4 = double.Parse(base4Base.Value);
            }

            var base10Base = (HtmlInputText)e.Control.FindControl("base10");
            if (string.IsNullOrEmpty(base10Base.Value))
            {
                bill.Base10 = 0;
            }
            else
            {
                bill.Base10 = double.Parse(base10Base.Value);
            }

            var base21Base = (HtmlInputText)e.Control.FindControl("base21");
            if (string.IsNullOrEmpty(base21Base.Value))
            {
                bill.Base21 = 0;
            }
            else
            {
                bill.Base21 = double.Parse(base21Base.Value);
            }

            var billScanned = (HtmlInputFile)e.Control.FindControl("bill");
            var billScannedPostedFile = billScanned.PostedFile;


            // también se podría haber subido el archivo con el controlador "FileUpload" de asp.net. Para verificar si existe archvo sería: "FileUpload.HasFile"
            if (billScannedPostedFile.ContentLength > 0)
            {
                string path = "../img/" + (lastIdBill + 1).ToString() + Path.GetExtension(billScannedPostedFile.FileName);
                billScannedPostedFile.SaveAs(e.Context.Server.MapPath(path));
                bill.BillScanned = path;
            }
            else
            {
                bill.BillScanned = "../img/FacturaNoEscaneada.pdf";
            }



            var dateBase = (HtmlInputGenericControl)e.Control.FindControl("date");
            bill.Date = DateTime.Parse(dateBase.Value);

            this.billsSystemContext.Bills.Add(bill);
            billsSystemContext.SaveChanges();
        }
    }
}
