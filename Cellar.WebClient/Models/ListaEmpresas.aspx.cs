using Bills.MVP.ListaEmpresas;
using Bills.MVP.ListaFacturas;
using Cellar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Cellar.WebClient.Models
{
    [PresenterBinding(typeof(ListaEmpresasPresenter))]
    public partial class ListaEmpresas : MvpPage<ListaEmpresasViewModel>, IListaEmpresasView
    {
        public event EventHandler OnListView1_GetData;
        public event EventHandler<GetListViewEventArgs> OnButonEliminar_Click;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Company> ListView1_GetData()
        {

            this.OnListView1_GetData?.Invoke(this, null);

            var companies = this.Model.Companies;
            return companies;
        }

        protected void ButonEliminar_Click(object sender, EventArgs e)
        {

            this.OnButonEliminar_Click?.Invoke(this, new GetListViewEventArgs(this.ListView1));

            this.Context.Response.Redirect("ListaEmpresas.aspx");
        }
    }
}