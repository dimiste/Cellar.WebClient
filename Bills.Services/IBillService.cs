using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

        IList<SumBills> CalculatorMounths(ISumBillsService sumBillsService, string idUser);

        void DeleteBillByCheckedBox(ListView listView);

        void CreateBillFromForm(HttpContext context, Control control);
    }   
}