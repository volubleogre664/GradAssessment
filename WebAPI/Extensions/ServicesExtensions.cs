using WebAPI.Interfaces;
using WebAPI.Services;

namespace WebAPI.Extensions
{
    public static class WeatherServiceIServiceCollectionExtensions
    {
        public static IServiceCollection AddWeatherService(this IServiceCollection services, ConfigurationManager configuration)
        {
            var host = configuration.GetConnectionString("WeatherAPIHost");
            var key = configuration.GetConnectionString("WeatherAPIKey");

            IWeatherService weatherService = new WeatherService(host, key);

            services.AddSingleton(weatherService);

            return services;
        }
    }
}
