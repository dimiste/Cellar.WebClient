using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bills.MVP.CustomEventArgs
{
    public class GetIdBillEventArgs : EventArgs
    {
        public int IdBill { get; set; }

        public GetIdBillEventArgs(int idBill)
        {
            this.IdBill = idBill;
        }
    }
}
