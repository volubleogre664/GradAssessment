namespace WebAPI.Models
{
    using Newtonsoft.Json;

    public class ForecastDay
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("day")]
        public DayAverage DayAverages { get; set; }

        [JsonProperty("hour")]
        public List<HourForecast> HourForecast { get; set; }
    }
}
