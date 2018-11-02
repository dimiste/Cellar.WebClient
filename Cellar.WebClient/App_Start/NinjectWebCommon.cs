[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Cellar.WebClient.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Cellar.WebClient.App_Start.NinjectWebCommon), "Stop")]

namespace Cellar.WebClient.App_Start
{
    using System;
    using System.Linq;
    using System.Web;
    using Bills.Services;
    using Cellar.Data;
    using Cellar.WebClient.NinjectBindingsModules;
    using Cellar.WebClient.PresenterFactories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Activation;
    using Ninject.Extensions.Factory;
    using Ninject.Parameters;
    using Ninject.Web.Common;
    using WebFormsMvp;
    using WebFormsMvp.Binder;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(Kernel);
                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        public static IKernel Kernel { get; private set; }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(new MvpNinjectModule());

            PresenterBinder.Factory = kernel.Get<IPresenterFactory>();

            kernel.Bind(typeof(IBillsSystemContext), typeof(IBillsSystemBaseContext))
                .To<BillsSystemContext>().InRequestScope();

            kernel.Bind<IBillService>().To<BillService>();
            kernel.Bind<ICompanyService>().To<CompanyService>();
            kernel.Bind<ISumBillsService>().To<SumBillsService>();
        }
    }
}
