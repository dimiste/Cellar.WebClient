using Bills.MVP.ListaFacturas;

using System;

using WebFormsMvp;

namespace Bills.MVP.InsertarEmpresa
{
    public interface IInsertarFacturaView : IView
    {
        event EventHandler<GetContextEventArgs> OnSubmitProcess;
        event EventHandler<GetContextEventArgs> OnServerValidation;
    }
}
