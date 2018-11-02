using Bills.MVP.InsertarEmpresa;
using Bills.MVP.ListaFacturas;

using System;
using System.Web.UI;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace Cellar.WebClient
{
    [PresenterBinding(typeof(InsertarFacturaPresenter))]
    public partial class InsertarFactura : MvpPage<ListaFacturasViewModel>, IInsertarFacturaView
    {

        public event EventHandler<GetContextEventArgs> OnSubmitProcess;
        public event EventHandler<GetContextEventArgs> OnServerValidation;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValidateBtn_OnClick(object sender, EventArgs e)
        {
            this.ServerValidation();

            if (Page.IsValid)
            {
                try
                {
                    this.SubmitProcess();
                    this.Context.Response.Redirect("FacturaGrabada");
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public void SubmitProcess()
        {
            this.OnSubmitProcess?.Invoke(this, new GetContextEventArgs(this.Context));
        }

        public void ServerValidation()
        {
            this.OnServerValidation?.Invoke(this, new GetContextEventArgs(this.Context));
        }

    }
}