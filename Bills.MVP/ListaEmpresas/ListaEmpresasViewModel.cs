using Cellar.Data.Models;

using System.Linq;

namespace Bills.MVP.ListaEmpresas
{
    public class ListaEmpresasViewModel
    {
        public IQueryable<Company> Companies { get; set; }
    }
}
