namespace WebAPI.Services
{
    using WebAPI.Interfaces;
    using WebAPI.Models;

    public class WeatherService : IWeatherService
    {
        private readonly string host;
        private readonly string key;
        private readonly HttpClient httpClient;
        private readonly ICacheService cacheService;

        public WeatherService(string host, string key, ICacheService cacheService)
        {
            this.host = host;
            this.key = key;
            this.httpClient = new HttpClient();
            this.cacheService = cacheService;
        }

        public async Task<string> GetWeatherForecastAsync(Input model)
        {
            var responseBody = this.cacheService.GetItem(model.City);

            if (responseBody != null)
            {
                return responseBody;
            }

            var request = this.GenerateRequestMessage(model.City, model.Days);

            var response = await this.httpClient.SendAsync(request);
            responseBody = await response.Content.ReadAsStringAsync();

            this.cacheService.SetItem(model.City, responseBody);

            return responseBody;
        }

        private HttpRequestMessage GenerateRequestMessage(string city, int days)
        {
            return new()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://" + this.host + "/forecast.json?q=" + city + "&days=" + days),
                Headers = 
                {
                    { "X-RapidAPI-Key", this.key },
                    { "X-RapidAPI-Host", this.host },
                },
            };
        }
    }
}
