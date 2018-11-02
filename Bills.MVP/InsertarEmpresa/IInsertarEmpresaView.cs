using Bills.MVP.ListaFacturas;
using System;

using WebFormsMvp;

namespace Bills.MVP.InsertarEmpresa
{
    public interface IInsertarEmpresaView : IView
    {
        event EventHandler<GetContextEventArgs> OnInsertCompany;
        event EventHandler<GetContextEventArgs> OnServerValidation;
    }
}
