using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAppBanHang.DI;
using WebAppBanHang.Mapping;

namespace WebClinet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Đăng ký Mapping
            AutoMap.MapConfig();
            //Đăng ký DI
            DependencyInjection.ConfigAutofac();

            // GlobalFilters.Filters.Add(new ExceptionHandler());
        }
    }
}
