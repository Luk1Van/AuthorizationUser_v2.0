using Microsoft.Extensions.DependencyInjection;
using User.Services;
using User.Services.Interfaces;

namespace DependencyInjection
{
    public static class Dependency
    {
        public static void AddMyServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IuserServices, userServices>();
        }
    }
}