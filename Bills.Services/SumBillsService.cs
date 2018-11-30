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
                sumBills.Exento = Math.Round( billsSameMounths.Sum(b => b.Exento), 2);
                sumBills.BaseSuperReducido = Math.Round(billsSameMounths.Sum(b => b.Base4), 2);
                sumBills.BaseReducido = Math.Round(billsSameMounths.Sum(b => b.Base10), 2);
                sumBills.BaseNormal = Math.Round(billsSameMounths.Sum(b => b.Base21), 2);
                sumBills.IVASuperReducido = Math.Round(billsSameMounths.Sum(b => b.IVA4), 2);
                sumBills.IVAReducido = Math.Round(billsSameMounths.Sum(b => b.IVA10), 2);
                sumBills.IVANormal = Math.Round(billsSameMounths.Sum(b => b.IVA21), 2);
                sumBills.BaseTotal = Math.Round(billsSameMounths.Sum(b => b.Base4 + b.Base10 + b.Base21), 2);
                sumBills.IVATotal = Math.Round(billsSameMounths.Sum(b => b.IVA4 + b.IVA10 + b.IVA21) , 2);
                sumBills.ImporteTotal = Math.Round((sumBills.Exento + sumBills.BaseTotal + sumBills.IVATotal), 2);

                sumBillsTotals.Add(sumBills);
            }

            return sumBillsTotals;
        }
    }
}
