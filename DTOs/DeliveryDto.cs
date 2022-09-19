using Saitynai_Delivery_System1.Models;

namespace Saitynai_Delivery_System1.DTOs
{
    public class DeliveryDto
    {
        public int DeliveryVehicleId { get; set; } = 0;
        public int DeliveryCourierId { get; set; } = 0;
        public string Route { get; set; } = string.Empty;
        public DateTime DeliveryDate { get; set; } = DateTime.Now;
    }
}
