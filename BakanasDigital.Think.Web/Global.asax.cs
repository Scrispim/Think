
using BakanasDigital.Think.Infra.Data.Contexto;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BakanasDigital.Think.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            

            AutoMapper.AutoMapperConfig.RegisterMappings();

            Database.SetInitializer<ThinkContext>(null);
        }
    }
}
