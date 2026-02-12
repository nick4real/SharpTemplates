using Microsoft.Extensions.DependencyInjection;
#if (IncludeSampleLogic)
using MSTemplate.Application.Interfaces.Repositories;
#endif
using MSTemplate.Infrastructure.Persistence;
#if (IncludeSampleLogic)
using MSTemplate.Infrastructure.Persistence.Repositories;
#endif
namespace MSTemplate.Infrastructure;

public static class ServiceCollectionExtension
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure()
        {
            services.AddDbContext<AppDbContext>();

#if (IncludeSampleLogic)
            //Repositories
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

#endif
            return services;
        }
    }
}
