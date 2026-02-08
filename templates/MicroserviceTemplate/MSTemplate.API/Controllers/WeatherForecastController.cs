using Microsoft.AspNetCore.Mvc;
using MSTemplate.Application.Interfaces.Services;

namespace MSTemplate.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IWeatherForecastService forecastService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetWeatherForecast(CancellationToken ct)
    {
        var result = await forecastService.GetWeatherForecastsAsync(ct);
        return HandleResult(result);
    }
}