﻿using Bills.Services;
using Cellar.Data;
using Bills.MVP.Commun;

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

using Microsoft.AspNet.Identity;

using WebFormsMvp.Web;
using Cellar.Data.Models;

namespace Bills.MVP.ListaFacturas
{
    public class ListaFacturasPresenter : PresenterCommun<IListaFacturasView>
    {
        public ListaFacturasPresenter(IListaFacturasView view, IBillsSystemContext billSystemContext, IBillService billService, ICompanyService companyService)
            : base(view, billSystemContext, billService, companyService)
        {
            this.View.OnListView1_GetData += View_OnListView1_GetData;
            this.View.OnButonEliminar_Click += View_OnButonEliminar_Click;
            this.View.OnButonEditar_Click += View_OnButonEditar_Click;
            this.View.OnListView1_DataBound += View_OnListView1_DataBound;
        }

        private void View_OnListView1_DataBound(object sender, GetContextEventArgs e)
        {
            var sen = sender as MvpPage;
            var control = sen.Master.FindControl("ContentPlaceHolder1") as Control;

            var listView = this.FindListView(sender);
            var idUser = e.Context.User.Identity.GetUserId();
            var billsById = this.billService.GetBillsByIdUser(idUser).ToArray();

            int counter = 0;

            foreach (var item in listView.Items)
            {
                HyperLink hyperLink = item.FindControl("VerFactura") as HyperLink;

                if (hyperLink != null && hyperLink.ID == "VerFactura" && (billsById[counter].BillScanned == "../img/FacturaNoEscaneada.pdf" || string.IsNullOrEmpty(billsById[counter].BillScanned)))
                {
                    hyperLink.Visible = false;
                }

                counter++;
            }
        }

        private void View_OnButonEditar_Click(object sender, EventArgs e)
        {
            ListView listView = this.FindListView(sender);

            var findedsBills = this.billService.FindBillsByCheckedBox(listView);

            string day = findedsBills[0].Date.Day.ToString();

            if (findedsBills[0].Date.Day < 10)
            {
                day = "0" + day;
            }



            this.Response.Redirect("InsertarFactura.aspx?Id=" + findedsBills[0].Id + "&Company=" + findedsBills[0].Company.Name + "&Exento=" + findedsBills[0].Exento + "&Base4=" + findedsBills[0].Base4 + "&Base10=" + findedsBills[0].Base10 + "&Base21=" + findedsBills[0].Base21 + "&Month=" + findedsBills[0].Month.Substring(5) + "&Date=" + findedsBills[0].Date.Year + "-" + findedsBills[0].Date.Month + "-" + day + "&BillScanned=" + findedsBills[0].BillScanned);
        }

        private void View_OnButonEliminar_Click(object sender, EventArgs e)
        {
            ListView listView = this.FindListView(sender);

            var findedsBills = this.billService.FindBillsByCheckedBox(listView);

            foreach (var bill in findedsBills)
            {
                this.billService.RemoveBill(bill);
            }

            this.billService.SaveChanges();
        }

        private ListView FindListView(object sender)
        {
            var sen = sender as MvpPage;
            var control = sen.Master.FindControl("ContentPlaceHolder1") as Control;
            var listView = (ListView)control.FindControl("ListView1");

            return listView;
        }

        private void View_OnListView1_GetData(object sender, GetContextEventArgs e)
        {
            var listView = this.FindListView(sender);

            var idUser = e.Context.User.Identity.GetUserId();
            this.View.Model.Bills = this.billService.GetBillsByIdUser(idUser);

            //int counter = 0;

            //var contarListView = listView.Items.Count;

            //foreach (var item in listView.Items)
            //{
            //    HyperLink hyperLink = item.FindControl("VerFactura") as HyperLink;

            //    //if (billsToArray[counter].BillScanned == "../img/FacturaNoEscaneada.pdf" || string.IsNullOrEmpty(billsToArray[counter].BillScanned))
            //    //{

            //    //}

            //    if (hyperLink != null && hyperLink.ID == "VerFactura")
            //    {
            //        var result = hyperLink.NavigateUrl;
            //        hyperLink.NavigateUrl = "google.es";
            //        HyperLink hyperLinkGoogle = control.FindControl("google") as HyperLink;
            //        hyperLinkGoogle.Text = "Hola";
            //    }

                

            //    counter++;
            //}
        }

    }
}
