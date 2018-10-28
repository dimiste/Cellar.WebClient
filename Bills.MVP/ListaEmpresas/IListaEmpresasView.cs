using Bills.MVP.ListaFacturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace Bills.MVP.ListaEmpresas
{
    public interface IListaEmpresasView : IView<ListaEmpresasViewModel>
    {
        event EventHandler OnListView1_GetData;

        event EventHandler<GetListViewEventArgs> OnButonEliminar_Click;
    }
}
