namespace WebAPI.Models
{
    using Newtonsoft.Json;

    public class DayAverage
    {
        [JsonProperty("avgtemp_c")]
        public decimal AverageTemperature { get; set; }

        [JsonProperty("maxtemp_c")]
        public decimal MaxTemperature { get; set; }

        [JsonProperty("mintemp_c")]
        public decimal MinTemperature { get; set; }

        [JsonProperty("maxwind_kph")]
        public decimal MaxWindSpeed { get; set; }

        [JsonProperty("avghumidity")]
        public decimal AverageHumidity { get; set; }
    }
}
