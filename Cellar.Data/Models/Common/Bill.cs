using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Data.Models
{
    public class Bill : IBill
    {

        public int Id { get; set; }

        public double Exento { get; set; }

        public double Base4 { get; set; }

        public double Base10 { get; set; }

        public double Base21 { get; set; }

        public double IVA4 { get { return this.Base4 * 0.04; } }

        public double IVA10 { get { return this.Base10 * 0.10; } }

        public double IVA21 { get { return this.Base21 * 0.21; } }

        public string Month { get; set; }

        public DateTime Date { get; set; }

        public Company Company { get; set; }

        public string IdUser { get; set; }

        public string BillScanned { get; set; }

        public double TotalBill {

            get {
                return this.Exento + this.Base4 + this.Base10 + this.Base21 + this.IVA4 + this.IVA10 + this.IVA21;
            }
        }

    }
}
