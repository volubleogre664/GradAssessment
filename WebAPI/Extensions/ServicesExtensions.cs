namespace WebAPI.Extensions
{
    using WebAPI.Interfaces;
    using WebAPI.Services;

    public static class WeatherServiceIServiceCollectionExtensions
    {
        public static IServiceCollection AddWeatherService(this IServiceCollection services, ConfigurationManager configuration)
        {
            var host = configuration.GetConnectionString("WeatherAPIHost");
            var key = configuration.GetConnectionString("WeatherAPIKey");

            var serviceProvider = services.BuildServiceProvider();
            var cache = serviceProvider.GetRequiredService<ICacheService>();

            IWeatherService weatherService = new WeatherService(host, key, cache);
            services.AddSingleton(weatherService);

            return services;
        }
    }
}
