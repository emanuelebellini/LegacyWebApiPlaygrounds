using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace DIPlayground.DI
{
    public class ServiceProviderHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ServiceProviderHttpControllerActivator(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (controllerDescriptor == null)
            {
                throw new ArgumentNullException(nameof(controllerDescriptor));
            }

            if (controllerType == null)
            {
                throw new ArgumentNullException(nameof(controllerType));
            }

            var scope = _scopeFactory.CreateScope();
            request.RegisterForDispose(scope);

            return (IHttpController)scope.ServiceProvider.GetRequiredService(controllerType);
        }
    }
}