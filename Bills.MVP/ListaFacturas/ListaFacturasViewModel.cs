using Cellar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bills.MVP.ListaFacturas
{
    public class ListaFacturasViewModel
    {
        public IQueryable<Bill> Bills { get; set; }
    }
}
