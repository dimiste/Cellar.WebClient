using Bills.MVP.InsertarEmpresa;
using Bills.MVP.ListaFacturas;

using System;
using System.Web.UI;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace Cellar.WebClient.Models
{
    [PresenterBinding(typeof(InsertarEmpresaPresenter))]
    public partial class InsertarEmpresa : MvpPage<ListaFacturasViewModel>, IInsertarEmpresaView
    {
        public event EventHandler<GetContextEventArgs> OnInsertCompany;
        public event EventHandler<GetContextEventArgs> OnServerValidation;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertCompany(object sender, EventArgs e)
        {
            this.ServerValidation();

            if (Page.IsValid)
            {
                this.OnInsertCompany?.Invoke(this, new GetContextEventArgs(this.Context));

                this.Context.Response.Redirect("EmpresaGuardada");
            }
            
        }

        public void ServerValidation()
        {
            this.OnServerValidation?.Invoke(this, new GetContextEventArgs(this.Context));
        }
    }
}