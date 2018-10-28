using Cellar.Data;
using Cellar.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bills.Services
{
    public class BillService : IBillService
    {
        private readonly IBillsSystemContext billsSystemContext;

        public BillService(IBillsSystemContext billsSystemContext)
        {
            this.billsSystemContext = billsSystemContext;
        }

        public IQueryable<Bill> GetBillsByIdUser(string idUser)
        {
            var bills = billsSystemContext.Bills.Where(b => b.IdUser == idUser).Include(b => b.Company);

            return bills;
        }

        public Bill FindBillById(int id)
        {
            var bills = billsSystemContext.Bills.Find(id);

            return bills;
        }

        public void RemoveBill(Bill bill)
        {
            billsSystemContext.Bills.Remove(bill);
        }

        public IList<Bill> GetAllBills()
        {
            return billsSystemContext.Bills.ToList();
        }

        public int GetLastOrDefaultIdBill()
        {
            return this.GetAllBills().LastOrDefault().Id;
        }

        public IList<SumBills> CalculatorMounths(string idUser)
        {
            var firstBills = this.billsSystemContext.Bills.Where(b => b.IdUser == idUser);
            var mounths = firstBills.ToList().Select(b => b.Month).Distinct();

            IList<SumBills> sumBillsTotals = new List<SumBills>();

            foreach (var item in mounths)
            {
                SumBills sumBills = new SumBills();
                sumBills.Mes = item;
                var bills = firstBills.Where(b => b.Month == item).ToList();
                sumBills.Exento = bills.Sum(b => b.Exento);
                sumBills.BaseSuperReducido = bills.Sum(b => b.Base4);
                sumBills.BaseReducido = bills.Sum(b => b.Base10);
                sumBills.BaseNormal = bills.Sum(b => b.Base21);
                sumBills.IVASuperReducido = bills.Sum(b => b.IVA4);
                sumBills.IVAReducido = bills.Sum(b => b.IVA10);
                sumBills.IVANormal = bills.Sum(b => b.IVA21);
                sumBills.BaseTotal = bills.Sum(b => b.Base4 + b.Base10 + b.Base21);
                sumBills.IVATotal = bills.Sum(b => b.IVA4 + b.IVA10 + b.IVA21);
                sumBills.ImporteTotal = sumBills.Exento + sumBills.BaseTotal + sumBills.IVATotal;

                sumBillsTotals.Add(sumBills);
            }

            return sumBillsTotals;
        }
    }
}
