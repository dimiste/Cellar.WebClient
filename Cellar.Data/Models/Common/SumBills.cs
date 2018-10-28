using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Data.Models
{
    public class SumBills : ISumBills
    {

        public string Mes { get; set; }

        public double Exento { get; set; }

        public double BaseSuperReducido { get; set; }

        public double BaseReducido { get; set; }

        public double BaseNormal { get; set; }

        public double IVASuperReducido { get; set; }

        public double IVAReducido { get; set; }

        public double IVANormal { get; set; }

        public double BaseTotal { get; set; }

        public double IVATotal { get; set; }

        public double ImporteTotal { get; set; }

    }
}
