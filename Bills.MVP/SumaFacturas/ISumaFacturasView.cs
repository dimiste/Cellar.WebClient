using Bills.MVP.ListaFacturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace Bills.MVP.SumaFacturas
{
    public interface ISumaFacturasView : IView<SumaFacturasViewModel>
    {
        event EventHandler<GetContextEventArgs> OnListView1_GetData;
    }
}
