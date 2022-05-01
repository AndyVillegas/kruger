using Kruger.Core.Interfaces.Repositories;
using Kruger.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Kruger.DI
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICarOwnerRepository, CarOwnerRepository>();
            services.AddTransient<IParkingPlaceRepository, ParkingPlaceRepository>();
            services.AddTransient<IRateRepository, RateRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IParkingRecordRepository, ParkingRecordRepository>();
        }
    }
}
