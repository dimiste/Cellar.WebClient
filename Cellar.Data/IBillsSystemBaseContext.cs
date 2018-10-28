using Cellar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Data
{
    public interface IBillsSystemBaseContext
    {
        int SaveChanges();

    }
}
