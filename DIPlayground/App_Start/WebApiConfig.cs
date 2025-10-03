using DIPlayground.DI;
using DIPlayground.Services;
using DIPlayground.Services.DictionaryManager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace DIPlayground
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Servizi e configurazione dell'API Web
            var services = new ServiceCollection();
            services.AddSingleton<IDictionaryProvider, FallbackDictionaryProvider>();
            services.AddTransient<IMyConsumerService, MyConsumerService >();
            RegisterApiControllers(services);

            var serviceProvider = services.BuildServiceProvider();
            var dependencyResolver = new ServiceProviderDependencyResolver(serviceProvider);
            config.DependencyResolver = dependencyResolver;

            var activator = new ServiceProviderHttpControllerActivator(dependencyResolver.ScopeFactory);
            config.Services.Replace(typeof(IHttpControllerActivator), activator);

            // Route dell'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void RegisterApiControllers(IServiceCollection services)
        {
            var controllerTypes = typeof(WebApiConfig).Assembly
                .GetTypes()
                .Where(type => !type.IsAbstract && typeof(ApiController).IsAssignableFrom(type));

            foreach (var controllerType in controllerTypes)
            {
                services.AddTransient(controllerType);
            }
        }
    }
}
