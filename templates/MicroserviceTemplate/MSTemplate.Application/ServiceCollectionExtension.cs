using Microsoft.Extensions.DependencyInjection;
#if IncludeSampleLogic
using MSTemplate.Application.Interfaces.Services;
using MSTemplate.Application.Services;
#endif

namespace MSTemplate.Application;

public static class ServiceCollectionExtension
{
    extension (IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
#if IncludeSampleLogic
            //Services
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

#endif
            return services;
        }
    }
}
