using Common.Helpers;
using Common.Helpers.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kruger.DI
{
    public static class DIDependency
    {
        public static void AddDIDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.Load("Kruger.Application"));
            services.AddContextDependency(configuration);
            services.AddRepositoryDependency();
            services.AddMediatR(Assembly.Load("Kruger.Application"));
            services.AddScoped<IDateTimeHelper, DateTimeHelper>();
        }
    }
}
