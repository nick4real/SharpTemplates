using MSTemplate.Application.Interfaces.Repositories;
using MSTemplate.Domain.Entities;

namespace MSTemplate.Infrastructure.Persistence.Repositories;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    public async Task<IReadOnlyList<WeatherForecast>?> GetWeatherForecastsAsync(CancellationToken ct)
    {
        if (ct.IsCancellationRequested)
            return null;

        var rng = new Random();
        var list = new List<WeatherForecast>
        {
            new WeatherForecast
            {
                Id = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                Summary = "Freezing",
                TemperatureC = rng.Next(-10, 0)
            },
            new WeatherForecast
            {
                Id = 2,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                Summary = "Bracing",
                TemperatureC = rng.Next(-10, 0)
            },
            new WeatherForecast
            {
                Id = 3,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                Summary = "Chilly",
                TemperatureC = rng.Next(0, 10)
            },
            new WeatherForecast
            {
                Id = 4,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(4)),
                Summary = "Cool",
                TemperatureC = rng.Next(0, 10)
            },
            new WeatherForecast
            {
                Id = 5,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                Summary = "Mild",
                TemperatureC = rng.Next(10, 20)
            }
        };

        return list;
    }
}
