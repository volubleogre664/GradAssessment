namespace WebAPI.Interfaces
{
    public interface IWeatherService
    {
        Task<string> GetWeatherForecastAsync(string city, int days);
    }
}
