using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace DIPlayground.DI
{
    public class ServiceProviderDependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScopeFactory _scopeFactory;

        public ServiceProviderDependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
        }

        public IServiceScopeFactory ScopeFactory => _scopeFactory;

        public IDependencyScope BeginScope()
        {
            var scope = _scopeFactory.CreateScope();
            return new ServiceScopeDependencyResolver(scope);
        }

        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _serviceProvider.GetServices(serviceType);
        }

        public void Dispose()
        {
        }

        private sealed class ServiceScopeDependencyResolver : IDependencyScope
        {
            private readonly IServiceScope _scope;

            public ServiceScopeDependencyResolver(IServiceScope scope)
            {
                _scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }

            public object GetService(Type serviceType)
            {
                return _scope.ServiceProvider.GetService(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _scope.ServiceProvider.GetServices(serviceType);
            }

            public void Dispose()
            {
                _scope.Dispose();
            }
        }
    }
}