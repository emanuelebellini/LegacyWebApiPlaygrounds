using Microsoft.Extensions.DependencyInjection;
using SimpleInjector.Integration.ServiceCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIPlayground.DI
{
    public class MsDiScopeModule : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.BeginRequest += (_, __) =>
                HttpContext.Current.Items[DiHost.ScopeKey] = DiHost.Root.CreateScope();

            app.EndRequest += (_, __) =>
                (HttpContext.Current.Items[DiHost.ScopeKey] as IServiceScope)?.Dispose();
        }
        public void Dispose() { }
    }
}