using System;

using WebFormsMvp;

namespace Bills.MVP.ListaFacturas
{
    public interface IListaFacturasView : IView<ListaFacturasViewModel>
    {
        event EventHandler<GetContextEventArgs> OnListView1_GetData;
        event EventHandler OnButonEliminar_Click;
        event EventHandler OnButonEditar_Click;
        event EventHandler<GetContextEventArgs> OnListView1_DataBound;
    }
}
