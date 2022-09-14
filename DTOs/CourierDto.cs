using Saitynai_Delivery_System1.Models;

namespace Saitynai_Delivery_System1.DTOs
{
    public class CourierDto
    {
        public string Email { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public double Wage { get; set; } = 1000;
    }
}
