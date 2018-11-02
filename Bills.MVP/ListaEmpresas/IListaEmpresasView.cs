using Bills.MVP.CustomEventArgs;
using Bills.MVP.ListaFacturas;

using System;

using WebFormsMvp;

namespace Bills.MVP.ListaEmpresas
{
    public interface IListaEmpresasView : IView<ListaEmpresasViewModel>
    {
        event EventHandler<GetContextEventArgs> OnListView1_GetData;
        event EventHandler<GetIdToUpdateItemEventArgs> OnListView1_UpdateItem;

    }
}
