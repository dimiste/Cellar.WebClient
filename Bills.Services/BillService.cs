using Cellar.Data.Models;
using Cellar.Data.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Bills.Services
{
    public class BillService : IBillService
    {
        private readonly ICompanyService companyService;
        private readonly IEfRepository<Bill> context;

        public BillService(ICompanyService companyService, IEfRepository<Bill> context)
        {
            this.companyService = companyService;
            this.context = context;
        }

        public IQueryable<Bill> GetBillsByIdUser(string idUser)
        {
            var bills = this.context.DbSet.Where(b => b.IdUser == idUser).Include(b => b.Company).ToArray();

            return bills.AsQueryable();
        }

        public Bill FindBillById(int id)
        {
            return this.context.DbSet.Find(id);
        }

        public void RemoveBill(Bill bill)
        {
            this.context.DbSet.Remove(bill);
        }

        public IList<Bill> GetAllBills()
        {
            return this.context.DbSet.ToList();
        }

        public int GetLastOrDefaultIdBill()
        {
            return this.GetAllBills().LastOrDefault().Id;
        }

        public IList<SumBills> CalculatorMounths(ISumBillsService sumBillsService, string idUser)
        {
            var firstBills = this.GetBillsByIdUser(idUser);
            var mounths = this.DistinctsMounths(firstBills);

            var sumBillsTotals = sumBillsService.CalculatorMounths(firstBills, mounths);

            return sumBillsTotals;
        }

        private IEnumerable<string> DistinctsMounths(IQueryable<Bill> bills)
        {
            return bills.ToList().Select(b => b.Month).Distinct();
        }

        public IList<Bill> FindBillsByCheckedBox(ListView listView)
        {
            var listViewItems = listView.Items;
            IList<Bill> findedsBills = new List<Bill>();

            foreach (var item in listViewItems)
            {
                CheckBox chkUser = item.FindControl("CheckBox") as CheckBox;

                if (chkUser != null & chkUser.Checked)
                {
                    Label idChecked = (Label)item.FindControl("Id");
                    var id = int.Parse(idChecked.Text);

                    var bill = this.FindBillById(id);
                    findedsBills.Add(bill);

                }
            }

            return findedsBills;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void CreateBillFromForm(HttpContext context, Control control)
        {
            int lastIdBill = 0;

            var id = context.Request.QueryString["Id"];
            var myBills = this.GetBillsByIdUser(context.User.Identity.GetUserId());

            Bill bill = null;

            if (!string.IsNullOrEmpty(id) && myBills != null)
            {
                bill = this.FindBillById(int.Parse(id));
            }
            else
            {
                bill = new Bill();
            }


            var month = (HtmlSelect)control.FindControl("month");
            var year = DateTime.Now.Year.ToString();
            bill.Month = year + month.Value;

            var idUser = context.User.Identity.GetUserId();

            bill.IdUser = idUser;

            if (this.GetAllBills().Count > 0)
            {
                lastIdBill = this.GetLastOrDefaultIdBill();
            }

            var companyBase = (HtmlInputText)control.FindControl("company");
            var company = this.companyService.GetCompanyByName(companyBase.Value);
            bill.Company = company;

            var exentoBase = (HtmlInputText)control.FindControl("exento");
            if (string.IsNullOrEmpty(exentoBase.Value))
            {
                bill.Exento = 0;
            }
            else
            {
                bill.Exento = double.Parse(exentoBase.Value);
            }

            var base4Base = (HtmlInputText)control.FindControl("base4");
            if (string.IsNullOrEmpty(base4Base.Value))
            {
                bill.Base4 = 0;
            }
            else
            {
                bill.Base4 = double.Parse(base4Base.Value);
            }

            var base10Base = (HtmlInputText)control.FindControl("base10");
            if (string.IsNullOrEmpty(base10Base.Value))
            {
                bill.Base10 = 0;
            }
            else
            {
                bill.Base10 = double.Parse(base10Base.Value);
            }

            var base21Base = (HtmlInputText)control.FindControl("base21");
            if (string.IsNullOrEmpty(base21Base.Value))
            {
                bill.Base21 = 0;
            }
            else
            {
                bill.Base21 = double.Parse(base21Base.Value);
            }

            var billScanned = (HtmlInputFile)control.FindControl("bill");
            var billScannedPostedFile = billScanned.PostedFile;


            // también se podría haber subido el archivo con el controlador "FileUpload" de asp.net. Para verificar si existe archvo sería: "FileUpload.HasFile"
            if (billScannedPostedFile.ContentLength > 0)
            {
                string path = string.Empty;
                if (!string.IsNullOrEmpty(context.Request.QueryString["Id"]))
                {
                    path = "../img/" + context.Request.QueryString["Id"] + Path.GetExtension(billScannedPostedFile.FileName);
                }
                else
                {
                    path = "../img/" + (lastIdBill + 1).ToString() + Path.GetExtension(billScannedPostedFile.FileName);
                }

                billScannedPostedFile.SaveAs(context.Server.MapPath(path));
                bill.BillScanned = path;
            }
            else
            {
                if (!string.IsNullOrEmpty(context.Request.QueryString["BillScanned"]))
                {
                    bill.BillScanned = context.Request.QueryString["BillScanned"];
                }
                else
                {
                    bill.BillScanned = "../img/FacturaNoEscaneada.pdf";
                }

            }



            var dateBase = (HtmlInputGenericControl)control.FindControl("date");
            bill.Date = DateTime.Parse(dateBase.Value);

            if (string.IsNullOrEmpty(id))
            {
                this.context.Add(bill);
            }


            this.context.SaveChanges();
        }
    }
}
