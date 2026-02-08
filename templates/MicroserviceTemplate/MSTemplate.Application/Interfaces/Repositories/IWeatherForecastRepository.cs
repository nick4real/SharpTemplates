using MSTemplate.Domain.Entities;

namespace MSTemplate.Application.Interfaces.Repositories;

public interface IWeatherForecastRepository
{
    Task<IReadOnlyList<WeatherForecast>?> GetWeatherForecastsAsync(CancellationToken ct);
}
