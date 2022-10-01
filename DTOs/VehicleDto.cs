using Saitynai_Delivery_System1.Models;
using System.ComponentModel.DataAnnotations;

namespace Saitynai_Delivery_System1.DTOs
{
    public class VehicleDto
    {
        public string RegNumbers { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        [Range(0, 999999)]
        public int MaxPayload { get; set; } = 0;
        public int? DriverId { get; set; } = null;
    }
}
