using Saitynai_Delivery_System1.Models;
using System.ComponentModel.DataAnnotations;

namespace Saitynai_Delivery_System1.DTOs
{
    public class CourierDto
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
        [StringLength(30, MinimumLength = 9)]
        public string Password { get; set; } = string.Empty;
        [Phone]
        public string Phone { get; set; } = string.Empty;
        [Range(1, 999999)]
        public double Wage { get; set; } = 1000;
    }
}
