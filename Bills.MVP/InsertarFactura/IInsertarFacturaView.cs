using Bills.MVP.CustomEventArgs;
using Bills.MVP.InsertarFactura;
using Bills.MVP.ListaFacturas;

using System;

using WebFormsMvp;

namespace Bills.MVP.InsertarEmpresa
{
    public interface IInsertarFacturaView : IView<InsertarFacturaViewModel>
    {
        event EventHandler<GetContextEventArgs> OnSubmitProcess;
        event EventHandler<GetContextEventArgs> OnServerValidation;
        event EventHandler OnFixMonth;

        // TODO
        //event EventHandler<GetIdBillEventArgs> OnEditBill;
    }
}
