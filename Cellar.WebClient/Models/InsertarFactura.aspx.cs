using Bills.MVP.InsertarEmpresa;
using Bills.MVP.ListaFacturas;
using Cellar.Data.Models;
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
            if (!Page.IsPostBack)
            {

                if (!string.IsNullOrEmpty(this.Context.Request.QueryString["Id"]))
                {
                    var company = this.Context.Request.QueryString["Company"];
                    this.company.Value = company;

                    var exento = this.Context.Request.QueryString["Exento"];
                    this.exento.Value = exento;

                    var base4 = this.Context.Request.QueryString["Base4"];
                    this.base4.Value = base4;

                    var base10 = this.Context.Request.QueryString["Base10"];
                    this.base10.Value = base10;

                    var base21 = this.Context.Request.QueryString["Base21"];
                    this.base21.Value = base21;

                    var mounth = this.Context.Request.QueryString["Month"];
                    this.month.SelectedIndex = int.Parse(mounth);

                    var date = this.Context.Request.QueryString["Date"];
                    this.date.Value = date;
                }

            }
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

        protected void CancelarBtn_OnClick(object sender, EventArgs e)
        {
            this.Context.Response.Redirect("ListaFacturas.aspx");
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