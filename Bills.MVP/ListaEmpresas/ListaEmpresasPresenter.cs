using Bills.MVP.Commun;
using Bills.Services;
using Cellar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using WebFormsMvp;

namespace Bills.MVP.ListaEmpresas
{
    public class ListaEmpresasPresenter : PresenterCommun<IListaEmpresasView>
    {
        public ListaEmpresasPresenter(IListaEmpresasView view, IBillsSystemContext billsSystemContext, IBillService billService, ICompanyService companyService)
            : base(view, billsSystemContext, billService, companyService)
        {
            this.View.OnListView1_GetData += View_OnListView1_GetData;
            this.View.OnButonEliminar_Click += View_OnButonEliminar_Click;
        }

        private void View_OnButonEliminar_Click(object sender, ListaFacturas.GetListViewEventArgs e)
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

                    var company = this.companyService.FindCompanyById(id);

                    this.companyService.RemoveCompany(company);
                    this.billsSystemContext.SaveChanges();
                }
            }
        }

        private void View_OnListView1_GetData(object sender, EventArgs e)
        {
            this.View.Model.Companies = this.companyService.GetAllCompanies();
        }
    }
}
