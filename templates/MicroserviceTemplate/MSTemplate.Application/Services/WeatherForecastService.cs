using MSTemplate.Application.Common.Result;
using MSTemplate.Application.DTOs;
using MSTemplate.Application.Interfaces.Repositories;
using MSTemplate.Application.Interfaces.Services;

namespace MSTemplate.Application.Services;

public class WeatherForecastService(IWeatherForecastRepository forecastRepository) : IWeatherForecastService
{
    public async Task<Result<List<WeatherForecastDto>>> GetWeatherForecastsAsync(CancellationToken ct)
    {
        var weatherForecastsList = await forecastRepository.GetWeatherForecastsAsync(ct);
        if (weatherForecastsList is null)
            return Result<List<WeatherForecastDto>>.Failure(new Error(ErrorCode.NotFound, "Not found."));
        
        return Result<List<WeatherForecastDto>>
            .Success(weatherForecastsList
            .Select(f => new WeatherForecastDto(f.Date, f.TemperatureC, f.TemperatureF, f.Summary))
                .ToList());
    }
}
