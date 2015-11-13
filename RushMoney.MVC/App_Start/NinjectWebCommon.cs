[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RushMoney.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(RushMoney.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace RushMoney.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using RushMoney.Application.Interfaces;
    using RushMoney.Application;
    using RushMoney.Domain.Interfaces.Services;
    using RushMoney.Domain.Services;
    using RushMoney.Domain.Interfaces.Repositories;
    using RushMoney.Infra.Data.Repositories;

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
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IClientAppService>().To<ClientAppService>();
            kernel.Bind<ITransactionAppService>().To<TransactionAppService>();
            kernel.Bind<IAccountAppService>().To<AccountAppService>();
            kernel.Bind<ICategoryAppService>().To<CategoryAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IClientService>().To<ClientService>();
            kernel.Bind<ITransactionService>().To<TransactionService>();
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));;
            kernel.Bind<IClientRepository>().To<ClientRepository>();
            kernel.Bind<ITransactionRepository>().To<TransactionRepository>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
        }        
    }
}

