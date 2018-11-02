using Bills.Services;
using Cellar.Data;
using Bills.MVP.Commun;

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;

using WebFormsMvp.Web;


namespace Bills.MVP.ListaFacturas
{
    public class ListaFacturasPresenter : PresenterCommun<IListaFacturasView>
    {
        public ListaFacturasPresenter(IListaFacturasView view, IBillsSystemContext billSystemContext, IBillService billService, ICompanyService companyService)
            : base(view, billSystemContext, billService, companyService)
        {
            this.View.OnListView1_GetData += View_OnListView1_GetData;
            this.View.OnButonEliminar_Click += View_OnButonEliminar_Click;
        }

        private void View_OnButonEliminar_Click(object sender, EventArgs e)
        {
            var sen = sender as MvpPage;
            var control = sen.Master.FindControl("ContentPlaceHolder1") as Control;
            var listView = (ListView)control.FindControl("ListView1");

            this.billService.DeleteBillByCheckedBox(listView);
        }

        private void View_OnListView1_GetData(object sender, GetContextEventArgs e)
        {
            var idUser = e.Context.User.Identity.GetUserId();
            this.View.Model.Bills = this.billService.GetBillsByIdUser(idUser);
        }

    }
}
