using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace Bills.MVP.ListaFacturas
{
    public interface IListaFacturasView : IView<ListaFacturasViewModel>
    {
        event EventHandler<GetContextEventArgs> OnListView1_GetData;

        event EventHandler<GetListViewEventArgs> OnButonEliminar_Click;
    }
}
