using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TemplateApp.Core.DI;

namespace TemplateApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityManager.Instance.RegisterAllSetups();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
