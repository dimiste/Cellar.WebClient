using Bills.Services;
using Cellar.Data;

using WebFormsMvp;

namespace Bills.MVP.Commun
{
    public class PresenterCommun<T> : Presenter<T> where T : class, IView
    {
        public readonly IBillsSystemContext billsSystemContext;
        public readonly IBillService billService;
        public readonly ICompanyService companyService;

        public PresenterCommun(T view, IBillsSystemContext billsSystemContext, IBillService billService, ICompanyService companyService)
            : base(view)
        {
            this.billsSystemContext = billsSystemContext;
            this.billService = billService;
            this.companyService = companyService;
        }
    }
}
