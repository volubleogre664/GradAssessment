namespace WebAPI.Models
{
    using Newtonsoft.Json;

    public class WeatherForecast
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }
}
