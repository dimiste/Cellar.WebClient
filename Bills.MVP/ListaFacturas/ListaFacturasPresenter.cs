using Bills.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;
using Microsoft.AspNet.Identity;
using System.Web.UI.WebControls;
using Cellar.Data;
using Bills.MVP.Commun;

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

        private void View_OnButonEliminar_Click(object sender, GetListViewEventArgs e)
        {
            var result = e.ListView.Items;

            foreach (var item in result)
            {
                CheckBox chkUser = item.FindControl("CheckBox") as CheckBox;

                if (chkUser != null & chkUser.Checked)
                {
                    //int.TryParse(item.FindControl("Id").ToString(), out int idChecked);
                    Label idChecked = (Label)item.FindControl("Id");
                    var id = int.Parse(idChecked.Text);

                    var bill = this.billService.FindBillById(id);

                    this.billService.RemoveBill(bill);
                    this.billsSystemContext.SaveChanges();
                }
            }
        }

        private void View_OnListView1_GetData(object sender, GetContextEventArgs e)
        {
            var idUser = e.Context.User.Identity.GetUserId();
            this.View.Model.Bills = this.billService.GetBillsByIdUser(idUser);
        }

    }
}
