
namespace WebAPI.Models
{
    using Newtonsoft.Json;

    public class Location
    {
        [JsonProperty("name")]
        public string City { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
