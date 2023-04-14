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

            return Ok(weatherForecast);
        }
    }
}