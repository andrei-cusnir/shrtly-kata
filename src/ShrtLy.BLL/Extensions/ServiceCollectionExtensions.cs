using Microsoft.Extensions.DependencyInjection;
using ShrtLy.BLL.Modules;
using System.Linq;
using System;
using Microsoft.Extensions.Configuration;

namespace ShrtLy.BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterModules(this IServiceCollection serviceCollection, IConfiguration cfg)
        {
            var modules = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IModule).IsAssignableFrom(p) && p.IsClass);

            foreach (var module in modules)
            {
                var moduleInstance = (IModule)Activator.CreateInstance(module);
                moduleInstance.RegisterServices(serviceCollection, cfg);
            }

            return serviceCollection;
        }
    }
}
