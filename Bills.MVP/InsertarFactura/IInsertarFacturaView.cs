using Bills.MVP.ListaFacturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Bills.MVP.InsertarEmpresa
{
    public interface IInsertarFacturaView : IView<ListaFacturasViewModel>
    {
        event EventHandler<GetContextAndControlEventArgs> OnSubmitProcess;
        event EventHandler<GetControlEventArgs> OnServerValidation;
    }
}
