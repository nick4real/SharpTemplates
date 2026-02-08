using MSTemplate.Application.Common.Result;
using MSTemplate.Application.DTOs;

namespace MSTemplate.Application.Interfaces.Services;

public interface IWeatherForecastService
{
    Task<Result<List<WeatherForecastDto>>> GetWeatherForecastsAsync(CancellationToken ct);
}