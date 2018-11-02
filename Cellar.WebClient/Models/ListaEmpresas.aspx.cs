using Bills.MVP.CustomEventArgs;
using Bills.MVP.ListaEmpresas;
using Bills.MVP.ListaFacturas;
using Cellar.Data;
using Cellar.Data.Models;

using System;
using System.Linq;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace Cellar.WebClient.Models
{
    [PresenterBinding(typeof(ListaEmpresasPresenter))]
    public partial class ListaEmpresas : MvpPage<ListaEmpresasViewModel>, IListaEmpresasView
    {
        public event EventHandler<GetContextEventArgs> OnListView1_GetData;
        public event EventHandler<GetIdToUpdateItemEventArgs> OnListView1_UpdateItem;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<ICompany> ListView1_GetData()
        {

            this.OnListView1_GetData?.Invoke(this, new GetContextEventArgs(this.Context));

            var companies = this.Model.Companies;
            return companies;
        }


        // El nombre de parámetro del id. debe coincidir con el valor DataKeyNames establecido en el control
        public void ListView1_UpdateItem(int id)
        {
            this.OnListView1_UpdateItem?.Invoke(this, new GetIdToUpdateItemEventArgs(id));
        }
    }
}