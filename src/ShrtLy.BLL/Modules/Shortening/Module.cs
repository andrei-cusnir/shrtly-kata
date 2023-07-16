using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShrtLy.BLL.Modules.Shortening.Services;
using ShrtLy.DAL;
using ShrtLy.DAL.Repositories;

namespace ShrtLy.BLL.Modules.Shortening
{
    public class Module : IModule
    {
        public IServiceCollection RegisterServices(IServiceCollection services, IConfiguration cfg)
        {
            services.AddTransient<IShorteningService, ShorteningService>();
            services.AddTransient<ILinksRepository, LinksRepository>();

            //services.AddTransient<ShrtLyContext>();
            return services;
        }
    }
}
