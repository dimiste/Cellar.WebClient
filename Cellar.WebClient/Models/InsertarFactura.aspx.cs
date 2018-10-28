using Bills.MVP.InsertarEmpresa;
using Bills.MVP.ListaFacturas;
using Bills.Services;
using Cellar.Data;
using Cellar.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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
    [PresenterBinding(typeof(InsertarFacturaPresenter))]
    public partial class InsertarFactura : MvpPage<ListaFacturasViewModel>, IInsertarFacturaView
    {
        private Control control;

        public event EventHandler<GetContextAndControlEventArgs> OnSubmitProcess;
        public event EventHandler<GetControlEventArgs> OnServerValidation;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.control = this.Master.FindControl("ContentPlaceHolder1");
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
            this.OnSubmitProcess?.Invoke(this, new GetContextAndControlEventArgs(this.Context, this.control));
        }

        public void ServerValidation()
        {
            this.OnServerValidation?.Invoke(this, new GetControlEventArgs(this.control));
        }

    }
}