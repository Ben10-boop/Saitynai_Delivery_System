using System.Text.Json.Serialization;

namespace Saitynai_Delivery_System1.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Size { get; set; } = string.Empty;
        public double Weight { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        [JsonIgnore]
        public User Recipient { get; set; }
        public int RecipientId { get; set; }
        //In warehouse; Being delivered; Delivered;
        [JsonIgnore]
        public Delivery? AssignedToDelivery { get; set; }
        public int? AssignedToDeliveryId { get; set; }
        public string State { get; set; } = "in warehouse";
    }
}
