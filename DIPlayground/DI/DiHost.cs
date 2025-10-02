using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIPlayground.DI
{
    public static class DiHost
    {
        public const string ScopeKey = "__msdi_scope";
        public static IServiceProvider Root { get; set; }

        public static IServiceProvider Current
        {
            get
            {
                return (HttpContext.Current?.Items[ScopeKey] as IServiceScope)?.ServiceProvider ?? Root;
            }
        }
}
}