using Microsoft.Extensions.DependencyInjection;

namespace MSTemplate.Infrastructure;

public static class ServiceCollectionExtension
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure()
        {
            return services;
        }
    }
}
