using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShrtLy.DAL;
using System;
using System.Reflection;

namespace ShrtLy.BLL.Modules.Shared
{
    public class Module : IModule
    {
        public IServiceCollection RegisterServices(IServiceCollection services, IConfiguration cfg)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDbContext<ShrtLyContext>(opt => opt.UseNpgsql(cfg.GetConnectionString("url")));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}
