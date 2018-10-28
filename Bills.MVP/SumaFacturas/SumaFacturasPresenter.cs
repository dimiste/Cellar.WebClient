using Bills.MVP.Commun;
using Bills.MVP.ListaFacturas;
using Bills.Services;
using Cellar.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace Bills.MVP.SumaFacturas
{
    public class SumaFacturasPresenter : PresenterCommun<ISumaFacturasView>
    {
        public SumaFacturasPresenter(ISumaFacturasView view, IBillsSystemContext billsSystemContext, IBillService billService, ICompanyService companyService)
            : base(view, billsSystemContext, billService, companyService)
        {
            this.View.OnListView1_GetData += View_OnListView1_GetData;
        }

        private void View_OnListView1_GetData(object sender, GetContextEventArgs e)
        {
            var idUser = e.Context.User.Identity.GetUserId();
            this.View.Model.SumBills = billService.CalculatorMounths(idUser);
        }
    }
}
