using Cellar.Data;
using Cellar.Data.Models;
using Cellar.Data.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Bills.Services
{
    public class BillService : IBillService
    {
        private readonly IBillsSystemContext billsSystemContext;
        private readonly ICompanyService companyService;
        private readonly EfRepository<Bill> context;

        public BillService(IBillsSystemContext billsSystemContext, ICompanyService companyService, EfRepository<Bill> context)
        {
            this.billsSystemContext = billsSystemContext;
            this.companyService = companyService;
            this.context = context;
        }

        public IQueryable<Bill> GetBillsByIdUser(string idUser)
        {
            //var bills = billsSystemContext.Bills.Where(b => b.IdUser == idUser).Include(b => b.Company);

            //return bills;

            return this.context.DbSet.Where(b => b.IdUser == idUser).Include(b => b.Company);
        }

        public Bill FindBillById(int id)
        {
            //var bill = billsSystemContext.Bills.Find(id);

            //return bill;

            return this.context.DbSet.Find(id);
        }

        public void RemoveBill(Bill bill)
        {
            //billsSystemContext.Bills.Remove(bill);

            this.context.DbSet.Remove(bill);
        }

        public IList<Bill> GetAllBills()
        {
            //return billsSystemContext.Bills.ToList();

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

        public IEnumerable<string> DistinctsMounths(IQueryable<Bill> bills)
        {
            //return bills.ToList().Select(b => b.Month).Distinct();

            return this.context.DbSet.ToList().Select(b => b.Month).Distinct();
        }
        
        public void DeleteBillByCheckedBox(ListView listView)
        {
            var listViewItems = listView.Items;

            foreach (var item in listViewItems)
            {
                CheckBox chkUser = item.FindControl("CheckBox") as CheckBox;

                if (chkUser != null & chkUser.Checked)
                {
                    //int.TryParse(item.FindControl("Id").ToString(), out int idChecked);
                    Label idChecked = (Label)item.FindControl("Id");
                    var id = int.Parse(idChecked.Text);

                    var bill = this.FindBillById(id);

                    this.RemoveBill(bill);
                    
                }
            }

            //this.billsSystemContext.SaveChanges();

            this.context.SaveChanges();
        }

        public void CreateBillFromForm(HttpContext context, Control control)
        {
            int lastIdBill = 0;

            Bill bill = new Bill();
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
                string path = "../img/" + (lastIdBill + 1).ToString() + Path.GetExtension(billScannedPostedFile.FileName);
                billScannedPostedFile.SaveAs(context.Server.MapPath(path));
                bill.BillScanned = path;
            }
            else
            {
                bill.BillScanned = "../img/FacturaNoEscaneada.pdf";
            }



            var dateBase = (HtmlInputGenericControl)control.FindControl("date");
            bill.Date = DateTime.Parse(dateBase.Value);

            //this.billsSystemContext.Bills.Add(bill);
            //this.billsSystemContext.SaveChanges();

            this.context.Add(bill);
            this.context.SaveChanges();
        }
    }
}
