using Cellar.Data.Models;

using System.Linq;

namespace Bills.MVP.ListaFacturas
{
    public class ListaFacturasViewModel
    {
        public IQueryable<Bill> Bills { get; set; }
    }
}
