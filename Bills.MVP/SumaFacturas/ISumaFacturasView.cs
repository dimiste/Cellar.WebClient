using Bills.MVP.ListaFacturas;

using System;

using WebFormsMvp;

namespace Bills.MVP.SumaFacturas
{
    public interface ISumaFacturasView : IView<SumaFacturasViewModel>
    {
        event EventHandler<GetContextEventArgs> OnListView1_GetData;
    }
}
