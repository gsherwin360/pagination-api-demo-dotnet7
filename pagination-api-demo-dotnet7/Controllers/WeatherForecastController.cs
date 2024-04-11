using Microsoft.AspNetCore.Mvc;
using pagination_api_demo_dotnet7.Pagination;

namespace pagination_api_demo_dotnet7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // An array of 22 weather-related summaries used for pagination demonstration
        private static readonly string[] Summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching",
            "Sizzling",
            "Breezy",
            "Windy",
            "Foggy",
            "Overcast",
            "Cloudy",
            "Partly Cloudy",
            "Clear",
            "Rainy",
            "Showers",
            "Thunderstorms",
            "Snowy"
        };

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<PagedList<WeatherForecast>> Get([FromQuery] PagingParams pagingParams)
        {
            var weather = Enumerable.Range(0, Summaries.Length).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[index]
            }).AsQueryable();

            if (pagingParams != null && weather != null)
            {
                if (!string.IsNullOrWhiteSpace(pagingParams.SearchText))
                {
                    weather = weather.Where(x => x.Summary.ToLowerInvariant().Contains(pagingParams.SearchText.ToLowerInvariant()));
                }

                if (!string.IsNullOrWhiteSpace(pagingParams.SortBy))
                {
                    weather = SortList<WeatherForecast>.CreateAsync(weather, pagingParams).Result.AsQueryable();
                }
            }

            var result = await PagedList<WeatherForecast>.CreateAsync(weather != null ? weather.AsQueryable() : null, pagingParams.PageNumber, pagingParams.PageSize);

            return result;
        }
    }
}