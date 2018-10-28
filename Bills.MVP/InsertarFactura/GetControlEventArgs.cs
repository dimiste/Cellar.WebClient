using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Bills.MVP.InsertarEmpresa
{
    public class GetControlEventArgs : EventArgs
    {
        public Control Control { get; set; }

        public GetControlEventArgs(Control control)
        {
            this.Control = control;
        }
    }
}
