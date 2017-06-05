[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BakanasDigital.Think.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BakanasDigital.Think.Web.App_Start.NinjectWebCommon), "Stop")]

namespace BakanasDigital.Think.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using BakanasDigital.Think.Application.Interface;
    using BakanasDigital.Think.Application;
    using BakanasDigital.Think.Domain.Interfaces.Services;
    using BakanasDigital.Think.Domain.Services;
    using BakanasDigital.Think.Domain.Interfaces.Repositories;
    using BakanasDigital.Think.Infra.Data.Repositories;

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
            //TypeOf para ser genérico, sendo assim ele não sabe oque vai receber ainda.

            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            kernel.Bind<ICidadeAppService>().To<CidadeAppService>();
            kernel.Bind<IEstadoAppService>().To<EstadoAppService>();
            kernel.Bind<ICartaoCreditoAppService>().To<CartaoCreditoAppService>();
            //kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IClienteService>().To<ClienteService>();
            kernel.Bind<ICidadeService>().To<CidadeService>();
            kernel.Bind<IEstadoService>().To<EstadoService>();
            kernel.Bind<ICartaoCreditoService>().To<CartaoCreditoService>();
            //kernel.Bind<IProdutoService>().To<ProdutoService>();

            //Correto seria criar um módulo para não ter referencia do Data
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<ICidadeRepository>().To<CidadeRepository>();
            kernel.Bind<IEstadoRepository>().To<EstadoRepository>();
            kernel.Bind<ICartaoCreditoRepository>().To<CartaoCreditoRepository>();
            //kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
        }        
    }
}
