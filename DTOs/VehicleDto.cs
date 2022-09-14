using Saitynai_Delivery_System1.Models;

namespace Saitynai_Delivery_System1.DTOs
{
    public class VehicleDto
    {
        public string RegNumbers { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int MaxPayload { get; set; } = 1000;
        public int? DriverId { get; set; } = null;
    }
}
