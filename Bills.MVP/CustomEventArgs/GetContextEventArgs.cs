using System;
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
