using Cellar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bills.MVP.InsertarFactura
{
    public class InsertarFacturaViewModel
    {
        public bool IsBillMine { get; set; }

        public int PositionMonth { get; set; }

        public IQueryable<Bill> Bills { get; set; }
    }
}
