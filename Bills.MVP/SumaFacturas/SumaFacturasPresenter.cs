using Bills.MVP.Commun;
using Bills.MVP.ListaFacturas;
using Bills.Services;
using Cellar.Data;

using Microsoft.AspNet.Identity;

namespace Bills.MVP.SumaFacturas
{
    public class SumaFacturasPresenter : PresenterCommun<ISumaFacturasView>
    {
        public ISumBillsService sumBillsService { get; set; }

        public SumaFacturasPresenter(ISumaFacturasView view, IBillsSystemContext billsSystemContext, IBillService billService, ICompanyService companyService, ISumBillsService sumBillsService)
            : base(view, billsSystemContext, billService, companyService)
        {
            this.sumBillsService = sumBillsService;

            this.View.OnListView1_GetData += View_OnListView1_GetData;
        }

        private void View_OnListView1_GetData(object sender, GetContextEventArgs e)
        {
            var idUser = e.Context.User.Identity.GetUserId();
            this.View.Model.SumBills = this.billService.CalculatorMounths(this.sumBillsService, idUser);
        }
    }
}
