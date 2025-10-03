using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIPlayground.DI
{
    public class ScopedDependencyHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += Context_EndRequest;
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;
            if (context.Items[typeof(IServiceScope)] is IServiceScope scope)
            {
                scope.Dispose();
                context.Items.Remove(typeof(IServiceScope));
            }
        }

        public void Dispose() { }
    }
}