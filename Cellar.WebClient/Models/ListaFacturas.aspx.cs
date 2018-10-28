using Bills.MVP.ListaFacturas;
using Bills.Services;
using Cellar.Data;
using Cellar.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Cellar.WebClient
{
    [PresenterBinding(typeof(ListaFacturasPresenter))]
    public partial class Vinos : MvpPage<ListaFacturasViewModel>, IListaFacturasView
    {

        public event EventHandler<GetContextEventArgs> OnListView1_GetData;
        public event EventHandler<GetListViewEventArgs> OnButonEliminar_Click;

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

            this.OnButonEliminar_Click?.Invoke(this, new GetListViewEventArgs(this.ListView1));

            this.Context.Response.Redirect("ListaFacturas.aspx");
        }

    }
}