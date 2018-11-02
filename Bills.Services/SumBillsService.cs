using Cellar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bills.Services
{
    public class SumBillsService : ISumBillsService
    {
        public IList<SumBills> CalculatorMounths(IQueryable<Bill> bills, IEnumerable<string> mounths)
        {
            IList<SumBills> sumBillsTotals = new List<SumBills>();

            foreach (var item in mounths)
            {
                SumBills sumBills = new SumBills();
                sumBills.Mes = item;
                var billsSameMounths = bills.Where(b => b.Month == item).ToList();
                sumBills.Exento = billsSameMounths.Sum(b => b.Exento);
                sumBills.BaseSuperReducido = billsSameMounths.Sum(b => b.Base4);
                sumBills.BaseReducido = billsSameMounths.Sum(b => b.Base10);
                sumBills.BaseNormal = billsSameMounths.Sum(b => b.Base21);
                sumBills.IVASuperReducido = billsSameMounths.Sum(b => b.IVA4);
                sumBills.IVAReducido = billsSameMounths.Sum(b => b.IVA10);
                sumBills.IVANormal = billsSameMounths.Sum(b => b.IVA21);
                sumBills.BaseTotal = billsSameMounths.Sum(b => b.Base4 + b.Base10 + b.Base21);
                sumBills.IVATotal = billsSameMounths.Sum(b => b.IVA4 + b.IVA10 + b.IVA21);
                sumBills.ImporteTotal = sumBills.Exento + sumBills.BaseTotal + sumBills.IVATotal;

                sumBillsTotals.Add(sumBills);
            }

            return sumBillsTotals;
        }
    }
}
