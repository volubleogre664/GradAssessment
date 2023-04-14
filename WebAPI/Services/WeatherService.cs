namespace WebAPI.Services
{
    using WebAPI.Interfaces;

    public class WeatherService : IWeatherService
    {
        private readonly string host;
        private readonly string key;
        private readonly HttpClient httpClient;

        public WeatherService(string host, string key)
        {
            this.host = host;
            this.key = key;
            this.httpClient = new HttpClient();
        }

        public async Task<string> GetWeatherForecastAsync(string city, int days)
        {
            var request = this.GenerateRequestMessage(city, days);

            var response = await this.httpClient.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

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
