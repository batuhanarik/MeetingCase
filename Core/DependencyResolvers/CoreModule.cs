using Microsoft.AspNetCore.Http;
using Core.Utiilites.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Core.Utiilites.Security.JWT;
using Microsoft.Extensions.Configuration;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<Stopwatch>();
            //serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
