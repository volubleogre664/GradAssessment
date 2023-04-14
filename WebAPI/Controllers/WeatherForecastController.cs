namespace WebAPI.Controllers
{
    using FluentValidation;
    using FluentValidation.AspNetCore;

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
        private readonly IValidator<Input> validator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService, IValidator<Input> validator)
        {
            this.logger = logger;
            this.weatherService = weatherService;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string city, int days)
        {
            var model = new Input() { City = city, Days = days };

            var result = this.validator.Validate(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return BadRequest(this.ModelState);
            }

            var res = await this.weatherService.GetWeatherForecastAsync(model);

            var weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(res);

            List<object> forecasts = new();

            weatherForecast.Forecast.Days.ForEach(_ =>
            {
                _.HourForecast.ForEach(HourForecast =>
                {
                    forecasts.Add(new
                    {
                        Date = _.Date.ToLongDateString(),
                        Time = HourForecast.Time.ToShortTimeString(),
                        HourForecast.Clouds,
                        HourForecast.FeelsLike,
                        HourForecast.Temperature,
                        HourForecast.Humidity,
                        HourForecast.WindDirection,
                        HourForecast.WindSpeed,
                    });
                });
            });

            return Ok(forecasts);
        }
    }
}