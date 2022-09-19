using System.Text.Json.Serialization;

namespace Saitynai_Delivery_System1.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Vehicle DeliveryVehicle { get; set; }
        public int DeliveryVehicleId { get; set; }
        [JsonIgnore]
        public User DeliveryCourier { get; set; }
        public int DeliveryCourierId { get; set; }
        public string Route { get; set; } = string.Empty;
        public DateTime DeliveryDate { get; set; }
        [JsonIgnore]
        public List<Package> AssignedPackages { get; set; }
    }
}
