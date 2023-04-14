namespace WebAPI.Models
{
    using Newtonsoft.Json;
    
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public List<ForecastDay> Days { get; set; }
    }
}
