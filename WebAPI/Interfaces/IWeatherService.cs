using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IWeatherService
    {
        Task<string> GetWeatherForecastAsync(Input model);
    }
}
