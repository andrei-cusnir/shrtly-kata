using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ShrtLy.BLL.Modules
{
    public interface IModule
    {
        public IServiceCollection RegisterServices(IServiceCollection services, IConfiguration cfg);
    }
}
