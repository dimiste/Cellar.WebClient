using Bills.MVP.ListaFacturas;
using Bills.MVP.SumaFacturas;
using Bills.Services;
using Cellar.Data;
using Cellar.Data.Models;
using Microsoft.AspNet.Identity;
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
    [PresenterBinding(typeof(SumaFacturasPresenter))]
    public partial class SumaFacturas : MvpPage<SumaFacturasViewModel>, ISumaFacturasView
    {
        public event EventHandler<GetContextEventArgs> OnListView1_GetData;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        public IList<SumBills> ListView1_GetData()
        {

            this.OnListView1_GetData?.Invoke(this, new GetContextEventArgs(this.Context));
            return this.Model.SumBills;
        }
    }
}