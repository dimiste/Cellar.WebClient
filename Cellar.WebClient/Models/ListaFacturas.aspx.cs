using Bills.MVP.ListaFacturas;
using Cellar.Data.Models;

using System;
using System.Linq;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace Cellar.WebClient
{
    [PresenterBinding(typeof(ListaFacturasPresenter))]
    public partial class Vinos : MvpPage<ListaFacturasViewModel>, IListaFacturasView
    {

        public event EventHandler<GetContextEventArgs> OnListView1_GetData;
        public event EventHandler OnButonEliminar_Click;
        public event EventHandler OnButonEditar_Click;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // El tipo devuelto puede ser modificado a IEnumerable, sin embargo, para ser compatible con paginación y ordenación 
        // , se deben agregar los siguientes parametros:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression

        public IQueryable<Bill> ListView1_GetData()
        {

            this.OnListView1_GetData?.Invoke(this, new GetContextEventArgs(this.Context));

            var bills = this.Model.Bills;
            return bills;
        }


        protected void ButonEliminar_Click(object sender, EventArgs e)
        {

            this.OnButonEliminar_Click?.Invoke(this, null);

            this.Context.Response.Redirect("ListaFacturas.aspx");
        }

        protected void ButonEditar_Click(object sender, EventArgs e)
        {

            this.OnButonEditar_Click?.Invoke(this, null);
        }

    }
}