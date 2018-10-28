using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bills.MVP.ListaFacturas
{
    public class GetContextEventArgs : EventArgs
    {
        public HttpContext Context { get; set; }

        public GetContextEventArgs(HttpContext context)
        {
            this.Context = context;
        }
    }
}
