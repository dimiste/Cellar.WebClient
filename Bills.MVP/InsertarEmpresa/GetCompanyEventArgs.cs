using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Bills.MVP.InsertarEmpresa
{
    public class GetCompanyEventArgs : EventArgs
    {
        public TextBox Company { get; set; }

        public GetCompanyEventArgs(TextBox company)
        {
            this.Company = company;
        }
    }
}
