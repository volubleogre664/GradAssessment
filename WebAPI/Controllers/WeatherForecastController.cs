namespace WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    using WebAPI.Interfaces;
    using WebAPI.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> logger;

        private readonly IWeatherService weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            this.logger = logger;
            this.weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string city, int days = 1)
        {
            var res = await this.weatherService.GetWeatherForecastAsync(city, days);

            var weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(res);

            return Ok(weatherForecast);
        }
    }
}