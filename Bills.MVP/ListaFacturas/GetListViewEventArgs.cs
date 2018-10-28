using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Bills.MVP.ListaFacturas
{
    public class GetListViewEventArgs : EventArgs
    {
        public ListView ListView { get; set; }

        public GetListViewEventArgs(ListView listView)
        {
            this.ListView = listView;
        }
    }
}
