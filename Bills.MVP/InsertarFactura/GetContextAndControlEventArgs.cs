using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace Bills.MVP.InsertarEmpresa
{
    public class GetContextAndControlEventArgs : GetControlEventArgs
    {
        public HttpContext Context { get; set; }

        public GetContextAndControlEventArgs(HttpContext context, Control control)
            : base(control)
        {
            this.Context = context;
        }
    }
}
