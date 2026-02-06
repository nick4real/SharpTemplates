using Microsoft.Extensions.DependencyInjection;

namespace MSTemplate.Application;

public static class ServiceCollectionExtension
{
    extension (IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
            return services;
        }
    }
}
