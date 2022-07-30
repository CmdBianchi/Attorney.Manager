using Attorney.Manager.Repository.Context;
using Attorney.Manager.Repository.Implementation;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Attorney.Manager.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            new AttorneyManagerDbContext().Database.EnsureCreated();
        }
    }
}
