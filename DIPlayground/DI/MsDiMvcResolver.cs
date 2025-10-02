using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIPlayground.DI
{
    public class MsDiMvcResolver : IDependencyResolver
    {
        private const string ScopeKey = "__msdi_scope";

        private readonly IServiceProvider _root;
        public MsDiMvcResolver(IServiceProvider root) => _root = root;

        private static IServiceProvider TryCurrentScope()
        => (HttpContext.Current?.Items[ScopeKey] as IServiceScope)?.ServiceProvider;

        private IServiceProvider CurrentScopeProvider =>
            TryCurrentScope() ?? _root;

        public object GetService(Type serviceType)
        {
            var sp = CurrentScopeProvider;
            var svc = sp.GetService(serviceType);
            if (svc != null) return svc;

            // If it's an MVC controller, try to construct it with DI even if not registered
            if (typeof(IControllerFactory).IsAssignableFrom(serviceType) && !serviceType.IsAbstract)
                return ActivatorUtilities.CreateInstance(sp, serviceType);

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType) =>
            (CurrentScopeProvider ?? _root).GetServices(serviceType);
    }

}