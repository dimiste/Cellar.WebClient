using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace Bills.MVP.InsertarEmpresa
{
    public interface IInsertarEmpresaView : IView
    {
        event EventHandler<GetCompanyEventArgs> OnInsertCompany;
    }
}
