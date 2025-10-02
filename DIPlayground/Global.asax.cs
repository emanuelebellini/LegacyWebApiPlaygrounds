using DIPlayground.Controllers;
using DIPlayground.DI;
using DIPlayground.Services;
using DIPlayground.Services.DictionaryManager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DIPlayground
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            var services = new ServiceCollection();
            services.AddSingleton<IDictionaryProvider, FallbackDictionaryProvider>();
            services.AddTransient<MyConsumerService>();
            services.AddTransient<ValuesController>();
            var root = services.BuildServiceProvider();

            DependencyResolver.SetResolver(new MsDiMvcResolver(root));
        }
    }
}
