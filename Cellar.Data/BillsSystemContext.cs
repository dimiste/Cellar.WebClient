using Cellar.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Data
{
    public class BillsSystemContext : DbContext, IBillsSystemContext
    {
        public BillsSystemContext()
            : base("VinotecaDbContext")
        {

        }

        public IDbSet<Company> Companies { get; set; }

        public IDbSet<Bill> Bills { get; set; }
    }
}
