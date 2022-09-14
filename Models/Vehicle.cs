using System.Text.Json.Serialization;

namespace Saitynai_Delivery_System1.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegNumbers { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int MaxPayload { get; set; } = 1000;
        [JsonIgnore]
        public User? Driver { get; set; }
        public int ? DriverId { get; set; }
        [JsonIgnore]
        public List<Package>? AssignedPackages { get; set; }
    }
}
