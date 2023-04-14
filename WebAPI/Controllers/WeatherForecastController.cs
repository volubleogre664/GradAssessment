
namespace WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[api/controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}