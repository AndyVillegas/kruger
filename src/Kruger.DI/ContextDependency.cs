using Kruger.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kruger.DI
{
    public static class ContextDependency
    {
        public static void AddContextDependency(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(connectionString));
        }
    }
}
