namespace WebAPI.Models
{
    using Newtonsoft.Json;

    using WebAPI.Extensions;

    public class HourForecast
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("temp_c")]
        public decimal Temperature { get; set; }

        [JsonProperty("wind_kph")]
        public decimal WindSpeed { get; set; }

        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; }

        [JsonProperty("humidity")]
        public decimal Humidity { get; set; }

        [JsonProperty("feelslike_c")]
        public decimal FeelsLike { get; set; }

        [JsonProperty("cloud")]
        public decimal Clouds { get; set; }
    }
}
