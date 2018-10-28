using Bills.MVP.InsertarEmpresa;
using Bills.MVP.ListaFacturas;
using Bills.Services;
using Cellar.Data;
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
    [PresenterBinding(typeof(InsertarEmpresaPresenter))]
    public partial class InsertarEmpresa : MvpPage<ListaFacturasViewModel>, IInsertarEmpresaView
    {
        public event EventHandler<GetCompanyEventArgs> OnInsertCompany;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertCompany(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                var companyBase = (TextBox)this.Master.FindControl("ContentPlaceHolder1").FindControl("company");

                this.OnInsertCompany?.Invoke(this, new GetCompanyEventArgs(companyBase));

                this.Context.Response.Redirect("EmpresaGuardada");
            }
            
        }
    }
}