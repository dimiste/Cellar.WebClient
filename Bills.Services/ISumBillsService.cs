using System.Collections.Generic;
using System.Linq;
using Cellar.Data.Models;

namespace Bills.Services
{
    public interface ISumBillsService
    {
        IList<SumBills> CalculatorMounths(IQueryable<Bill> bills, IEnumerable<string> mounths);
    }
}