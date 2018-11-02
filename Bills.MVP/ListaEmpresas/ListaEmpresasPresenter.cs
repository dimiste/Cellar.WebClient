using Bills.MVP.Commun;
using Bills.MVP.ListaFacturas;
using Bills.Services;
using Cellar.Data;

using System.Linq;

using Microsoft.AspNet.Identity;
using System;
using System.Web.ModelBinding;
using System.Web.UI;
using Cellar.Data.Models;
using Bills.MVP.CustomEventArgs;
using WebFormsMvp.Web;

namespace Bills.MVP.ListaEmpresas
{
    public class ListaEmpresasPresenter : PresenterCommun<IListaEmpresasView>
    {
        public ListaEmpresasPresenter(IListaEmpresasView view, IBillsSystemContext billsSystemContext, IBillService billService, ICompanyService companyService)
            : base(view, billsSystemContext, billService, companyService)
        {
            this.View.OnListView1_GetData += View_OnListView1_GetData;
            this.View.OnListView1_UpdateItem += View_OnListView1_UpdateItem;
        }

        private void View_OnListView1_UpdateItem(object sender, GetIdToUpdateItemEventArgs e)
        {
            Page page = (Page)sender;
            int idToUpdateItem = e.IdToUpdateItem;

            this.companyService.UpdateByIdCompany(page, idToUpdateItem);
        }

        private void View_OnListView1_GetData(object sender, GetContextEventArgs e)
        {
            var idUser = e.Context.User.Identity.GetUserId();
            //this.View.Model.Companies = this.billsSystemContext.Companies.Where(c => c.IdUser == idUser);
            this.View.Model.Companies = this.companyService.GetCompanyByIdUser(idUser);
        }
    }
}
