using Cellar.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Data
{
    public interface IBillsSystemContext : IBillsSystemBaseContext
    {
        IDbSet<Company> Companies { get; set; }

        IDbSet<Bill> Bills { get; set; }

        DbEntityEntry Entry(object entity);
    }
}
