using Cellar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bills.MVP.ListaEmpresas
{
    public class ListaEmpresasViewModel
    {
        public IQueryable<Company> Companies { get; set; }
    }
}
