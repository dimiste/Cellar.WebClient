using System.Collections.Generic;
using System.Linq;
using Cellar.Data.Models;

namespace Bills.Services
{
    public interface IBillService
    {
        IQueryable<Bill> GetBillsByIdUser(string idUser);

        Bill FindBillById(int id);

        void RemoveBill(Bill bill);

        IList<Bill> GetAllBills();

        int GetLastOrDefaultIdBill();

        IList<SumBills> CalculatorMounths(string idUser);
    }   
}