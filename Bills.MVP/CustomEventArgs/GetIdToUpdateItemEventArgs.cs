using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Bills.MVP.CustomEventArgs
{
    public class GetIdToUpdateItemEventArgs : EventArgs
    {
        public int IdToUpdateItem { get; set; }

        public GetIdToUpdateItemEventArgs(int idToUpdateItem)
        {
            this.IdToUpdateItem = idToUpdateItem;
        }
    }
}
