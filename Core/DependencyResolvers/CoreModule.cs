﻿using Microsoft.AspNetCore.Http;
using Core.Utiilites.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            //serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
